using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OwnComplex.Domain.Entities;
using OwnComplex.Domain.Repositories;
using OwnComplex.Domain.Service;

namespace OwnComplex.EF6.OwnModel
{
    public class TestEF6Context : DbContext, IPeopleRepository
    {
        public DbSet<PersonEntity> People { get; set; }
        private readonly ILogger<TestEF6Context>? _logger;
        private ITenantIdAccessor _tenantIdAccessor;


        public TestEF6Context()
        {
        }

        public TestEF6Context(ILogger<TestEF6Context>? logger, ITenantIdAccessor tenantIdAccessor)
        {
            _logger = logger;
            _tenantIdAccessor = tenantIdAccessor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Environment.GetEnvironmentVariable("EFExampleConnectionString"),
                x =>
                {
                    x.MigrationsHistoryTable(
                        HistoryRepository.DefaultTableName,
                        "EF6");
                });

            options.EnableSensitiveDataLogging();
            options.LogTo(log =>
            {
                if (!log.Contains("Executing DbCommand"))
                {
                    return;
                }
                if (_logger == null)
                    Console.WriteLine(log);
                else
                    _logger.LogDebug(log);
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());

            modelBuilder.Entity<PersonEntity>().HasQueryFilter(p => p.TenantId == this._tenantIdAccessor.GetTenantId());
        }

        public void Add(PersonEntity personEntity)
        {
            this.Set<PersonEntity>().Add(personEntity);
        }

        public void Update(PersonEntity personEntity)
        {
            this.People.Update(personEntity);
        }

        public async Task<PersonEntity> Get(Guid id)
        {
            return await this.Set<PersonEntity>().FindAsync(_tenantIdAccessor.GetTenantId(), id) ?? throw new Exception($"Person with id {id} not fond");
        }

        public async Task<ICollection<PersonEntity>> GetAll()
        {
            return await this.Set<PersonEntity>().ToListAsync();
        }

        public Task Commit()
        {
            if (_logger == null)
                Console.WriteLine(ChangeTracker.DebugView.LongView);
            else
                _logger.LogDebug(ChangeTracker.DebugView.LongView);;
            return this.SaveChangesAsync();
        }
    }
}
