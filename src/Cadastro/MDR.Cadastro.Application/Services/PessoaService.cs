using AutoMapper;
using MDR.Cadastro.Application.DTO;
using MDR.Cadastro.Domain.Entities;
using MDR.Cadastro.Domain.Repositories;

namespace MDR.Cadastro.Application.Services;

public class PessoaService : IPessoaService
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _map;

    public PessoaService(IUnitOfWork unitOfWork, IMapper map)
    {
        _unitOfWork = unitOfWork;
        _map = map;
    }

    public async void AdicionarPessoa(PessoaDTO pessoa)
    {
        var pessoaEntity = _map.Map<Pessoa>(pessoa);
        _unitOfWork.Pessoa.AdicionarPessoa(pessoaEntity);

        await _unitOfWork.CommitAsync();
    }

    public async void AtualizarPessoa(PessoaDTO pessoa)
    {
        var pessoaEntity = _map.Map<Pessoa>(pessoa);
        _unitOfWork.Pessoa.AtualizarPessoa(pessoaEntity);

        await _unitOfWork.CommitAsync();
    }

    public async Task<PessoaDTO> RecuperarPessoaPorId(Guid id)
        => _map.Map<PessoaDTO>(await _unitOfWork.Pessoa.RecuperarPessoaPorId(id));

    public async Task<IEnumerable<PessoaDTO>> RecuperarPessoas()
        => _map.Map<IEnumerable<PessoaDTO>>(await _unitOfWork.Pessoa.RecuperarPessoas());
}