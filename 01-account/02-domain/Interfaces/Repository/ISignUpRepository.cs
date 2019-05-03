using System.Threading.Tasks;
using domain.Models;

namespace domain.Interfaces.Repository
{
    public interface ISignUpRepository
    {
        Task<AccountResult> SignUp(SignUp entity);
    }
}