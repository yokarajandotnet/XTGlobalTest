using DadJoke;
using Microsoft.AspNetCore.Mvc.Formatters;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();
builder.Services.AddControllers(c => {

    c.OutputFormatters.Add(new HtmlOutputFormatter());
    c.OutputFormatters.Add(new StringOutputFormatter());
  
});

builder.Services.AddAuthentication("ApiKey")
    .AddScheme<ApiKeyAuthenticationSchemeOptions, ApiKeyAuthenticationSchemeHandler>("ApiKey",
        opts => opts.ApiKey = configuration.GetValue<string>("api-key")
    );



var app = builder.Build();


app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
