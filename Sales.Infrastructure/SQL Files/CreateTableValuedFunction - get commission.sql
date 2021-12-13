USE [Sales]
GO
/****** Object:  UserDefinedFunction [dbo].[fnchkID]    Script Date: 12/13/2021 1:09:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[get_agent_accumulated_comm] (@level INT,@amount decimal (18,2))
RETURNS @AccumulatedCommissions TABLE
(
Amount decimal(18,2),
Level int
)AS
BEGIN

	if(@level = 1)
		begin
		insert into @AccumulatedCommissions(Amount,Level)
		select @amount * 0.7 ,@level 
		return
		end

		--recursive  CTE.  calculates  sales agent commission  through  hierarchy  
	;WITH cte_numbers(n, amount) 
		AS (
			SELECT 
				1, 
				CAST(@amount * 0.3 as DECIMAL(18,2))
			UNION ALL
			SELECT    
				n + 1, 
				CAST(amount - CAST(amount * 0.3 as DECIMAL(18,2)) as DECIMAL(18,2))
			FROM    
				cte_numbers
			WHERE n < @level - 1
		)
	
			insert INTO @AccumulatedCommissions
			SELECT amount,n FROM cte_numbers;

			
			insert into @AccumulatedCommissions(Amount,Level)
			select @amount - sum(Amount),max(Level) + 1 from @AccumulatedCommissions
    
		RETURN
	END