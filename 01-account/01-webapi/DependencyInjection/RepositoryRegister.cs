using domain.Interfaces.Repository;
using infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace webapi
{
   //Register dependency injection for Repository classes
    public class RepositoryRegister
    {
        public RepositoryRegister(IServiceCollection services){
            services.AddTransient<ISignUpRepository<IdentityResult>, SignUpRepository>();
            services.AddTransient<IConfirmRepository<IdentityResult>, ConfirmRepository>();
        }
    }
}