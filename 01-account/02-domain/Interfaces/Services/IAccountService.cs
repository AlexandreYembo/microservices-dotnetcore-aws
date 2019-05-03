using System.Threading.Tasks;
using domain.Models;

namespace domain.Interfaces.Services
{
    public interface IAccountService
    {
         Task<AccountResult> SignUp(SignUp entity);
         Task<AccountResult> Confirm(Confirm entity);
         Task<AccountResult> Login(Login entity);
    }
}