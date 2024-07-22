using Microsoft.AspNetCore.Mvc;

namespace TechBlogMiniProject.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
