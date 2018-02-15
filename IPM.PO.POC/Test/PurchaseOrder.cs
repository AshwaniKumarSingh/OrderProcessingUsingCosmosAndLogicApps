using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace IPM.Order.NunitTest
{
    [TestFixture]
    public class PurchaseOrder
    {
        private HttpClient client;

        private HttpResponseMessage response;
        [SetUp]
        public void SetUp()
        {
            client.BaseAddress = new Uri("http://localhost:54806");
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

        }

        [Test]
        public void GetPurchaseOrder()
        {
            HttpResponseMessage response = client.GetAsync("/api/1").Result;
            string stringData = response.Content.
                ReadAsStringAsync().Result;
            Assert.Pass();

        }

        [Test]
        public void CreatePurchaseOrder()
        {
            HttpResponseMessage response = client.GetAsync("/api/1").Result;
            string stringData = response.Content.
                ReadAsStringAsync().Result;
            Assert.Pass();

        }



    }
}
