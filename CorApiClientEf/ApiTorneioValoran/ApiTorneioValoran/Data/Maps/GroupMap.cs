using System;
using System.Collections.Generic;
using System.Linq;
using ApiTorneioValoran.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTorneioValoran.Data.Maps
{
    public class GroupMap : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
            builder.HasOne(p => p.Match).WithOne(q => q.Group).HasForeignKey<Match>(i => i.IdGrupo);
            builder.HasMany(p => p.Teams).WithOne(q => q.Group).IsRequired(false);
        }
    }
}
