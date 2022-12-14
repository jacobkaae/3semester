using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;

namespace QueueSender
{
    public class Bajer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Smag { get; set; }
    }

    class Program
    {
        // connection string to your Service Bus namespace 
        //static string connectionString = "Endpoint=sb://ibasnamespace55.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gqsoaF93vX4QRVJqfLpvCSGXTYhBezQklsY9Q6J3dnw=";

        //// name of your Service Bus queue 
        //static string queueName = "ibasproductionqueue";

        // the client that owns the connection and can be used to create senders and receivers
        static ServiceBusClient? client;

        // the sender used to publish messages to the queue 
        static ServiceBusSender? sender;

        // number of messages to be sent to the queue 
        private const int numOfMessages = 3;

        static async Task Main()
        {
            // The Service Bus client types are safe to cache and use as a singleton for the lifetime
            // of the application, which is best practice when messages are being published or read
            // regularly. 

            // Hent miljø-variabel med key-vault name
            string? keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");

            // Bygger en URL streng til keyvault
            var kvUri = "https://" + keyVaultName + ".vault.azure.net";
            Console.WriteLine("Using key vault @ {0}", kvUri);

            // Forbind til Key Vault
            var Keyclient = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            // Hent hemmelighed
            var secret1 = await Keyclient.GetSecretAsync("ConnectionString");
            var connectionString = secret1.Value.Value;

            var secret2 = await Keyclient.GetSecretAsync("QueueName");
            var queueName = secret2.Value.Value;

            // Create the clients that we'll use for sending and processing messages.
            client = new ServiceBusClient(connectionString);
            sender = client.CreateSender(queueName);


            // create a batch  
            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

            // Serialize C# object
            List<Bajer> bajere = new List<Bajer> {
            new Bajer { ID = 1, Name = "Tuborg Classic", Smag = "God" },
            new Bajer { ID = 2, Name = "Heiken", Smag = "Brækker mig" },
            new Bajer { ID = 3, Name = "1669 Blanc", Smag = "Ku godt" },
            new Bajer { ID = 4, Name = "Guinnees", Smag = "Ved ikke helt endnu" }
            };


            foreach (var bajer in bajere)
            {
                string jsonString = JsonSerializer.Serialize(bajer);

                // try adding a message to the batch 
                if (!messageBatch.TryAddMessage(new ServiceBusMessage(jsonString)))
                {
                    // if it is too large for the batch 
                    throw new Exception($"The message is too large to fit in the batch.");
                }
            }            
               
            try
            {
                // Use the producer client to send the batch of messages to the Service Bus queue
                await sender.SendMessagesAsync(messageBatch);
                Console.WriteLine($"A batch of {bajere.Count()} messages has been published to the queue.");
            }
            finally
            {
                // Calling DisposeAsync on client types is required to ensure that network
                // resources and other unmanaged objects are properly cleaned up. 
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }

            Console.WriteLine("Press any key to end the application");
            Console.Read();
        }
    }
}