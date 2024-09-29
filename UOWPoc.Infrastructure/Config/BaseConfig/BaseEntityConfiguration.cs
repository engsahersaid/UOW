﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UOwPoc.Core.Entities.Base;

namespace UOWPoc.Infrastructure.Config.BaseConfig
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseAuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("nvarchar(50)");
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}