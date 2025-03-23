using MDR.Core.DomainObject;

namespace MDR.Core.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
}
