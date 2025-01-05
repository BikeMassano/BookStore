using BookStore.Infrastructure;
using BookStore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructureServices();
builder.AddServices();
var app = builder.Build();

if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/home/error");
}

app.UseWelcomePage("/");

app.Run();
