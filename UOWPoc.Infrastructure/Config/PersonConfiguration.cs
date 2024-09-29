using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UOWPoc.Entities;
using UOWPoc.Infrastructure.Config.BaseConfig;

namespace UOWPoc.Infrastructure.Config
{
    public class PersonConfiguration : BaseEntityConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasMany<Address>(x => x.Addresses).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Restrict);
            /*builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("guid");
            builder.HasQueryFilter(x => !x.IsDeleted);*/
            base.Configure(builder);
        }
    }
}