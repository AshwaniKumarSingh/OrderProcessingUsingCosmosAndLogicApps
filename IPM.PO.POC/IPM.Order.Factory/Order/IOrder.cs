using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Order.Factory
{
    public interface IOrder
    {
        PurchaseOrderDto GetOrder(int orderId);
        Boolean SaveOrder(PurchaseOrderDto vOrder);
    }
}