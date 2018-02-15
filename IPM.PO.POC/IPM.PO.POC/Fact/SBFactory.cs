using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessing.POC.Fact
{
    public class SBFactory : IOrderFactory
    {
        public IOrder CreateProcessor()
        {
            return new SBOrder();
        }
    }
}
