using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.Models
{
    public class GetCommissionsRequest
    {
        public long EmployeeId { get; set; }

        public DateTime TransDate { get; set; }
    }
}
