using System.Threading.Tasks;
using AdvertModel;
using AdvertModel.Confirm;

namespace Domain.Interfaces.Services
{
    public interface IAdvertsService
    {
        Task<string> Add(Advert model);
        Task<ConfirmAdvertModelResult> Confirm(ConfirmAdvertModel model, string topicArn);
    }
}