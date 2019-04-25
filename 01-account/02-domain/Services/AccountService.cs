using System.Threading.Tasks;
using domain.Interfaces.Repository;
using domain.Interfaces.Services;
using domain.Models;


namespace domain.Services
{
    public class AccountService : IAccountService
    {
        protected readonly ISignUpRepository  _signUpRepository;
        protected readonly IConfirmRepository  _confirmRepository;
        public AccountService(ISignUpRepository  signUpRepository, IConfirmRepository confirmRepository)
        {
            _signUpRepository = signUpRepository;
            _confirmRepository = confirmRepository;
        }
        public Task<IdentityResult> Confirm(Confirm entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> SignUp(Login entity)
        {
            _signUpRepository.SignUp(entity);
        }
    }
}