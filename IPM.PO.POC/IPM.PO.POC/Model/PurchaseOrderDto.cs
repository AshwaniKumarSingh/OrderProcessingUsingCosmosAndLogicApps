using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrderProcessing.POC.Model
{
    public class PurchaseOrderDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
