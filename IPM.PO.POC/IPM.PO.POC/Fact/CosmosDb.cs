using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderProcessing.POC.Model;
using IPM.OrderAPI;
using Microsoft.Azure.Documents.Client;

namespace OrderProcessing.POC.Fact
{
    public class CosmosDb : IOrder
    {
       
        public PurchaseOrderCreationdDto GetOrder(int orderId, IDictionary<string, string> collKeys)
        {
            //   readonly string endpointUrl = "https://labcosmosdbacc.documents.azure.com:443/";
            //  readonly string authorizationKey = "eAC8yqwMnQi2KG2vDyf0qLuCMbMK8MWhjw0HooYaOavUXJeahROMRSlvRAy72EgCPX0aOmlnSzfI1oiHfOFKIw==";
            DocumentClient client;
            string str = string.Empty;

           // using (client = new DocumentClient(new Uri(collKeys["endpointUrl"]), collKeys["authorizationKey"]))
         //   {
               // var task = CosmosDB.QueryWithStoredProcs("labdatabase", "labdatabasecollection", @"./scripts/spQuery.js", collKeys, orderId);
               // var or = task;
                Console.WriteLine("demo");

          //  }





            return null;

        }

        public bool SaveOrder(PurchaseOrderCreationdDto vOrder, IDictionary<string, string> collKeys)
        {
            throw new NotImplementedException();
        }
    }
}
