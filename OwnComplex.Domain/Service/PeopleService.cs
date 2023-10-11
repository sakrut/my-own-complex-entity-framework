using OwnComplex.Domain.Entities;
using OwnComplex.Domain.Repositories;
using OwnComplex.Domain.ValueObjects;

namespace OwnComplex.Domain.Service
{
    public class PeopleService : IPeopleService, IDisposable
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly ITenantIdAccessor _tenantIdAccessor;

        public PeopleService(IPeopleRepository peopleRepository, ITenantIdAccessor tenantIdAccessor)
        {
            _peopleRepository = peopleRepository;
            _tenantIdAccessor = tenantIdAccessor;
        }

        public Task<Guid> AddThinPerson()
        {
            return AddThinPerson(null, null);
        }

        public async Task<Guid> AddThinPerson(List<EntityId>? roles, EntityId? riskProfile)
        {
            var thinPerson = PersonEntity.ThinPerson(_tenantIdAccessor.GetTenantId());
            if (roles != null)
                thinPerson.SetRoles(roles);
            if (riskProfile != null)
                thinPerson.AddRiskProfile(riskProfile);

            _peopleRepository.Add(thinPerson);
            await _peopleRepository.Commit();
            return thinPerson.Id;
        }

        public async Task<Guid> AddFatPerson()
        {
            var fatPerson = PersonEntity.FatPerson(_tenantIdAccessor.GetTenantId());
            _peopleRepository.Add(fatPerson);

            await _peopleRepository.Commit();
            return fatPerson.Id;
        }

        public Task UpdatePerson(PersonEntity person)
        {
            _peopleRepository.Update(person);
            return _peopleRepository.Commit();
        }

        public Task UpdateByTracking()
        {
            return _peopleRepository.Commit();
        }

        public Task<PersonEntity> GetPerson(Guid id)
        {
            return _peopleRepository.Get(id);
        }

        public Task<ICollection<PersonEntity>> GetAll()
        {
            return _peopleRepository.GetAll();
        }

        public void Dispose()
        {
            _peopleRepository.Dispose();
        }
    }

    public interface IPeopleService : IDisposable
    {
        public Task<Guid> AddThinPerson();
        public Task<Guid> AddThinPerson(List<EntityId>? roles, EntityId? riskProfile);

        public Task<Guid> AddFatPerson();

        public Task UpdatePerson(PersonEntity person);

        public Task UpdateByTracking();

        public Task<PersonEntity> GetPerson(Guid id);

        public Task<ICollection<PersonEntity>> GetAll();
    }
}
