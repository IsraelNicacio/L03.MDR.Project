using MDR.Cadastro.Application.DTO;

namespace MDR.Cadastro.Application.Services;

public interface IPessoaService
{
    Task<IEnumerable<PessoaDTO>> RecuperarPessoas();
    Task<PessoaDTO> RecuperarPessoaPorId(Guid id);
    void AdicionarPessoa(PessoaDTO pessoa);
    void AtualizarPessoa(PessoaDTO pessoa);
}