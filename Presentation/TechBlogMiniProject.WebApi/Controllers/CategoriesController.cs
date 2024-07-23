using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechBlogMiniProject.Application.Features.Mediatr.Commands.CategoryCommands;
using TechBlogMiniProject.Application.Features.Mediatr.Queries.CategoryQueries;

namespace TechBlogMiniProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CategoriesController(IMediator mediator)
		{
			_mediator = mediator;
		}
		

		[HttpGet]

		public async Task<IActionResult> CategoryList()
		{
			var values = await _mediator.Send(new GetAllCategoryQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> GetCategoryById(int id)
		{
			var value = await _mediator.Send(new GetCategoryByIdQuey(id));
			return Ok(value);
		}

		//[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
		[HttpDelete("{id}")]

		public async Task<IActionResult> RemoveCategory(int id)
		{
			 await _mediator.Send(new RemoveCategoryCommand(id));
			return Ok("Category Removed successfully");
		}

		//[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]

		[HttpPost]

		public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
		{
			await _mediator.Send(command);
			return Ok("Category Added successfully");
		}

		//[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]

		[HttpPut]

		public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
		{
			await _mediator.Send(command);
			return Ok("Category Updated Successfully");
		}
	}
}
