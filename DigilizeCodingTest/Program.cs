using DigilizeCodingTest;
using DigilizeCodingTest.BusinessLogic.Services;
using DigilizeCodingTest.BusinessLogic.Services.Interface;
using DigilizeCodingTest.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<Application>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<ICompanyService, CompanyService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ApplicationDbContext>();
            services.AddSingleton<Application>();
        });
}