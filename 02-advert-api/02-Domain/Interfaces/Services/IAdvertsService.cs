using System.Threading.Tasks;
using AdvertModel;

namespace Domain.Interfaces.Services
{
    public interface IAdvertsService
    {
        Task<string> Add(Advert model);
        Task Confirm(ConfirmAdvertModel model);
    }
}