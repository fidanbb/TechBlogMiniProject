using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TechBlogMiniProject.Dtos.ArticleDtos;
using TechBlogMiniProject.WebUI.Models;

namespace TechBlogMiniProject.WebUI.ViewComponents.ArticleViewComponents
{
    public class _ArticleDetailComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public _ArticleDetailComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.articleId = id;
            //var client = _httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var client = _httpClientFactory.CreateClient("ApiClient");
          
            var responseMessage = await client.GetAsync($"Articles/GetArticleById/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<GetArticleByIdDto>(jsonData);

                return View(value);
            }

            return View();
        }
    }
}
