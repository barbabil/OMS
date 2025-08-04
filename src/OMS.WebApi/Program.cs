using OMS.Application.Shared.Settings;
using OMS.Bootstrapper;

var webBuilder = WebApplication.CreateBuilder(args);
var env = webBuilder.Environment;
var services = webBuilder.Services;

// Add services to the container.
//

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

webBuilder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
webBuilder.Configuration.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);

var appSettingsSection = webBuilder.Configuration.GetSection("ApplicationSettings");
//bind our configuration on the appropriate class
services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();

ApplicationStartup.InitializeWebApiRegistrations(services, appSettings);

var app = webBuilder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();