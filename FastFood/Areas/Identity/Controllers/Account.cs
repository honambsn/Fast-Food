using Microsoft.AspNetCore.Mvc;

namespace FastFood.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Route("Identity")]
    [Route("Identity/Account")]
    public class Account : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("access")]
        [HttpGet]
        public IActionResult LoginOrRegister()
        {
            return View();
        }

        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [Route("register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

    }
}
