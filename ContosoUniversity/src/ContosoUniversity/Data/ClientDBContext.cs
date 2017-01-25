using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Data
{
    public class ClientDBContext : DbContext
    {
        public ClientDBContext() : base()
        {
        }
        public ClientDBContext(DbContextOptions<ClientDBContext> options) : base(options)
        {
        }

        public DbSet<vwInpatient> Inpatients { get; set; }
        public DbSet<vwOutpatient> Outpatients { get; set; }
        public DbSet<vwOutpatientDetails> OutpatientsDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vwInpatient>().ToTable("vwInpatient");
            modelBuilder.Entity<vwOutpatient>().ToTable("vwOutpatient");
            modelBuilder.Entity<vwOutpatientDetails>().ToTable("vwOutpatientDetails");
        }
    }
}
