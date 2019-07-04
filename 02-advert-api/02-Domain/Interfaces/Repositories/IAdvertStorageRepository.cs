using System.Threading.Tasks;
using AdvertModel;
using AdvertModel.Confirm;

namespace Domain.Interfaces.Repositories
{
    public interface IAdvertStorageRepository
    {
        Task<string> Add(Advert model);
        Task Confirm(ConfirmAdvertModel model);
        Task Delete(ConfirmAdvertModel model);

        Task<bool> CheckHealthAsync();
    }
}