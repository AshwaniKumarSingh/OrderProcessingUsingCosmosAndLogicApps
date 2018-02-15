using OrderProcessing.POC.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessing.POC.Fact
{
  public  interface IOrder
    {
        PurchaseOrderCreationdDto GetOrder(int orderId, IDictionary<string, string> collKeys );
        Boolean SaveOrder(PurchaseOrderCreationdDto vOrder, IDictionary<string, string> collKeys);
    }
}
