using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;


namespace QueueReceiver
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

        // the processor that reads and processes messages from the queue 
        static ServiceBusProcessor? processor;

        // handle received messages 
        static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();


            Bajer ølDe = JsonSerializer.Deserialize<Bajer>(body);

            Console.WriteLine($"Received: ID: {ølDe.ID}, Name: {ølDe.Name}, Smag: {ølDe.Smag}");

            // complete the message. messages is deleted from the queue.  
            await args.CompleteMessageAsync(args.Message);
        }

        // handle any errors when receiving messages 
        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

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

            // Create the client object that will be used to create sender and receiver objects
            client = new ServiceBusClient(connectionString);

            // create a processor that we can use to process the messages 
            processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());

            try
            {
                // add handler to process messages 
                processor.ProcessMessageAsync += MessageHandler;

                // add handler to process any errors 
                processor.ProcessErrorAsync += ErrorHandler;

                // start processing  
                await processor.StartProcessingAsync();

                Console.WriteLine("Wait for a minute and then press any key to end the processing");
                Console.Read();

                // stop processing  
                Console.WriteLine("\nStopping the receiver...");
                await processor.StopProcessingAsync();
                Console.WriteLine("Stopped receiving messages");
            }
            finally
            {
                // Calling DisposeAsync on client types is required to ensure that |network 
                // resources and other unmanaged objects are properly cleaned up. 
                await processor.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}