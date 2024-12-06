using Cookaracha.Application;
using Cookaracha.Core;
using Cookaracha.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplication()
    .AddCore()
    .AddInfrastructure()
    .AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();