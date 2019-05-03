using System;
using System.Threading.Tasks;
using Amazon.Extensions.CognitoAuthentication;
using Microsoft.AspNetCore.Identity;
using domain.Interfaces.Repository;
using domain.Models;
using Amazon.AspNetCore.Identity.Cognito;
using System.Collections.Generic;
using System.Net;
using infrastructure.Interfaces;

namespace infrastructure.Repository
{
    public class SignUpRepository : ISignUpRepository
    {
        private readonly UserManager<CognitoUser> _userManager;
        private readonly CognitoUserPool _pool;

        private readonly IIdentityResultMap _resultMap;
        public SignUpRepository(UserManager<CognitoUser> userManager, CognitoUserPool pool, IIdentityResultMap resultMap)
        {
            _userManager = userManager;
            _pool = pool;
            _resultMap = resultMap;
        }

        public async Task<AccountResult> SignUp(SignUp entity)
        {
            var user = _pool.GetUser(entity.Email);

            if(user.Status != null)
              return new AccountResult
                {
                    Succeeded = false,
                    Errors = new List<ErrorsResult>{ new ErrorsResult(HttpStatusCode.NotFound, "Invalid status")}
                };

            user.Attributes.Add(CognitoAttribute.Name.AttributeName, entity.Name);

            return _resultMap.Map(await _userManager.CreateAsync(user, entity.Password).ConfigureAwait(false));
        }
    }
}