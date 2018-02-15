using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Azure.ServiceBus;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OrderProcessing.POC.Model;

namespace OrderProcessing.POC.Fact
{
    /// <summary>
    /// 
    /// Service bus save and retrieve order
    /// 
    /// </summary>
    public class SBOrder : IOrder
    {
        static IQueueClient queueClient;
        private IConfiguration configuration;

        public SBOrder()
        {
        }

        public bool SaveOrder(PurchaseOrderCreationdDto order, IDictionary<string, string> collKeys)
        {
            queueClient = new QueueClient(collKeys["ConnectionString"], collKeys["Queue"], ReceiveMode.PeekLock, null);
            try
            {
                var json = JsonConvert.SerializeObject(order);
                queueClient.SendAsync(new Message(Encoding.UTF8.GetBytes(json)));

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public PurchaseOrderCreationdDto GetOrder(int orderId,  IDictionary<string, string> collKeys)
        {
            throw new NotImplementedException();
        }
    }
}
