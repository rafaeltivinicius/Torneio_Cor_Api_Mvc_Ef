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
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=bdValoran1;User ID=SA;Password=leafar");
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Projetos\Torneio_Cor_Api_Mvc_Ef\CorApiClientEf.mdf;Integrated Security=True;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GroupMap());
            builder.ApplyConfiguration(new MatchMap());
            builder.ApplyConfiguration(new TeamMap());
        }
    }
}
