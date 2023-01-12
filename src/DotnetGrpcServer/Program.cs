using DotnetGrpcServer.Servers;
using DotnetGrpcServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<CategoryServer>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();