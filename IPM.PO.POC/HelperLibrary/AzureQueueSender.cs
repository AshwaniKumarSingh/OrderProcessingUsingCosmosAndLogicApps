using System;
using System.Collections.Generic;
using System.Text;

namespace HelperLibrary
{
    public class AzureQueueSender<T> : IAzureQueueSender<T> where T : class
    {
        public AzureQueueSender(AzureQueueSettings settings)
        {
            this.settings = settings;
            Init();
        }

        public async Task SendAsync(T item, Dictionary<string, object> properties)
        {
            var json = JsonConvert.SerializeObject(item);
            var message = new Message(Encoding.UTF8.GetBytes(json));

            if (properties != null)
            {
                foreach (var prop in properties)
                {
                    message.UserProperties.Add(prop.Key, prop.Value);
                }
            }

            await client.SendAsync(message);
        }

        private AzureQueueSettings settings;
        private QueueClient client;

        private void Init()
        {
            client = new QueueClient(
  is.settings.ConnectionString, this.settings.QueueName);
        }
    }
}
