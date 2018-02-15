using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace OrderProcessing.POC.Fact
{

  /// <summary>
  /// Collection creation for list of assemblies
  /// </summary>
    public class OrderFactory
    {
        Dictionary<string, Type> orders;

        public OrderFactory()
        {
            LoadTypesICanReturn();
        }

        public IOrder CreateInstance(string OrderStorage)
        {
            Type t = GetTypeToCreate(OrderStorage);

            if (t == null)
                return new DefaultStorage();

            return Activator.CreateInstance(t) as IOrder;
        }

        Type GetTypeToCreate(string OrderName)
        {
            foreach (var vOrd in orders)
            {
                if (vOrd.Key.Contains(OrderName))
                {
                    return orders[vOrd.Key];
                }
            }

            return null;
        }

        void LoadTypesICanReturn()
        {
            orders = new Dictionary<string, Type>();

            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterface(typeof(IOrder).ToString()) != null)
                {
                    orders.Add(type.Name.ToLower(), type);
                }
            }
        }
    }

}
