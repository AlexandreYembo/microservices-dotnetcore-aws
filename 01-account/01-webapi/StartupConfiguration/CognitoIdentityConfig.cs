using Microsoft.Extensions.DependencyInjection;

namespace webapi
{
    /// <summary>
    /// Singleton of Cognito Identity configuration class
    /// </summary>
    public class CognitoIdentityConfig
    {
         private static CognitoIdentityConfig _instance;
        public static CognitoIdentityConfig New{
            get
            {
                lock(typeof(CognitoIdentityConfig)){
                    if(_instance == null){
                        _instance = new CognitoIdentityConfig();
                    }
                }
                
                return _instance;
            }
        }

    /// <summary>
    /// Configure de AWS Cognito SDK
    /// </summary>
    /// <param name="services"></param>        
    public void BasicConfiguration(IServiceCollection services) => 
        services.AddCognitoIdentity();

    /// <summary>
    /// Configure de AWS Cognito SDK
    /// </summary>
    /// <param name="services"></param>        
    public void Configure(IServiceCollection services) => 
        services.AddCognitoIdentity(config =>
        {
            config.Password = new Microsoft.AspNetCore.Identity.PasswordOptions
            {
                RequireDigit = false,
                RequiredLength = 6,
                RequiredUniqueChars = 0,
                RequireLowercase = false,
                RequireNonAlphanumeric = false,
                RequireUppercase = false
            };
        });
    }
}