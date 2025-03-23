using MDR.Core.DomainObject;

namespace MDR.Cadastro.Domain.Entities;

public class Departamento : EntityCore
{
    public string Nome { get; private set; }
    public ICollection<Pessoa> Pessoas { get; private set; }

    public Departamento()
    { }

    public Departamento(string nome)
    {
        DomainValidation.ValidarCaracteres(nome, 3, 120, "O nome do Departamento deve ter entre 3 e 120 caracteres");
        Nome = nome;
    }

    public void AlterarNome(string nome)
    {
        DomainValidation.ValidarCaracteres(nome, 3, 120, "O nome do Departamento deve ter entre 3 e 120 caracteres");
        Nome = nome;
    }
}