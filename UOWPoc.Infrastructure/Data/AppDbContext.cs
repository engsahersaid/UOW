using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;
using UOwPoc.Core.Entities;
using UOwPoc.Core.Entities.Base;
using UOWPoc.Entities;
using UOWPoc.Infrastructure.Config;

namespace UOWPoc.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var item in ChangeTracker.Entries<BaseAuditableEntity>().AsEnumerable())
            {
                //Auto Timestamp
                //if (item.State == EntityState.Added)
                //    item.Entity.CreatedAt = DateTime.Now;

                if (item.State == EntityState.Modified)
                    item.Entity.lastUpdatedAt = DateTime.Now;

            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<BaseAuditableEntity>();
            //modelBuilder.Entity<BaseAuditableEntity>().HasQueryFilter(p => p.IsDeleted == false);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            /*modelBuilder.ApplyConfiguration<Nationality>(new NationalityConfiguration());
            modelBuilder.ApplyConfiguration<Person>(new PersonConfiguration());
            modelBuilder.ApplyConfiguration<Address>(new AddressConfiguration());*/

            //Seed some dummy data
            ModelBuilderSeed(modelBuilder);
        }

        private void ModelBuilderSeed(ModelBuilder modelBuilder)
        {
            Guid personId1 = Guid.NewGuid();
            Guid personId2 = Guid.NewGuid();
            Guid addressId1 = Guid.NewGuid();
            Guid addressId2 = Guid.NewGuid();

            modelBuilder.Entity<Nationality>().HasData(
                new Nationality(1, "Egypt", "Egypt"),
                new Nationality(2, "KSA", "KSA"));

            modelBuilder.Entity<Person>().HasData(
                new Person(personId1, "Saher", "Fahd", 1),
                new Person(personId2, "Saher", "Said", 2));

            modelBuilder.Entity<Address>().HasData(
                new Address(addressId1, personId1, "Egypt", "7575", "Cairo", "test street", "3"),
                new Address(addressId2, personId2, "KSA", "443543", "Riydah", "Almourabe", "54"));
        }
    }
}