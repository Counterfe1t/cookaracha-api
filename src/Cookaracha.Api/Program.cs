using Cookaracha.Api;
using Cookaracha.Application;
using Cookaracha.Core;
using Cookaracha.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplication()
    .AddCore()
    .AddInfrastructure(builder.Configuration)
    .AddControllers();

var app = builder.Build();
app.UseInfrastructure();
app.UseHome();
app.Run();