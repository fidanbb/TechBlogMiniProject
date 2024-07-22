using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechBlogMiniProject.Application.Features.Mediatr.Commands.ArticleCommands;
using TechBlogMiniProject.Application.Features.Mediatr.Queries.ArticleQueries;
using TechBlogMiniProject.Application.Features.Mediatr.Queries.CategoryQueries;

namespace TechBlogMiniProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]

        public async Task<IActionResult> CategoryList()
        {
            var values = await _mediator.Send(new GetAllArticlesQuery());
            return Ok(values);
        }

        [HttpGet("GetRecent4Articles")]

        public async Task<IActionResult> GetRecent4Articles()
        {
            var values = await _mediator.Send(new GetRecent4ArticlesQuery());
            return Ok(values);
        }

        [HttpGet("GetArticleById/{id}")]

        public async Task<IActionResult> GetArticleById(int id)
        {
            var values = await _mediator.Send(new GetArticleByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("GetArticlesByUserId/{userId}")]

        public async Task<IActionResult> GetArticlesByUserId(string userId)
        {
            var values = await _mediator.Send(new GetArticlesByUserIdQuery(userId));
            return Ok(values);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> RemoveArticle(int id)
        {
           await _mediator.Send(new RemoveArticleCommand(id));
           return Ok("Article removed Successfully");
        }

        [HttpPost]

        public async Task<IActionResult> CreateArticle(CreateArticleCommand command)
        {
            await _mediator.Send(command);
            return Ok("Article created Successfully");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateArticle(UpdateArticleCommand command)
        {
            await _mediator.Send(command);
            return Ok("Article updated Successfully");
        }
    }
}
