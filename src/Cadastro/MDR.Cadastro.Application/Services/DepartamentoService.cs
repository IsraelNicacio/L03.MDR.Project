using AutoMapper;
using MDR.Cadastro.Application.DTO;
using MDR.Cadastro.Domain.Entities;
using MDR.Cadastro.Domain.Repositories;

namespace MDR.Cadastro.Application.Services;

public class DepartamentoService : IDepartamentoService
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _map;

    public DepartamentoService(IUnitOfWork unitOfWork, IMapper map)
    {
        _unitOfWork = unitOfWork;
        _map = map;
    }

    public void AdicionarDepartamento(DepartamentoDTO departamento)
    {
        var _depEntity = _map.Map<Departamento>(departamento);
        _unitOfWork.Pessoa.AdicionarDepartamento(_depEntity);

        _unitOfWork.CommitAsync();
    }

    public void AtualizarDepartamento(DepartamentoDTO departamento)
    {
        var depEntity = _map.Map<Departamento>(departamento);
        _unitOfWork.Pessoa.AtualizarDepartamento(depEntity);

        _unitOfWork.CommitAsync();
    }

    public async Task<DepartamentoDTO> RecuperarDepartamentoPorId(Guid id)
        => _map.Map<DepartamentoDTO>(await _unitOfWork.Pessoa.RecuperarDepartamentoPorId(id));

    public async Task<IEnumerable<DepartamentoDTO>> RecuperarDepartamentos()
        => _map.Map<IEnumerable<DepartamentoDTO>>(await _unitOfWork.Pessoa.RecuperarDepartamentos());
}
