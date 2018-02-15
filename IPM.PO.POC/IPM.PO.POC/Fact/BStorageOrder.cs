using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderProcessing.POC.Model;

namespace OrderProcessing.POC.Fact
{
    public class BStorageOrder : IOrder
    {
        public PurchaseOrderCreationdDto GetOrder(int orderId, IDictionary<string, string> collKeys)
        {
            throw new NotImplementedException();
        }

        public bool SaveOrder(PurchaseOrderCreationdDto vOrder, IDictionary<string, string> collKeys)
        {
            throw new NotImplementedException();
        }

        
    }
}
