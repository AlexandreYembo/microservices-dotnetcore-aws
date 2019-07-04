using System.Net;
using System.Threading.Tasks;
using AdvertModel;
using AdvertModel.Confirm;
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

        public async Task<ConfirmAdvertModelResult> Confirm(ConfirmAdvertModel model, string topicArn)
        {
             if(model.Status == AdvertStatus.Active){
                await _storageRespository.Confirm(model);
                return new ConfirmAdvertModelResult(await SendConfirmationMessage(model.Id, topicArn));
             } 
            await _storageRespository.Delete(model);

            return new ConfirmAdvertModelResult(HttpStatusCode.OK, "Record is not active has been removed");              
        }

        private async Task<HttpStatusCode> SendConfirmationMessage(string id, string topicArn) =>
            await _messageRepository.RaiseAdvertConfirmedMessage(new ConfirmMessage{Id = id}, topicArn);
    }
}