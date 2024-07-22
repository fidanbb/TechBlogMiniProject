using Microsoft.AspNetCore.Mvc;

namespace TechBlogMiniProject.WebUI.Controllers
{
	public class UILayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
