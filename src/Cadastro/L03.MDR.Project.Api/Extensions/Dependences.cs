using MDR.Cadastro.Application.Automapper;
using MDR.Cadastro.Application.Services;
using MDR.Cadastro.Domain.Repositories;
using MDR.Cadastro.Infrastructure.Data.Repositories;

namespace L03.MDR.Project.Api.Extensions;

public static class Dependences
{
    public static void AddDependences(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainDTOMappingProfile));

        services.AddScoped<IPessoaRepository, PessoaRepository>();
        services.AddScoped<IPessoaService, PessoaService>();
        services.AddScoped<IDepartamentoService, DepartamentoService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
