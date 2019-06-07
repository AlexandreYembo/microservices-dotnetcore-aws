using System.Threading.Tasks;
using AdvertModel;

namespace Domain.Interfaces.Repositories
{
    public interface IAdvertStorageRepository
    {
        Task<string> Add(Advert model);
        Task Confirm(ConfirmAdvertModel model);
        Task Delete(ConfirmAdvertModel model);
    }
}