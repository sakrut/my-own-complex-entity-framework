using OwnComplex.Domain.Entities;

namespace OwnComplex.Domain.Repositories;

public interface IPeopleRepository : IDisposable
{
    public void Add(PersonEntity personEntity);

    public void Update(PersonEntity personEntity);

    public Task<PersonEntity> Get(Guid id);

    public Task<ICollection<PersonEntity>> GetAll();

    public Task Commit();
}