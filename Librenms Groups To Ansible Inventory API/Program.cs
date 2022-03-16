using Microsoft.Extensions.DependencyInjection;
using Refit;
using Shared_Library.DataAccess;

var builder = WebApplication.CreateBuilder(args);

var ConfigurationValue = builder.Configuration["Url"];
builder.Services.AddControllers();
builder.Services.AddRefitClient<IDevices>().ConfigureHttpClient(ConfigureClient);
builder.Services.AddRefitClient<IGroups>().ConfigureHttpClient(ConfigureClient);
builder.Services.AddRefitClient<ISingleGroup>().ConfigureHttpClient(ConfigureClient);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();




void ConfigureClient(HttpClient client) => client.BaseAddress = new Uri(ConfigurationValue);