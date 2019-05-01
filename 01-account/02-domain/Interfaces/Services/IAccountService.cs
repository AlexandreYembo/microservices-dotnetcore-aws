using System.Threading.Tasks;
using domain.Models;

namespace domain.Interfaces.Services
{
    public interface IAccountService<T>
    {
         Task<T> SignUp(SignUp entity);
         Task<T> Confirm(Confirm entity);
    }
}