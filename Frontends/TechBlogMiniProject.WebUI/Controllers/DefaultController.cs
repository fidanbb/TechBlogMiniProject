﻿using Microsoft.AspNetCore.Mvc;

namespace TechBlogMiniProject.WebUI.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
