using System.Threading.Tasks;
using Amazon.Extensions.CognitoAuthentication;
using api_account.Model;
using api_account.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api_account.Controllers
{
    public class AccountController
    {
     
        /* Create instance to use Cognito Identity */
        private readonly SignInManager<CognitoUser> _signInManager;
        private readonly UserManager<CognitoUser> _userManager;
        private readonly CognitoUserPool _pool;

        /* Inject the dependencies by Constructor */
        public AccountController(SignInManager<CognitoUser> signInManager, UserManager<CognitoUser> userManager, CognitoUserPool pool)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _pool = pool;
        }

        [HttpPost]
        public async Task<IdentityResult> SignUp(SignUp model)
        {
            IdentityResult result = await new AccountService(_signInManager, _userManager, _pool, model)
                                                .GetUser()
                                                .CreateUser();
            return result;
        }

    }
}