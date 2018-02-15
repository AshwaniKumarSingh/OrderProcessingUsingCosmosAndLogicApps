using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Order.Factory.Order
{
    public class PurchaseOrderDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
