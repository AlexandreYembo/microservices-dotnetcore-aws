using System.Threading.Tasks;
using Amazon.Extensions.CognitoAuthentication;
using domain.Models;
using domain.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;

namespace infrastructure.Repository
{
    public class ConfirmRepository : IConfirmRepository<IdentityResult>
    {
        private readonly UserManager<CognitoUser> _userManager;
        private readonly CognitoUserPool _pool;
        public ConfirmRepository(UserManager<CognitoUser> userManager, CognitoUserPool pool)
        {
            _userManager = userManager;
            _pool = pool;
        }
        public async Task<IdentityResult> Confirm(Confirm entity)
        {
            var user = await _userManager.FindByEmailAsync(entity.Email).ConfigureAwait(false);

            if(user == null){
                // throw an validation exception
            }

            return await _userManager.ConfirmEmailAsync(user, entity.Code).ConfigureAwait(false);
        }
    }
}