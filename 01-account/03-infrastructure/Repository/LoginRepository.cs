using System.Threading.Tasks;
using Amazon.Extensions.CognitoAuthentication;
using domain.Interfaces.Repository;
using domain.Models;
using Microsoft.AspNetCore.Identity;

namespace infrastructure.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly SignInManager<CognitoUser> _signInManager;    
        public LoginRepository(SignInManager<CognitoUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<AccountResult> Login(Login entity) => 
            Map(await _signInManager.PasswordSignInAsync(entity.Username, entity.Password, entity.RememberMe, lockoutOnFailure: false)
                                       .ConfigureAwait(false));

         private AccountResult Map(SignInResult result) =>
            new AccountResult
                {
                    Succeeded = result.Succeeded,
                    IsLockedOut = result.IsLockedOut,
                    RequiresTwoFactor = result.RequiresTwoFactor,
                    IsNotAllowed = result.IsNotAllowed,
                };
    }
}