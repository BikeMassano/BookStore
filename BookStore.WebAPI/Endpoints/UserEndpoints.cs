using BookStore.App.Interfaces.Services;
using BookStore.WebAPI.Contracts;

namespace BookStore.WebAPI.Endpoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("register", Register);
            app.MapPost("login", Login);
            return app;
        }

        private static async Task<IResult> Register(
            UserRegistrationRequest request,
            IUserService userService)
        {
            await userService.Register(request.UserName, request.Password, request.Adress, request.PhoneNumber, request.Email);

            return Results.Ok();
        }

        private static async Task<IResult> Login(
            UserLoginRequest request,
            IUserService userService,
            HttpContext context)
        {
            var token = await userService.Login(request.UserName, request.Password);

            context.Response.Cookies.Append("SuperCookies", token);

            return Results.Ok(token);
        }
    }
}
