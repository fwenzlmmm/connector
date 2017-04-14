using Microsoft.EntityFrameworkCore;
using RestAPIforMySql.Models;

namespace RestAPIforMySql.DAL
{
    public class HubConnectorContext : DbContext
    {
        public virtual DbSet<ExtractDefinitions> ExtractDefinitions { get; set; }
        public virtual DbSet<Schedules> Schedules { get; set; }
        public virtual DbSet<ExtractSchedules> ExtractSchedules { get; set; }

        public HubConnectorContext(DbContextOptions<HubConnectorContext> options) : base(options)
        {
        }
        }
}