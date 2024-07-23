using Microsoft.AspNetCore.Mvc;

namespace TechBlogMiniProject.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Contact";
            ViewBag.v2 = "Contact Us";
            return View();
        }
    }
}
