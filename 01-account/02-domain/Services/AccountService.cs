using System.Threading.Tasks;
using domain.Interfaces.Repository;
using domain.Interfaces.Services;
using domain.Models;


namespace domain.Services
{
    public class AccountService<T> : IAccountService<T>
    {
        protected readonly ISignUpRepository<T>  _signUpRepository;
        protected readonly IConfirmRepository<T>  _confirmRepository;
        public AccountService(ISignUpRepository<T>  signUpRepository, IConfirmRepository<T> confirmRepository)
        {
             _signUpRepository = signUpRepository;
             _confirmRepository = confirmRepository;
        }
        public async Task<T> Confirm(Confirm entity)
        {
            return await _confirmRepository.Confirm(entity);
        }

        public async Task<T> SignUp(Login entity)
        {
           return await _signUpRepository.SignUp(entity);
        }
    }
}