using System.Threading.Tasks;
using AdvertModel;
using Amazon.SimpleNotificationService;
using Domain.Interfaces.Repositories;
using Newtonsoft.Json;

namespace Infrastructure.Repositories{
    public class AdverMessageRepository : IAdverMessageRepository
    {
        public async Task SendConfirmMessage(ConfirmMessage model, string topicArn)
        {
            using (var client = new AmazonSimpleNotificationServiceClient())
            {
                var messageJson = JsonConvert.SerializeObject(model);
                await client.PublishAsync(topicArn, messageJson);
            }
        }
    }
}