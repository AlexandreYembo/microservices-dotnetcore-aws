using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
{
    public class ServicesRegister : RepositoryRegister
    {
        public ServicesRegister(IServiceCollection services) : base(services)
        {
            services.AddTransient<IAdvertsService, AdvertsService>();
        }
    }
}