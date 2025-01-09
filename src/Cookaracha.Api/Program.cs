using Cookaracha.Api;
using Cookaracha.Application;
using Cookaracha.Core;
using Cookaracha.Infrastructure;
using Cookaracha.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.UseSerilog();
builder.Services
    .AddApplication()
    .AddCore()
    .AddInfrastructure(builder.Configuration)
    .AddControllers();

var app = builder.Build();
app.UseInfrastructure();
app.MapHomeEndpoint();
app.Run();