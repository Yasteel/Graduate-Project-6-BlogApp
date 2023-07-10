using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using StolenBlog.API.Configurations;
using StolenBlog.API.Data;
using StolenBlog.API.Interfaces;
using StolenBlog.API.Services;
using StolenBlog.API.Validators;
using StolenBlog.Models.BlogModels;
using StolenBlog.Models.DTOs;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig")); // allows us to use in Dependancy Injection

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // For api endpoint Headers - Bearer ...
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; // fallback
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwt =>
{
	var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);

	jwt.SaveToken = true;
	jwt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(key),
		ValidateIssuer = false,
		ValidateAudience = false,
		RequireExpirationTime = false,
		ValidateLifetime = true
	};
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
	.AddEntityFrameworkStores<AppDbContext>();




builder.Services.AddScoped<IBlogPostsService, BlogPostsService>();
builder.Services.AddScoped<IBlogsService, BlogsService>();
builder.Services.AddScoped<ICommentsService, CommentsService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IValidator<BlogPosts>, BlogPostValidator>();
builder.Services.AddScoped<IValidator<Blogs>, BlogValidator>();
builder.Services.AddScoped<IValidator<RegistrationRequestDto>, RegisterValidator>();


builder.Services.AddScoped<ICacheService, CacheService>();

builder.Services.AddStackExchangeRedisCache(options =>
{
	options.ConfigurationOptions = new()
	{
		EndPoints = { { "localhost:5002" } },
		AllowAdmin = true,
		ConnectTimeout = 500

	};
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
