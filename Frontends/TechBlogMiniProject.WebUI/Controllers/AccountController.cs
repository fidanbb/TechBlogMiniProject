using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechBlogMiniProject.Dtos.AccountDtos;
using TechBlogMiniProject.WebUI.Models;
using System.Text.Json;
using System.Reflection;
using TechBlogMiniProject.WebUI.Helpers;


namespace TechBlogMiniProject.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public AccountController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.v1 = "Login";
            ViewBag.v2 = "Login Now";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
           

            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }


            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var content = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Users/SignIn", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if(tokenModel.Token is null)
                {
                    ModelState.AddModelError(string.Empty, "Login informations is wrong");
                    return View();
                }

                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();

                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("techblogtoken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Default");
                    }
                }
            }

            return View();
        }



        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.v1 = "Register";
            ViewBag.v2 = "Register Now";
            return View();
        }
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }
            if (!PasswordChecker.IsPasswordComplex(registerDto.Password))
            {
                ModelState.AddModelError("Password", "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.");
                return View(registerDto);
            }

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(registerDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("Users/SignUp", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public IActionResult Logout()
        {
            var isContains = Request.Cookies.ContainsKey("TechBlogJwt");
            if (isContains)
            {
                Response.Cookies.Delete("TechBlogJwt"); // Delete the JWT token cookie
            }

            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Default");
        }
    }
}
