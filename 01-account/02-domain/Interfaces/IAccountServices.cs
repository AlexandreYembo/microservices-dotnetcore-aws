using System.Threading.Tasks;

namespace domain
{
    public interface IAccountServices
    {
         Task<IAccountServices> CreateUser();
         IAccountServices GetUser();
    }
}