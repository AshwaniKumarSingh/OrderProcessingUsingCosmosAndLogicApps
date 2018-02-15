using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Order.Factory.Order
{
    class OrderSample : IOrder
    {
        public string TurnOn()
        {
            return " trun on smape";
        }
        public string TurnOff()
        {
            return "turnoff sample";
        }
    }
}
