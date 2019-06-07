using System.Threading.Tasks;
using AdvertModel;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class DynamoDBAdvertStorage : IAdvertStorageRepository
    {
        private readonly IMapper _mapper;

        public DynamoDBAdvertStorage(IMapper mapper){
            _mapper = mapper;
        }
        public async Task<string> Add(Advert model)
        {
            var dbModel = _mapper.Map<AdvertDbModel>(model);
            dbModel.Id = new Guid().ToString();
            dbModel.CreationDateTime = DateTime.UtcNow;
            dbModel.Status = AdvertStatus.Pending;

            using (var client = new AmazonDynamoDBClient())
            {
                using(var context = new DynamoDBContext(client))
                {
                    await context.SaveAsync(dbModel);
                }
            }
            return dbModel.Id;
        }

        public async Task Confirm(ConfirmAdvertModel model)
        {
            using (var client = new AmazonDynamoDBClient())
            {
                using(var context = new DynamoDBContext(client))
                {
                    var record = await context.LoadAsync<AdvertDbModel>(model.Id);

                    if(record == null)
                        throw new KeyNotFoundException($"A record with ID={model.Id} was not found.");
                  
                    record.Status = AdvertStatus.Active;
                    await context.SaveAsync(record);   
                }
            }
        }

        public async Task Delete(ConfirmAdvertModel model)
        {
            using (var client = new AmazonDynamoDBClient())
            {
                using(var context = new DynamoDBContext(client))
                {
                    var record = await context.LoadAsync<AdvertDbModel>(model.Id);
                    await context.DeleteAsync(record);
                }
            }
        }
    }
}