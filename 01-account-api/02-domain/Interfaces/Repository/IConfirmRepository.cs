using System.Threading.Tasks;
using domain.Models;

namespace domain.Interfaces.Repository
{
    public interface IConfirmRepository
    {
        Task<AccountResult> Confirm(Confirm entity);
    }
}