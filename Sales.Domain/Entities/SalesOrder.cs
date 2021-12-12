using Sales.Domain.Enums;
using System;

namespace Sales.Domain.Entities
{
    public class SalesOrder
    {
        public long Id { get; set; }

        public DateTime CreateDate { get; set; }

        public SalesOrderStatus Status { get; set; }

        public long EmployeeId { get; set; }

        public DateTime ApproveDate { get; set; }

        public decimal Qty { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

        public Employee Employee { get; set; }
    }
}
