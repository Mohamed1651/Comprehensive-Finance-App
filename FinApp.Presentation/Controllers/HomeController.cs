using Microsoft.AspNetCore.Mvc;

namespace ShinyCollectorPlatform.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [HttpGet]
        [Route("/login")]
        public void Login()
        {
            //
        }
    }
}
