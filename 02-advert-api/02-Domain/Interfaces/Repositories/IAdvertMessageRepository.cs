using System.Net;
using System.Threading.Tasks;
using AdvertModel.Confirm;

namespace Domain.Interfaces.Repositories
{
    public interface IAdverMessageRepository
    {
        Task<HttpStatusCode> RaiseAdvertConfirmedMessage(ConfirmMessage model, string topicArn);
    }
}