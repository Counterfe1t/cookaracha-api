using Cookaracha.Application;
using Cookaracha.Core;
using Cookaracha.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddCore()
    .AddApplication()
    .AddControllers();

var app = builder.Build();
app.UseInfrastructure();
app.Run();