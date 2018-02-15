using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OrderProcessing.POC.Fact;
using OrderProcessing.POC.Model;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.SystemFunctions;

namespace OrderProcessing.POC.Controllers
{
    [Route("api")]
    public class PurchaseOrderController : Controller
    {
        /// <summary>
        /// Order processing Controller
        /// CRUD operation on various data source
        /// </summary>

        private OrderFactory Factory { get; set; }
        private IDictionary<string, string> KeyColl;
        private IOrder order;
        static DocumentClient client;

        public PurchaseOrderController(IConfiguration iConfiguration)
        {
            KeyColl = new Dictionary<string, string>();
            KeyColl.Add("Namespace", iConfiguration["serviceBusNamespace"]);
            KeyColl.Add("PKey", iConfiguration["serviceBusKey"]);
            KeyColl.Add("Queue", iConfiguration["serviceBusTopicName"]);
            KeyColl.Add("ConnectionString", iConfiguration["connectionString"]);
            KeyColl.Add("endpointUrl", iConfiguration["endpointUrl"]);
            KeyColl.Add("authorizationKey", iConfiguration["authorizationKey"]);
            KeyColl.Add("scriptPath", iConfiguration["scriptPath"]);

            this.Factory = new OrderFactory();
        }

        [HttpGet("")]
        public IActionResult GetOrder()
        {
            return NotFound("Please provide valid query params");
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var scriptPath = @"./script/SP_GetOrderById.js";
            var response = string.Empty;
            using (client = new DocumentClient(new Uri(KeyColl["endpointUrl"]), KeyColl["authorizationKey"]))
            {
                var vtask = QueryWithStoredProcs("labdatabase", "labdatabasecollection", scriptPath, id);
                if (vtask.Result == null)
                {
                    return NotFound();
                }
                return Ok(vtask.Result);
            }
        }

        [HttpPost("PurchaseOrder")]
        public IActionResult CreatePurchaseOrder([FromBody] PurchaseOrderCreationdDto pOrder)
        {
            if (pOrder == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            order = Factory.CreateInstance("sborder");
            // order = Factory.CreateInstance("blobstorage");
            //  order = Factory.CreateInstance("defaultStorage");

            Boolean result = order.SaveOrder(pOrder, KeyColl);

            return Ok();


        }

        /// <summary>
        ///  Move this implementation to factory Project
        /// </summary>


        static async Task<string> QueryWithStoredProcs(string databaseId, string collectionId
            , string scriptPath, int id)
        {
            var rsp = string.Empty;
            var collection = await client.ReadDocumentCollectionAsync(
                UriFactory.CreateDocumentCollectionUri(databaseId, collectionId));

            string scriptId = Path.GetFileNameWithoutExtension(scriptPath);

            var storedProcedure = new StoredProcedure
            {
                Id = scriptId,
                Body = System.IO.File.ReadAllText(scriptPath)
            };

            StoredProcedure procedure = client.CreateStoredProcedureQuery(
                    collection.Resource.SelfLink).
                Where(x => x.Id == storedProcedure.Id).
                AsEnumerable().FirstOrDefault();
            if (procedure != null)
            {
                client.DeleteStoredProcedureAsync(procedure.SelfLink).Wait();
            }

            storedProcedure = await client.CreateStoredProcedureAsync(
                collection.Resource.SelfLink, storedProcedure);

            var response = await client.ExecuteStoredProcedureAsync<string>(
                  storedProcedure.SelfLink,
                  " where r.id='" + id + "'");

            rsp = response.Response;
            return rsp;

        }
    }
}
