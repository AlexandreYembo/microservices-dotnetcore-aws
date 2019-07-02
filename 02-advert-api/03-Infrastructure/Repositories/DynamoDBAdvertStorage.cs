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
            
            await Run(async(DynamoDBContext context) =>{
                await context.SaveAsync(dbModel);
            });
            return dbModel.Id;
        }
       public async Task Confirm(ConfirmAdvertModel model) =>
            await Run(async (DynamoDBContext context) => {
                    var record = await context.LoadAsync<AdvertDbModel>(model.Id);

                    if(record == null)
                        throw new KeyNotFoundException($"A record with ID={model.Id} was not found.");
                  
                    record.Status = AdvertStatus.Active;
                    await context.SaveAsync(record);  
            });

        public async Task Delete(ConfirmAdvertModel model) =>
            await Run(async (DynamoDBContext context) =>{
                 var record = await context.LoadAsync<AdvertDbModel>(model.Id);
                 await context.DeleteAsync(record);
            });
        
        private async Task Run(Func<DynamoDBContext, Task> function){
            try
            {
                using (var client = new AmazonDynamoDBClient())
                {
                    using(var context = new DynamoDBContext(client))
                    {
                        await function.Invoke(context);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CheckHealthAsync()
        {
            using (var client = new AmazonDynamoDBClient())
            {
                var tableData = await client.DescribeTableAsync("Advert");
                return string.Compare(tableData.Table.TableStatus, "active", true) == 0;
            }
        }
    }
}