USE [Sales]
GO
/****** Object:  StoredProcedure [dbo].[calculate_commision2]    Script Date: 12/13/2021 12:57:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[calculate_commision]  
			@employeeId bigint ,
			@transDate Datetime
			
	AS 


	
	BEGIN TRY       
        declare @transDateStr varchar(10);
		set @transDateStr = convert(varchar(10), @transDate, 112)

		
		IF OBJECT_ID(N'tempdb..#emplSales') IS NOT NULL
		BEGIN
		DROP TABLE #emplSales
		END

		-- Create employee table (stores  hierarchical data with total sales in transdate)
		CREATE TABLE #emplSales (
		   Amount  decimal(18,2),
		   EmployeeId bigint,
		   Level int
		);

		IF OBJECT_ID(N'tempdb..#commResult') IS NOT NULL
		BEGIN
		DROP TABLE #commResult
		END

		
		-- Create commission table. calculated commission data
		CREATE TABLE #commResult (
		   Amount  decimal(18,2),
		   EmployeeId bigint,
		   Level int
		);

		--recursivly loops employee hierarchy and inserts  accumalated  sales amounts into #emplSales table
		WITH cte_org(Level,Id,ManagerId) AS (
			SELECT  
				1 as Level,
				k.Id, 
				k.ManagerId
			FROM       
				Employees as k
			WHERE k.Id = @employeeId
			UNION ALL
			SELECT 
				o.Level + 1,
				e.Id, 
				e.ManagerId
			FROM 
				Employees e
				INNER JOIN cte_org o 
					ON o.Id = e.ManagerId
		)
		insert into #emplSales(Amount,EmployeeId,Level)
		SELECT sum(s.amount) as amount,c.Id,c.Level fROM cte_org as c
		join SalesOrders as s on s.EmployeeId = c.Id and CAST(s.CreateDate as Date) = @transDateStr and s.Status = 2
		group by c.Id,c.Level

		order by c.Level asc;

		DECLARE 
			@amount decimal (18,2), 
			@empId   bigint,
			@level int;

			DECLARE empl_com CURSOR
		FOR SELECT 
				Amount, 
				EmployeeId,
				Level
			FROM 
				#emplSales;

		OPEN empl_com;

		FETCH NEXT FROM empl_com INTO 
			@amount, 
			@empId,
			@level;
			--loops through accumulated sales  and  calles  recursive table valued function to calculate  all commissions
		WHILE @@FETCH_STATUS = 0
			BEGIN
				insert into #commResult(Amount,EmployeeId,Level)
				select acom.Amount,(select e.EmployeeId from #emplSales as e where e.Level = acom.Level),acom.Level from [dbo].[get_agent_accumulated_comm] (@level,@amount) as acom
				FETCH NEXT FROM empl_com INTO 
			@amount, 
			@empId,
			@level;
			END;

		CLOSE empl_com;

		DEALLOCATE empl_com;

		--sum of all commissions  grouped by employee
		select sum(c.Amount) AS Amount,c.EmployeeId from #commResult as c
		group by c.EmployeeId

		IF OBJECT_ID(N'tempdb..#empl') IS NOT NULL
		BEGIN
		DROP TABLE #empl
		END
    
                                
		END TRY
		BEGIN CATCH
			IF OBJECT_ID(N'tempdb..#emplSales') IS NOT NULL
			BEGIN
			DROP TABLE #emplSales
			END


			IF OBJECT_ID(N'tempdb..#commResult') IS NOT NULL
			BEGIN
			DROP TABLE #commResult
			END
		END CATCH
	
