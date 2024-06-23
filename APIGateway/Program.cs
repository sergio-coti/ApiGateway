using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//ler o arquivo de configurações do Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

//habilitar o Ocelot
builder.Services.AddOcelot();

var app = builder.Build();

app.UseRouting();
app.MapGet("/", () => "API Gateway");

app.UseOcelot().Wait();

app.Run();
