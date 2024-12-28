using BookStore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructureServices();
var app = builder.Build();

if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/home/error");
}
app.UseWelcomePage("/");

app.Run();
