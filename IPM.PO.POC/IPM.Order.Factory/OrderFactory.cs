using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace IPM.Order.Factory
{

    /// <summary>
    /// A simple order factory that creates various types of automobiles
    /// based on a key for Type lookup
    /// </summary>
    public class OrderFactory
    {
        Dictionary<string, Type> orders;

        public OrderFactory()
        {
            LoadTypesICanReturn();
        }

        public IOrder CreateInstance(string carName)
        {
            Type t = GetTypeToCreate(carName);

            if (t == null)
                return new DefaultOrder();

            return Activator.CreateInstance(t) as IOrder;
        }

        Type GetTypeToCreate(string carName)
        {
            foreach (var auto in orders)
            {
                if (auto.Key.Contains(carName))
                {
                    return orders[auto.Key];
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
