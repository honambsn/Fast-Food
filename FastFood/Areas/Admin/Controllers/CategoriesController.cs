using Microsoft.AspNetCore.Mvc;

namespace FastFood.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
