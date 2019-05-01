using System.Threading.Tasks;
using domain.Interfaces.Repository;
using domain.Interfaces.Services;
using domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/account/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService<IdentityResult> _accountService;

        public AccountController(IAccountService<IdentityResult> accountService)
        {
            _accountService = accountService;
        }

        [HttpPost, Route("signup")]
        public async Task<IdentityResult> SignUp(SignUp entity)  => await _accountService.SignUp(entity);

        [HttpPost, Route("confirm")]
        public async Task<IdentityResult> Confirm(Confirm entity) => await _accountService.Confirm(entity);
    }
}