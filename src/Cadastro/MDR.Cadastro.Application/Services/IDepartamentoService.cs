using MDR.Cadastro.Application.DTO;

namespace MDR.Cadastro.Application.Services;

public interface IDepartamentoService
{
    Task<IEnumerable<DepartamentoDTO>> RecuperarDepartamentos();
    Task<DepartamentoDTO> RecuperarDepartamentoPorId(Guid id);
    void AdicionarDepartamento(DepartamentoDTO departamento);
    void AtualizarDepartamento(DepartamentoDTO departamento);
}