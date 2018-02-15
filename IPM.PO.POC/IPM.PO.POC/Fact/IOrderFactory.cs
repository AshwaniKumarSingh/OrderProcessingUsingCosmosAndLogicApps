using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessing.POC.Fact
{
  public  interface IOrderFactory
    {
        IOrder CreateProcessor();
    }
}
 