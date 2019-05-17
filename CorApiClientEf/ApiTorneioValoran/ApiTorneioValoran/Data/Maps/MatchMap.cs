using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ApiTorneioValoran.Models;

namespace ApiTorneioValoran.Data.Maps
{
    public class MatchMap : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("Matchs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date);
        }
    }
}
