
using Microsoft.Extensions.DependencyInjection;

namespace webapi
{
    /// <summary>
    /// Singleton of Authorize configuration class
    /// Configuration used on startup.cs for [Authorization] attribute used on Controllers
    /// </summary>
    public class AuthorizeConfig
    {
        private static AuthorizeConfig _instance;
        public static AuthorizeConfig New{
            get
            {
                lock(typeof(AuthorizeConfig)){
                    if(_instance == null){
                        _instance = new AuthorizeConfig();
                    }
                }
                
                return _instance;
            }
        }
    public void Configure(IServiceCollection services) =>
        services.ConfigureApplicationCookie(options => {
            options.LoginPath = "/api/account/login";
        });
    }
}