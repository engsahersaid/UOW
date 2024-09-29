using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UOWPoc.Entities;
using UOWPoc.Infrastructure.Config.BaseConfig;

namespace UOWPoc.Infrastructure.Config
{
    public class AddressConfiguration : BaseEntityConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).HasColumnType("guid");
            //builder.HasQueryFilter(x => !x.IsDeleted);
            base.Configure(builder);
        }
    }
}