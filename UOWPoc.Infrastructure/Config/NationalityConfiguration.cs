using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UOwPoc.Core.Entities;
using UOWPoc.Infrastructure.Config.BaseConfig;

namespace UOWPoc.Infrastructure.Config
{
    public class NationalityConfiguration : BaseLookupConfiguration<Nationality>
    {
        public override void Configure(EntityTypeBuilder<Nationality> builder)
        {
            builder.ToTable("Nationality");
            /*builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.UniqueName).IsUnique();*/
            base.Configure(builder);
        }
    }
}