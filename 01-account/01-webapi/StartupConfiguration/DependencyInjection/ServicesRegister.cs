using domain.Interfaces.Services;
using domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace webapi
{
    //Register dependency injection for Services classes
    public class ServicesRegister : RepositoriesRegister
    {
        public ServicesRegister(IServiceCollection services) : base(services)
        {
            services.AddTransient<IAccountService, AccountService>();
        }
    }
}