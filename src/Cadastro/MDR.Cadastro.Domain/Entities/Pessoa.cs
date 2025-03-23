using MDR.Core.DomainObject;

namespace MDR.Cadastro.Domain.Entities;

public class Pessoa : EntityCore, IAggregateRoot
{
    public Guid DepartamentoId { get; private set; }
    public string Nome { get; private set; }
    public string SobreNome { get; private set; }
    public int Idade { get; private set; }
    public Departamento Departamento { get; private set; }

    public Pessoa()
    { }

    public Pessoa(string nome, string sobreNome, int idade, Guid departamentoId)
    {
        Nome = nome;
        SobreNome = sobreNome;
        Idade = idade;
        DepartamentoId = departamentoId;

        Validacao();
    }

    #region Ad-Hoc

    public void AlterarNome(string nome)
    {
        DomainValidation.ValidarCaracteres(nome, 3, 60, "O nome da Pessoa deve ter entre 3 e 60 caracteres");
        Nome = nome;
    }

    public void AlterarSobreNome(string sobreNome)
    {
        DomainValidation.ValidarCaracteres(sobreNome, 3, 60, "O SobreNome da Pessoa deve ter entre 3 e 60 caracteres");
        SobreNome = sobreNome;
    }

    public void AlterarSobreNome(int idade)
    {
        DomainValidation.ValidarMinimoMaximo(idade, 0, 120, "A Idade da Pessoa deve ser entre 0 e 120 anos");
        Idade = idade;
    }

    public void AlterarDepartamento(Departamento departamento)
    {
        if (departamento is not null)
            Departamento.AlterarNome(departamento.Nome);
    }

    #endregion

    #region Validation Domain

    public void Validacao()
    {
        DomainValidation.ValidarCaracteres(Nome, 3, 60, "O nome da Pessoa deve ter entre 3 e 60 caracteres");
        DomainValidation.ValidarCaracteres(SobreNome, 3, 60, "O SobreNome da Pessoa deve ter entre 3 e 60 caracteres");
        DomainValidation.ValidarMinimoMaximo(Idade, 0, 120, "A Idade da Pessoa deve ser entre 0 e 120 anos");
    } 

    #endregion
}