using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OwnComplex.Domain.Entities;
using OwnComplex.Domain.Repositories;
using OwnComplex.Domain.Service;

namespace OwnComplex.EF7.OwnModel
{
    public class TestEF7Context : DbContext, IPeopleRepository
    {
        public DbSet<PersonEntity> People { get; set; }
        private readonly ILogger<TestEF7Context>? _logger;
        private ITenantIdAccessor _tenantIdAccessor;

        public TestEF7Context()
        {
        }

        public TestEF7Context(ILogger<TestEF7Context> logger, ITenantIdAccessor tenantIdAccessor)
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
                        "EF7");
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
        }

        public void Add(PersonEntity personEntity)
        {
            this.People.Add(personEntity);
        }

        public void Update(PersonEntity personEntity)
        {
            this.People.Update(personEntity);
        }

        public async Task<PersonEntity> Get(Guid id)
        {
            return await this.People.FindAsync(_tenantIdAccessor.GetTenantId(), id) ?? throw new Exception($"Person with id {id} not fond");
        }

        public async Task<ICollection<PersonEntity>> GetAll()
        {
            return await this.People.ToListAsync();
        }

        public Task Commit()
        {
            return this.SaveChangesAsync();
        }
    }
}
