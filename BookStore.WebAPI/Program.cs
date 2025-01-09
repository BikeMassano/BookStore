using BookStore.App.Interfaces.Services;
using BookStore.Infrastructure;
using BookStore.Infrastructure.Services;
using BookStore.WebAPI.Extensions;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructureServices();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/home/error");
}

app.UseHttpsRedirection();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

string token;
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userService = services.GetRequiredService<IUserService>();
    //await userService.Register("Иванов Иван Иваныч", "1234", "Ул. Пушкина д. Колотушкина", "8(800)555-35-35", "dasdasasd@urmail.su");
    //token = await userService.Login("Иванов Иван Иваныч", "1234");
}

app.UseAuthentication();
//app.MapGet("/", () => token);

app.Run();
