using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace Advert.SearchWorker
{
    public class SearchWorker
    {
        public void Function(SNSEvent sndEvent, ILambdaContext context)
        {
            foreach (var record in sndEvent.Records)
            {
                context.Logger.LogLine(record.Sns.Message);
            }
        }
    }
}
