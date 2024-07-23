using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text;
using TechBlogMiniProject.Dtos.ArticleDtos;
using TechBlogMiniProject.Dtos.CategoryDtos;
using TechBlogMiniProject.WebUI.Models;

namespace TechBlogMiniProject.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public ArticleController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Articles";
            ViewBag.v2 = "Tech Articles";
            //var client = _httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var client = _httpClientFactory.CreateClient("ApiClient");
            var responseMessage = await client.GetAsync("Articles");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<GetAllArticlesDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        public IActionResult ArticleDetail(int id)
        {
            ViewBag.v1 = "Article";
            ViewBag.v2 = "Article Detail";
            ViewBag.articleId = id;
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UsersArticles(string userId)
        {
            ViewBag.v1 = "Articles";
            ViewBag.v2 = "Your Articles";
            var token = User.Claims.FirstOrDefault(x => x.Type == "techblogtoken")?.Value;

            if(token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                userId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;

                //var client = _httpClientFactory.CreateClient();
                //client.BaseAddress = new Uri(_apiSettings.BaseUrl);
                var client = _httpClientFactory.CreateClient("ApiClient");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.GetAsync($"Articles/GetArticlesByUserId/{userId}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();

                    var values = JsonConvert.DeserializeObject<List<GetAllArticlesDto>>(jsonData);

                    return View(values);
                }
            }

          

            return View();
        }

        [Authorize]
        [HttpGet]

        public async Task<IActionResult> AddArticle()
        {
            ViewBag.v1 = "Article";
            ViewBag.v2 = "Post Your Article";

            var token = User.Claims.FirstOrDefault(x => x.Type == "techblogtoken")?.Value;
            if (token != null) {
				var handler = new JwtSecurityTokenHandler();
				var jwtToken = handler.ReadJwtToken(token);
				var userId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
                ViewBag.userId = userId;
                //var client = _httpClientFactory.CreateClient();
                //            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
                var client = _httpClientFactory.CreateClient("ApiClient");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.GetAsync($"Categories");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();

                    var values = JsonConvert.DeserializeObject<List<GetAllCategoriesDto>>(jsonData);

                    List<SelectListItem> values2 = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.CategoryID.ToString()
                                                    }).ToList();
                    ViewBag.Categories = values2;
                }
            }
            return View();
        }

        [Authorize]
        [HttpPost]

		public async Task<IActionResult> AddArticle(CreateArticleDto createArticleDto)
		{
			var token = User.Claims.FirstOrDefault(x => x.Type == "techblogtoken")?.Value;
			var handler = new JwtSecurityTokenHandler();
			var jwtToken = handler.ReadJwtToken(token);
			var userId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
			ViewBag.userId = userId;

            //var client = _httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var client = _httpClientFactory.CreateClient("ApiClient");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			var responseMessage1 = await client.GetAsync($"Categories");

			if (responseMessage1.IsSuccessStatusCode)
			{
				var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();

				var values = JsonConvert.DeserializeObject<List<GetAllCategoriesDto>>(jsonData1);

				List<SelectListItem> values2 = (from x in values
												select new SelectListItem
												{
													Text = x.Name,
													Value = x.CategoryID.ToString()
												}).ToList();
				ViewBag.Categories = values2;
			}

			if (!ModelState.IsValid)
            {
                return View();
            }

			
			if (token != null)
            {
               
				var jsonData = JsonConvert.SerializeObject(createArticleDto);
				StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
				var responseMessage = await client.PostAsync("Articles", stringContent);
				if (responseMessage.IsSuccessStatusCode)
				{
					TempData["SuccessMessage"] = "Your article was created successfully!";
				}
                else
                {
					TempData["ErrorMessage"] = "Something went wrong. Please try again.";
				}
			}
			return RedirectToAction(nameof(AddArticle));
		}

		[Authorize]
		[HttpGet]

		public async Task<IActionResult> EditArticle(int id)
		{
			ViewBag.v1 = "Article";
			ViewBag.v2 = "Edit Your Article";

			var token = User.Claims.FirstOrDefault(x => x.Type == "techblogtoken")?.Value;
			if (token != null)
			{
				var handler = new JwtSecurityTokenHandler();
				var jwtToken = handler.ReadJwtToken(token);
				var userId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
				ViewBag.userId = userId;
                //var client = _httpClientFactory.CreateClient();
                //client.BaseAddress = new Uri(_apiSettings.BaseUrl);
                var client = _httpClientFactory.CreateClient("ApiClient");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
				var responseMessage = await client.GetAsync($"Categories");
                var responseMessage2 = await client.GetAsync($"Articles/GetArticleById/{id}");
				if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
				{
					var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var jsonData2=await responseMessage2.Content.ReadAsStringAsync();

					var values = JsonConvert.DeserializeObject<List<GetAllCategoriesDto>>(jsonData);
                    var values2 = JsonConvert.DeserializeObject<UpdateArticleDto>(jsonData2);

					List<SelectListItem> categories = (from x in values
													select new SelectListItem
													{
														Text = x.Name,
														Value = x.CategoryID.ToString()
													}).ToList();
					ViewBag.Categories = categories;
                    return View(values2);
				}
			}
			return View();
		}


		[Authorize]
		[HttpPost]

		public async Task<IActionResult> EditArticle(UpdateArticleDto updateArticleDto)
		{
			var token = User.Claims.FirstOrDefault(x => x.Type == "techblogtoken")?.Value;
			var handler = new JwtSecurityTokenHandler();
			var jwtToken = handler.ReadJwtToken(token);
			var userId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
			ViewBag.userId = userId;

            //var client = _httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var client = _httpClientFactory.CreateClient("ApiClient");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			var responseMessage1 = await client.GetAsync($"Categories");

			if (responseMessage1.IsSuccessStatusCode)
			{
				var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();

				var values = JsonConvert.DeserializeObject<List<GetAllCategoriesDto>>(jsonData1);

				List<SelectListItem> values2 = (from x in values
												select new SelectListItem
												{
													Text = x.Name,
													Value = x.CategoryID.ToString()
												}).ToList();
				ViewBag.Categories = values2;
			}

			if (!ModelState.IsValid)
			{
				return View();
			}


			if (token != null)
			{


				var jsonData = JsonConvert.SerializeObject(updateArticleDto);
				StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
				var responseMessage = await client.PutAsync("Articles", stringContent);
				if (!responseMessage.IsSuccessStatusCode)
				{
					TempData["ErrorMessage"] = "Something went wrong. Please try again.";

				}

				return RedirectToAction("UsersArticles");
			}
			return RedirectToAction(nameof(EditArticle));
		}

		[Authorize]
		public async Task<IActionResult> DeleteArticle(int id)
		{
			var token = User.Claims.FirstOrDefault(x => x.Type == "techblogtoken")?.Value;
			if(token is not null)
			{
                //var client = _httpClientFactory.CreateClient();
                //client.BaseAddress = new Uri(_apiSettings.BaseUrl);
                var client = _httpClientFactory.CreateClient("ApiClient");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
				var responseMessage = await client.DeleteAsync($"Articles/{id}");

				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("UsersArticles");
				}
			}

			return View();
			
		}


	}
}
