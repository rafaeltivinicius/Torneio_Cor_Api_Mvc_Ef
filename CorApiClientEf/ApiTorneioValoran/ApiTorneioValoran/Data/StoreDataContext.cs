using ApiTorneioValoran.Data.Maps;
using ApiTorneioValoran.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTorneioValoran.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Group> Group { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<Team> Team { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=bdValoran31;User ID=SA;Password=Leafar17.");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GroupMap());
            builder.ApplyConfiguration(new MatchMap());
            builder.ApplyConfiguration(new TeamMap());
        }
    }
}
