using Microsoft.EntityFrameworkCore;
using Serilog;
using TimeManager.ProcessingEngine.Data;
using TimeManager.ProcessingEngine.Data.Services;
using TimeManager.ProcessingEngine.Services;
using TimeManager.ProcessingEngine.Services.MessageBroker;

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

builder.Services.AddSingleton<DataContext>(s => new DataContext(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IActivitySetProcessors, ActivitySetProcessors>();

var mqManager = new MQManager(new MQModelPooledObjectPolicy());


var app = builder.Build();

DatabaseManagerService.MigrationInitialization(app);
mqManager.Consume(app.Services.GetService<IActivitySetProcessors>());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();
