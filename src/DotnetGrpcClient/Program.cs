using DotnetGrpcClient.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddGrpcClient<GrpcProtos.Category.CategoryService.CategoryServiceClient>(factoryOptions =>
{
    factoryOptions.Address = new Uri("http://localhost:9090");
    factoryOptions.ChannelOptionsActions.Add(channelOptions =>
    {
        channelOptions.HttpHandler = new SocketsHttpHandler
        {
            EnableMultipleHttp2Connections = true
        };
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();