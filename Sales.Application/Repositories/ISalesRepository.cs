using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Repositories
{
    public interface ISalesRepository
    {
        Task CreateSalesOrder();

        Task ApproveSalesOrder();
    }
}
