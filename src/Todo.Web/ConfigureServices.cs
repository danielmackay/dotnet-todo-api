using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Todo.Infrastructure.Persistence;
using Todo.Web.Filters;

namespace Todo.Web;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddControllers(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>());

        services.AddFluentValidationAutoValidation(x => x.DisableDataAnnotationsValidation = true)
            .AddFluentValidationClientsideAdapters();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        return services;
    }
}
