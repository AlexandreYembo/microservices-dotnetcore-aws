using System.Net;
using System.Threading.Tasks;
using AdvertModel.Confirm;
using Amazon.SimpleNotificationService;
using Domain.Interfaces.Repositories;
using Newtonsoft.Json;

namespace Infrastructure.Repositories{
    public class AdverMessageRepository : IAdverMessageRepository
    {
        public async Task<HttpStatusCode> RaiseAdvertConfirmedMessage(ConfirmMessage model, string topicArn)
        {
            using (var client = new AmazonSimpleNotificationServiceClient())
            {
                var messageJson = JsonConvert.SerializeObject(model);
                var result = await client.PublishAsync(topicArn, messageJson);
                return result.HttpStatusCode;
            }
        }
    }
}