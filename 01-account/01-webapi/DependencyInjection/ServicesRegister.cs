using domain.Interfaces.Services;
using domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace webapi
{
    //Register dependency injection for Services classes
    public class ServicesRegister : RepositoryRegister
    {
        public ServicesRegister(IServiceCollection services) : base(services)
        {
            services.AddTransient<IAccountService<IdentityResult>, AccountService<IdentityResult>>();
        }
    }
}