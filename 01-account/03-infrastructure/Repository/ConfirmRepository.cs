using System.Threading.Tasks;
using Amazon.Extensions.CognitoAuthentication;
using domain.Models;
using domain.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;
using System.Net;
using infrastructure.Interfaces;
using Amazon.AspNetCore.Identity.Cognito;

namespace infrastructure.Repository
{
    public class ConfirmRepository : IConfirmRepository
    {
        private readonly UserManager<CognitoUser> _userManager;
        private readonly CognitoUserPool _pool;
        private readonly IIdentityResultMap _resultMap;
        public ConfirmRepository(UserManager<CognitoUser> userManager, CognitoUserPool pool, IIdentityResultMap resultMap)
        {
            _userManager = userManager;
            _pool = pool;
            _resultMap = resultMap;
        }

        public async Task<AccountResult> Confirm(Confirm entity)
        {
            CognitoUser user = await _userManager.FindByEmailAsync(entity.Email).ConfigureAwait(false);
            return user == null ? AddError() : _resultMap.Map(await ((CognitoUserManager<CognitoUser>) _userManager).ConfirmSignUpAsync(user, entity.Code, true).ConfigureAwait(false));
        }

        private AccountResult AddError() => 
            new AccountResult
                {
                    Succeeded = false,
                    Errors = new List<ErrorsResult>{ new ErrorsResult(HttpStatusCode.NotFound, "User not found")}
                };
    }
}