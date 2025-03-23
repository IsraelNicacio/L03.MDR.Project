namespace MDR.Core.DomainObject;

public abstract class EntityCore
{
    public Guid Id { get; set; }

    protected EntityCore()
        => Id = Guid.NewGuid();

    public override bool Equals(object? obj)
    {
        var compareTo = obj as EntityCore;

        if(ReferenceEquals(this, compareTo)) return true;
        if(ReferenceEquals(null, compareTo)) return false;

        return Id.Equals(compareTo);
    }
}