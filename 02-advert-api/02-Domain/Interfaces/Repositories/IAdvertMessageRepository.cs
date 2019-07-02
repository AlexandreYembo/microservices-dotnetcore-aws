using System.Threading.Tasks;
using AdvertModel;

namespace Domain.Interfaces.Repositories
{
    public interface IAdverMessageRepository
    {
        Task SendConfirmMessage(ConfirmMessage model, string topicArn);
    }
}