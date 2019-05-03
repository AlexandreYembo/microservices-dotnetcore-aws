using infrastructure.Interfaces;
using infrastructure.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace webapi
{
    /// <summary>
    /// Define a singleton class for Mapping register.
    /// </summary>
    public class MappingRegister
    {
        private static MappingRegister _instance = null;
        public static MappingRegister Instance{
            get
            {
                lock(typeof(MappingRegister))
                {
                    if(_instance == null)
                    _instance = new MappingRegister();
                }

                return _instance;
            }
        }

        public void Register(IServiceCollection services)
        {
            services.AddTransient<IIdentityResultMap, IdentityResultMap>();
        }
    }
}