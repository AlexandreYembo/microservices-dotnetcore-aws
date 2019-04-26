using System.Threading.Tasks;
using domain.Interfaces.Repository;
using domain.Interfaces.Services;
using domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService<IdentityResult> _accountService;

        public AccountController(IAccountService<IdentityResult> accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IdentityResult> SignUp(Login entity) => await _accountService.SignUp(entity);
    }
}