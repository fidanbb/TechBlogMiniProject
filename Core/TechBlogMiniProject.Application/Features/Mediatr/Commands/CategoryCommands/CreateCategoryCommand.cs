using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogMiniProject.Application.Features.Mediatr.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest
    {
        public string Name { get; set; }
    }
}
