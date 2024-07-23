using TechBlogMiniProject.Application.Repositories;
using TechBlogMiniProject.Application.Repositories.CategoryRepositories;
using TechBlogMiniProject.Persistence.Context;
using TechBlogMiniProject.Persistence.Repositories;
using TechBlogMiniProject.Persistence.Repositories.CategoryRepositories;
using TechBlogMiniProject.Application;
using Microsoft.AspNetCore.Identity;
using System;
using TechBlogMiniProject.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TechBlogMiniProject.Application.Tools;
using TechBlogMiniProject.Application.Services.User;
using TechBlogMiniProject.Persistence.Services.User;
using TechBlogMiniProject.Application.Services.Token;
using TechBlogMiniProject.Persistence.Services.Token;
using TechBlogMiniProject.WebApi.Injections;
using TechBlogMiniProject.Application.Repositories.ArticleRepositories;
using TechBlogMiniProject.Persistence.Repositories.ArticleRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
	opt.RequireHttpsMetadata = false;
	opt.TokenValidationParameters = new TokenValidationParameters
	{
		ValidAudience = JwtTokenDefaults.ValidAudience,
		ValidIssuer = JwtTokenDefaults.ValidIssuer,
		ClockSkew = TimeSpan.Zero,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true

	};
});

builder.Services.AddDbContext<TechBlogContext>();

builder.Services.AddIdentity<AppUser, IdentityRole>()
				.AddEntityFrameworkStores<TechBlogContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
	options.Password.RequireNonAlphanumeric = true;
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireUppercase = true;
	options.Password.RequiredLength = 6;

	options.User.RequireUniqueEmail = true;

	options.SignIn.RequireConfirmedEmail = true;

	//default lockout settings

	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
	options.Lockout.MaxFailedAccessAttempts = 5;
	options.Lockout.AllowedForNewUsers = true;
});


builder.Services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
builder.Services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

builder.Services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
builder.Services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
builder.Services.AddScoped<IArticleReadRepository, ArticleReadRepository>();
builder.Services.AddScoped<IArticleWriteRepository, ArticleWriteRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddApplicationService(builder.Configuration);




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwagger();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
