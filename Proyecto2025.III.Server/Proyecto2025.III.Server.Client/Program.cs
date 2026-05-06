using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Proyecto2025.III.Servicio.ServiciosHttp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

builder.Services.AddScoped<IHttpServicio, HttpServicio>();

await builder.Build().RunAsync();
