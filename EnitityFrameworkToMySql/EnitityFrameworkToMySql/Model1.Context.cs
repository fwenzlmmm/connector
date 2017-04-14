using EnitityFrameworkToMySql;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data.Entity;

[DbConfigurationType(typeof(MySqlEFConfiguration))]
class HubConnectorContext : DbContext
{
    public DbSet<ExtractDefinition> ExtractDefinitions { get; set; }
    public DbSet<Schedules> Schedules { get; set; }
    public DbSet<ExtractSchedule> ExtractSchedules { get; set; }

    public HubConnectorContext()
      : base("server=localhost;user id=root;password=imperial7;persistsecurityinfo=True;database=Model1")
    {

    }
    /*
    public HubConnectorContext(DbConnection existingConnection, bool contextOwnsConnection)
      : base(existingConnection, contextOwnsConnection)
    {

    }
    */
}

