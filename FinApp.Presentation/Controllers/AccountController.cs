using FinApp.Application.Interfaces;
using FinApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(IAccountService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Account>> Get()
        //{
        //    //var userId = _userService.GetCurrentUser(HttpContext);
        //    //var accounts = _accountService.GetAccountsByUser(userId);
        //    //return Ok(accounts);
        //}
    }
}
