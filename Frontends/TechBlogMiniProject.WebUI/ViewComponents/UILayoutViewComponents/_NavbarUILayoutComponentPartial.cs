using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TechBlogMiniProject.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public _NavbarUILayoutComponentPartial(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }

        public IViewComponentResult Invoke()
        {
            var token = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "techblogtoken")?.Value;

            if (token is not null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var fullNameClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "NameSurname");
                var fullName = fullNameClaim?.Value;

                var userId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;

                ViewBag.FullName = fullName;
                ViewBag.UserId = userId;
                ViewBag.Token=token;
            }

            return View();
        }
    }
}
