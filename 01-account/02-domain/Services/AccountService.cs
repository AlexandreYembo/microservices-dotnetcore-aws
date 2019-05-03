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

        protected readonly ILoginRepository _loginRepository;
        public AccountService(ISignUpRepository  signUpRepository, IConfirmRepository confirmRepository, ILoginRepository loginRepository)
        {
             _signUpRepository = signUpRepository;
             _confirmRepository = confirmRepository;
             _loginRepository = loginRepository;
        }
        
        public async Task<AccountResult> Confirm(Confirm entity) => 
            await _confirmRepository.Confirm(entity);

        public async Task<AccountResult> SignUp(SignUp entity) => 
            await _signUpRepository.SignUp(entity);

        public async Task<AccountResult> Login(Login entity) => 
            await _loginRepository.Login(entity);

    }
}