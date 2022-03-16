using Shared_Library.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;


var config = new ConfigurationBuilder();
BuildConfig(config);


var configuration = config.Build();

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddRefitClient<IGroups>().ConfigureHttpClient(ConfigureClient);
        services.AddRefitClient<IDevices>().ConfigureHttpClient(ConfigureClient);
        services.AddRefitClient<ISingleGroup>().ConfigureHttpClient(ConfigureClient);
        services.AddTransient<ILibrenmsToAnsibleInventory, LibrenmsToAnsibleInventory>();
    }).Build();

var svc = ActivatorUtilities.CreateInstance<LibrenmsToAnsibleInventory>(builder.Services);
await svc.GetDevices();


void ConfigureClient(HttpClient client) => client.BaseAddress = new Uri(configuration.GetValue<String>("Url"));
static void BuildConfig(IConfigurationBuilder builder) => builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();




