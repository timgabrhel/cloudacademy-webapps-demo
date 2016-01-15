using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure;

namespace webjob_queue_trigger
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting ServiceBus Trigger...");
            Console.WriteLine();

            var connectionString = AmbientConnectionStringProvider.Instance.GetConnectionString(ConnectionStringNames.ServiceBus);

            JobHostConfiguration config = new JobHostConfiguration();
            ServiceBusConfiguration serviceBusConfig = new ServiceBusConfiguration
            {
                ConnectionString = connectionString
            };
            config.UseServiceBus(serviceBusConfig);

            JobHost host = new JobHost(config);
            host.RunAndBlock();
        }

        public static void Trigger([ServiceBusTrigger("CloudAcademy")] BrokeredMessage message)
        {
            var output = $"MessageId: {message.MessageId} | Body: {message.GetBody<string>()}";
            Console.WriteLine(output);
        }
    }
}
