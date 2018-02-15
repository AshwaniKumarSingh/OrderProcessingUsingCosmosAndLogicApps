using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Order.Factory
{
    public class DefaultOrder : IOrder
    {
        public string TurnOn()
        {
            return " trun on defualt";
        }
        public string TurnOff()
        {
            return "turnoff";
        }
    }
}
