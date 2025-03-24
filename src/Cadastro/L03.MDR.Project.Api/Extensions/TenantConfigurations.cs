using MDR.Cadastro.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace L03.MDR.Project.Api.Extensions;

public static class TenantConfigurations
{
    public static void RegisterTenant(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<CadastroContext>(provider =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<CadastroContext>();
            var httpContext = provider.GetService<IHttpContextAccessor>()?.HttpContext;
            var tenant = httpContext?.Request.Path.Value?.Split("/", StringSplitOptions.RemoveEmptyEntries)[0];
            var connectionString = configuration.GetConnectionString("Tenant_DataBase")?.Replace("_DATABASE_",tenant);

            optionsBuilder.UseSqlServer(connectionString)
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging();

            return new CadastroContext(optionsBuilder.Options);
        });
    }
}