using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace OrderProcessing.POC.Model
{
    public class PurchaseOrderCreationdDto
    {

        [Required(ErrorMessage = "You should provide a name value.")]
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("itemname")]
        public string ItemName { get; set; }
        [JsonProperty("itemquantity")]
        public string ItemQuantity { get; set; }
        [JsonProperty("itemdescription")]
        public string ItemDescription { get; set; }
        [JsonProperty("status")]
        public string Status{ get; set; }

    }
}
