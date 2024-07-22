using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogMiniProject.Application.Dtos.User;
using TechBlogMiniProject.Application.Helpers.Responses;

namespace TechBlogMiniProject.Application.Services.Token
{
    public interface ITokenService
	{
        JwtTokenResponse GenerateJwtToken(CheckAppUserDto result);

	}
}
