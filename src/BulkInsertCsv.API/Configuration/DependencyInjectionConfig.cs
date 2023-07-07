using BulkInsertCsv.API.Application.Messages.Commands;
using BulkInsertCsv.API.Application.Services;
using BulkInsertCsv.API.Data;
using Microsoft.EntityFrameworkCore;

namespace BulkInsertCsv.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OrganizationDbContext>(options => options.UseInMemoryDatabase("OrganizationDB"));

        services.AddTransient<OrganizationPopulateService>();

        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(typeof(CreateOrganizationCommand).Assembly);
        });

        return services;
    }
}
