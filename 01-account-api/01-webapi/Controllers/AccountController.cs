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
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost, Route("signup")]
        public async Task<AccountResult> SignUp(SignUp entity) =>
            await _accountService.SignUp(entity);

        [HttpPost, Route("confirm")]
        public async Task<AccountResult> Confirm(Confirm entity) =>
            await _accountService.Confirm(entity);

        [HttpPost, Route("login")]
        public async Task<AccountResult> Login(Login entity) =>
            await _accountService.Login(entity);

        [HttpPost, Route("forgotPassword")]
        public async Task<AccountResult> ForgotPassword(Login entity) =>
            await _accountService.ForgotPassword(entity);
    }
}