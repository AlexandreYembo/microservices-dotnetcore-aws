using domain.Interfaces.Repository;
using infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace webapi
{
   //Register dependency injection for Repository classes
    public class RepositoriesRegister
    {
        public RepositoriesRegister(IServiceCollection services){
            services.AddTransient<ISignUpRepository, SignUpRepository>();
            services.AddTransient<IConfirmRepository, ConfirmRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            MappingRegister.Instance.Register(services);
        }
    }
}