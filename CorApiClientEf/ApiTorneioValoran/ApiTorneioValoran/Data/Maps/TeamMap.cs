using ApiTorneioValoran.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ApiTorneioValoran.Data.Maps
{
    public class TeamMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
            builder.HasOne(p => p.Match).WithOne(q => q.RsultTeamChampion).HasForeignKey<Match>(q => q.IdRsultTeamChampion);
        }
    }
}
