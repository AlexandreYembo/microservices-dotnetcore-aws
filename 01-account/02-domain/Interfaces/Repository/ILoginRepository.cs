using System.Threading.Tasks;
using domain.Models;

namespace domain.Interfaces.Repository
{
    public interface ILoginRepository
    {
         Task<AccountResult> Login(Login entity);
         Task<AccountResult> ResetPassword(ResetPasword entity);
         Task<AccountResult> ForgotPassword(Login entity);
    }
}