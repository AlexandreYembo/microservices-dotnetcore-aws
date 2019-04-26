using System;
using System.Threading.Tasks;
using Amazon.Extensions.CognitoAuthentication;
using Microsoft.AspNetCore.Identity;
using domain.Interfaces.Repository;
using domain.Models;

namespace infrastructure.Repository
{
    public class SignUpRepository : ISignUpRepository<IdentityResult>
    {
        private readonly UserManager<CognitoUser> _userManager;
        private readonly CognitoUserPool _pool;
        

        public SignUpRepository(UserManager<CognitoUser> userManager, CognitoUserPool pool)
        {
            _userManager = userManager;
            _pool = pool;
        }

        public async Task<IdentityResult> SignUp(Login entity)
        {
            var user = _pool.GetUser(entity.Email);

            if(user.Status != null){
                // throw an validation exception
            }

            user.Attributes.Add("Name", "Alexandre");

            IdentityResult result = await _userManager.CreateAsync(user, entity.Password).ConfigureAwait(false);
            return result;
        }
    }
}