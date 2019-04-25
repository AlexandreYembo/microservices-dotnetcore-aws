using domain;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAccountRespository _accountRepository;

        public AccountController(IAccountRespository accountRepository)
        {
            _accountRepository = accountRepository;
        }
    }
}