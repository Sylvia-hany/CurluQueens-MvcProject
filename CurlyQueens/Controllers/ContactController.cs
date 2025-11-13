using Microsoft.AspNetCore.Mvc;

namespace CurlyQueens.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View("Contactpage");
        }
    }
}
