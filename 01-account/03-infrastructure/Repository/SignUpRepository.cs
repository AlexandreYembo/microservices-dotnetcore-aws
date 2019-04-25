using System;
using System.Threading.Tasks;
using Amazon.Extensions.CognitoAuthentication;
using Microsoft.AspNetCore.Identity;
using domain.Interfaces.Repository;
using domain.Models;

namespace infrastructure.Repository
{
    public class SignUpRepository : ISignUpRepository
    {
        private readonly UserManager<CognitoUser> _userManager;
        private readonly CognitoUserPool _pool;
        
        private IdentityResult result {get; set; }

        public SignUpRepository(UserManager<CognitoUser> userManager, CognitoUserPool pool)
        {
            _userManager = userManager;
            _pool = pool;
        }

        public async Task<ISignUpRepository> SignUp(Login entity)
        {
            var user = _pool.GetUser(entity.Email);

            if(user.Status != null){
                // throw an validation exception
            }

            user.Attributes.Add("Name", "Alexandre");

            result = await _userManager.CreateAsync(user, entity.Password).ConfigureAwait(false);
            return this;
        }

        public static implicit operator IdentityResult(SignUpRepository service) => service.result;
    }
}