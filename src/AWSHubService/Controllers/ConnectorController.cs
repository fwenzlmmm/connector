using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using AWSHubService.Models;
using AWSHubService.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AWSHubService.Controllers
{
    [Route("api/[controller]")]
    public class ConnectorController : Controller
    {
        private readonly IOptions<AppSettings> _config;
        private readonly ClientDBContext _context;
        public ConnectorController(IOptions<AppSettings> config, ClientDBContext context)
        {
            _config = config;
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<vwInpatient>> GetAll()
        {
            int enterpriseId = 237006;
            DateTime dateStart = new DateTime(2013, 1, 1);
            DateTime dateEnd = new DateTime(2013, 12, 31);
            string finalOrWorking = "Final";

            vwInpatient[] inpatients = await _context.vwInpatient.Where(m => Convert.ToDateTime(m.DischargeDate) >= dateStart && Convert.ToDateTime(m.DischargeDate) <= dateEnd && m.WorkingOrFinal == finalOrWorking).ToArrayAsync();
            return inpatients.ToList();
        }

        [HttpGet]
        [Route("api/[controller]/{enterpriseId}/{dateStart}/{dateEnd}/{final}")]
        public string Inpatient(int enterpriseId, DateTime dateStart, DateTime dateEnd, bool final)
        {
            return GetInpatientData(enterpriseId, dateStart, dateEnd, final);
        }
        public IActionResult Index()
        {
            return View();
        }

        private string GetInpatientData(int enterpriseId, DateTime dateStart, DateTime dateEnd, bool final)
        {
            //string inpatientData = null;
            
            //using (var context = serviceProvider.GetService<ConnectorContext>())
            //{
            // do stuff
            //}

            //var options = serviceProvider.GetService<DbContextOptions<ConnectorContext>>();
            return string.Format("select * from [ClientDB_{0}].[dbo].[vwInpatient] where DischargeDate between '{1}' and '{2}' and WorkingOrFinal = '{3}' order by DischargeDate ASC", enterpriseId, dateStart, dateEnd, final ? "Final" : "Working");
        }
    }
}
