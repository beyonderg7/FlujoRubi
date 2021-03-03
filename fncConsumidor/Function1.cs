

namespace fncConsumidor
{

    using fncConsumidor.Models;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System;

    public static class Function1
    {
        [FunctionName("Function1")]
        public static async void Run(
            
            [ServiceBusTrigger
            
                    ("cola1", 
                    Connection = "MyConn"
                    )]string myQueueItem,


          [CosmosDB(
                    databaseName:"dbUbicua",
                    collectionName:"Eventos",
                    ConnectionStringSetting ="strCosmos"

                )]IAsyncCollector<object>datos,

            ILogger log)
        {
            try
            {

                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");

                var data = JsonConvert.DeserializeObject<Data>(myQueueItem);

                await datos.AddAsync(data);

            }

            catch(Exception ex)
            {

                log.LogError($"No fue posible insertar datos:{ex.Message}");
            }


        }
    }
}
