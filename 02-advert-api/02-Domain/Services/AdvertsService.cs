using System.Threading.Tasks;
using AdvertModel;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class AdvertsService : IAdvertsService
    {
        protected readonly IAdvertStorageRepository _storageRespository;

        public AdvertsService(IAdvertStorageRepository storageRepository){
            _storageRespository = storageRepository;
        }

        public Task<string> Add(Advert model) =>  
            _storageRespository.Add(model);

        public Task Confirm(ConfirmAdvertModel model) => 
            model.Status == AdvertStatus.Active ? _storageRespository.Confirm(model) : _storageRespository.Delete(model); 
    }
}