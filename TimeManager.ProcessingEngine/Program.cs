using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;
using Serilog;
using TimeManager.ProcessingEngine.Data;
using TimeManager.ProcessingEngine.Data.Services;
using TimeManager.ProcessingEngine.Services;
using TimeManager.ProcessingEngine.Services.container;
using TimeManager.ProcessingEngine.Services.MessageBroker;
using Grpc;
using Grpc.AspNetCore;
using TimeManager.ProcessingEngine.Protos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.Seq("http://seq:5341")
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();

builder.Services.AddSingleton<DataContext>(s => new DataContext(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IProcessors, Processors>();
builder.Services.AddSingleton<IPooledObjectPolicy<IModel>, MQModelPooledObjectPolicy>();

builder.Services.AddHostedService<MQManager>();



var app = builder.Build();

DatabaseManagerService.MigrationInitialization(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapGrpcService<GreeterService>();

app.Run();
