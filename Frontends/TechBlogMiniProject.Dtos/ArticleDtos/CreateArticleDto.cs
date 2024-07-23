using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogMiniProject.Dtos.ArticleDtos
{
	public class CreateArticleDto
	{
		[Required(ErrorMessage = "Title is required.")]
		[MinLength(20, ErrorMessage = "The Title must be at least 20 characters long.")] 
		public string Title { get; set; }
		[Required]
		[MinLength(200, ErrorMessage = "The Content must be at least 200 characters long.")]

		public string Content { get; set; }
		[Required]
		public string ImageUrl { get; set; }
		[Required]
		public string AppUserId { get; set; }
		[Required]
		public int CategoryID { get; set; }
	}
}
