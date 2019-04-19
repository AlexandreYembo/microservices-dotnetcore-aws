using domain;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices _accountServices;

        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }
    }
}