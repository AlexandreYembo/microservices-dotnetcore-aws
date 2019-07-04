using System.Threading.Tasks;
using AdvertModel;
using AdvertModel.Messages;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class AdvertsService : IAdvertsService
    {
        protected readonly IAdvertStorageRepository _storageRespository;
        protected readonly IAdverMessageRepository _messageRepository;


        public AdvertsService(IAdvertStorageRepository storageRepository, IAdverMessageRepository messageRepository)
        {
            _storageRespository = storageRepository;
            _messageRepository = messageRepository;
        }

        public async Task<string> Add(Advert model) =>  
           await _storageRespository.Add(model);

        public async Task Confirm(ConfirmAdvertModel model, string topicArn)
        {
             if(model.Status == AdvertStatus.Active){
                await _storageRespository.Confirm(model);
               
                var message = new AdvertConfirmedMessage()
                {
                    Id = model.Id, Title = "TO DO"
                };

                await _messageRepository.SendConfirmMessage(null, topicArn);
             } 
              await _storageRespository.Delete(model); 
        }
    }
}