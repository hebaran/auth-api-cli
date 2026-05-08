using Microsoft.Extensions.Configuration;
using AuthCli.Core;
using AuthCli.Settings;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");

IConfiguration config = builder.Build();

ApiSettings.BaseUrl = config["ApiSettings:BaseUrl"] 
    ?? throw new InvalidOperationException("ERRO: \"BaseUrl\" não foi configurada em appsettings.json.");

var app = new App();
await app.Run();
