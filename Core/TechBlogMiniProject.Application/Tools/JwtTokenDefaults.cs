﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogMiniProject.Application.Tools
{
	public class JwtTokenDefaults
	{
		//public const string ValidAudience = "https://localhost";
        public const string ValidAudience = "http://fidanfidanfidan-001-site1.ktempurl.com/";
        public const string ValidIssuer = "http://fidanfidan-001-site1.atempurl.com";
		//public const string ValidIssuer = "https://localhost";
		public const string Key = "TechBlogMiniProject+*010203CTECHBLOG01+*..020304TechBlogMiniProject";
		public const int Expire = 5;
	}
}
