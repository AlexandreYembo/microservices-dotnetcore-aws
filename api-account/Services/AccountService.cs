using System.Threading.Tasks;
using Amazon.Extensions.CognitoAuthentication;
using api_account.Model;
using Microsoft.AspNetCore.Identity;

namespace api_account.Services
{
    /* This class implement the Pattern Fluent Builder */
    public class AccountService
    {
        protected CognitoUser _user;
        protected SignUp _model = new SignUp();
        private readonly SignInManager<CognitoUser> _signInManager;
        private readonly UserManager<CognitoUser> _userManager;
        private readonly CognitoUserPool _pool;
        public IdentityResult result;

        public AccountService(SignInManager<CognitoUser> signInManager, UserManager<CognitoUser> userManager, CognitoUserPool pool, SignUp model){
            _signInManager = signInManager;
            _userManager = userManager;
            _pool = pool;
            _model = model;
        }
        public async Task<AccountService> CreateUser(){
            if(_user == null)
            {
                // implement role class = User nullable, please Get the User First.
                return this;
            }

            if(_user.Status != null)
            {
                // implement role class // User Exist: User with this email already exists.
                return this;
            }

            result = await _userManager.CreateAsync(_user, _model.Password).ConfigureAwait(false);
            return this;
        }

        public AccountService GetUser(){
            _user = _pool.GetUser(_model.Email);
            return this;
        }


        #region Implicit Operatior
        public static implicit operator IdentityResult(AccountService builder) => builder.result;
        
        #endregion
    }
}