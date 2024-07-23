using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TechBlogMiniProject.Dtos.ArticleDtos;
using TechBlogMiniProject.WebUI.Models;

namespace TechBlogMiniProject.WebUI.ViewComponents.ArticleViewComponents
{
    public class _ArticleRecent4ArticlesComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public _ArticleRecent4ArticlesComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Articles/GetRecent4Articles");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<GetLast4ArticlesDtos>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
