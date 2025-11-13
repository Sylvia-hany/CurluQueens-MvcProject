using Microsoft.AspNetCore.Mvc;

namespace CurlyQueens.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View("Aboutpage");
        }
    }
}
