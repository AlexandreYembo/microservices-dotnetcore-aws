using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Amazon.Extensions.CognitoAuthentication;
using domain.Interfaces.Repository;
using domain.Models;
using infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace infrastructure.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly SignInManager<CognitoUser> _signInManager;
        private readonly UserManager<CognitoUser> _userManager;
        private readonly IIdentityResultMap _resultMap;
        public LoginRepository(SignInManager<CognitoUser> signInManager, UserManager<CognitoUser> userManager, IIdentityResultMap resultMap)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _resultMap = resultMap;

        }

        public async Task<AccountResult> Login(Login entity) => 
            Map(await _signInManager.PasswordSignInAsync(entity.Username, entity.Password, entity.RememberMe, lockoutOnFailure: false)
                                       .ConfigureAwait(false));

        public async Task<AccountResult> ResetPassword(ResetPasword entity)
        {
            CognitoUser user = await _userManager.FindByEmailAsync(entity.Username).ConfigureAwait(false);
             return user == null ? AddError() : _resultMap.Map(await _userManager.ResetPasswordAsync(user, entity.Token, entity.NewPassword).ConfigureAwait(false));
        }

          public async Task<AccountResult> ForgotPassword(Login entity)
          {
            CognitoUser user = await _userManager.FindByEmailAsync(entity.Username).ConfigureAwait(false);
             return user == null ? AddError() : Map(await _userManager.GeneratePasswordResetTokenAsync(user).ConfigureAwait(false));
        }
         private AccountResult Map(SignInResult result) =>
            new AccountResult
                {
                    Succeeded = result.Succeeded,
                    IsLockedOut = result.IsLockedOut,
                    RequiresTwoFactor = result.RequiresTwoFactor,
                    IsNotAllowed = result.IsNotAllowed,
                };
            private AccountResult AddError() => 
            new AccountResult
                {
                    Succeeded = false,
                    Errors = new List<ErrorsResult>{ new ErrorsResult(HttpStatusCode.NotFound, "User not found")}
                };

        private AccountResult Map(string password) =>
            new AccountResult{
                Token = password,
                Succeeded = true,

            };
    }
}