using System.Threading.Tasks;
using domain.Models;

namespace domain.Interfaces.Services
{
    public interface IAccountService
    {
         Task<IdentityResult> SignUp(Login entity);
         Task<IdentityResult> Confirm(Confirm entity);
    }
}