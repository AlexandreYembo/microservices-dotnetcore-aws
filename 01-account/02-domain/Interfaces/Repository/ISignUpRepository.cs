using System.Threading.Tasks;
using domain.Models;

namespace domain.Interfaces.Repository
{
    public interface ISignUpRepository<T>
    {
         Task<T> SignUp(SignUp entity);
    }
}