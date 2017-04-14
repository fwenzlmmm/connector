using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitityFrameworkToMySql
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new HubConnectorContext())
            {
                // Create and save a new ExtractDefinition 
                Console.Write("Enter a name for a new ExtractDefinition: ");
                var name = Console.ReadLine();

                var extractDefinition = new ExtractDefinition { Id = 1, ApplicationId = 124, Name = name, CreatedBy = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, EnterpriseId = 53002, QueryDefinition = "Some definition", UpdatedBy = 1 };
                db.ExtractDefinitions.Add(extractDefinition);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.ExtractDefinitions
                            orderby b.Name
                            select b;

                Console.WriteLine("All ExtractDefinitions in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
