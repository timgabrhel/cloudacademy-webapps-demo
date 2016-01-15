using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace webjob_queue_pump
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting ServiceBus Pump...");
            Console.WriteLine();

            var connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            // Create the root topic
            if (!namespaceManager.QueueExists("CloudAcademy"))
            {
                namespaceManager.CreateQueue("CloudAcademy");
            }
            
            var queueClient = QueueClient.CreateFromConnectionString(connectionString, "CloudAcademy");

            var i = 0;
            while (true)
            {
                queueClient.Send(new BrokeredMessage(i.ToString()));
                Console.WriteLine($"Sent {i}");
                i++;
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}
