using Domain.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
{
    public class RepositoryRegister
    {
        public RepositoryRegister(IServiceCollection services)
        {
            services.AddTransient<IAdvertStorageRepository, DynamoDBAdvertStorage>();
        }
    }
}