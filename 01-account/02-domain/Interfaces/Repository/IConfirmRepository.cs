using System.Threading.Tasks;
using domain.Models;

namespace domain.Interfaces.Repository
{
    public interface IConfirmRepository<T>
    {
         Task<T> Confirm(Confirm entity);
    }
}