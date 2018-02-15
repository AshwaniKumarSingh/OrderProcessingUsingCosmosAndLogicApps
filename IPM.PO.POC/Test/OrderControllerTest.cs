using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NUnit.Framework;
using OrderProcessing.POC.Controllers;
using OrderProcessing.POC.Model;

namespace IPM.Order.NunitTest
{
    
    public class OrderControllerTest
    {
        private HttpClient client;
        private HttpResponseMessage response;
        [SetUp]
        public void SetUp()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54806");
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }

        [Test]
        public void GetOrder()
        {
            response = client.GetAsync("/api/1").Result;
            string stringData = response.Content.
                ReadAsStringAsync().Result;
            Assert.That(true, Is.EqualTo(response.Content.ReadAsStringAsync().Result.Contains("Jacket")));
        }

        [Test]
        public void CreatePurchaseOrder()
        {
            var ord = new PurchaseOrderCreationdDto() { Id = "1", ItemName = "Jacket", ItemQuantity = "10", ItemDescription = "test", Status = "test2" };
            string stringData = JsonConvert.SerializeObject(ord);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("/api/PurchaseOrder", contentData).Result;
            Assert.That("OK", Is.EqualTo(response.StatusCode.ToString()));
        }
    }



}
