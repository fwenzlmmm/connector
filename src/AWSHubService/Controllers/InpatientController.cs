using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using AWSHubService.Data;
using AWSHubService.Models;

namespace AWSHubService.Controllers
{
    [Route("api/[controller]")]
    public class InpatientController : BaseController
    {
        public InpatientController(IOptions<AppSettings> config, ILogger<InpatientController> logger, ClientDBContext context) : base(config, logger, context)
        {
        }

        // GET: Inpatient/Details/5
        public async Task<vwInpatient> Details(string id)
        {
            if (id == null)
            {
                return null;
            }
            vwInpatient inpatient = await DBContext.vwInpatient.SingleOrDefaultAsync(m => m.ExportQueueKey == id);
            if (inpatient == null)
            {
                return inpatient;
            }
            return inpatient;
        }

        [HttpGet]
        public async Task<IEnumerable<vwInpatient>> GetAll()
        {
            int enterpriseId = 237006;
            DateTime dateStart = new DateTime(2013, 1, 1);
            DateTime dateEnd = new DateTime(2013, 12, 31);
            string finalOrWorking = "Final";

            vwInpatient[] inpatients = await DBContext.vwInpatient.Where(m => Convert.ToDateTime(m.DischargeDate) >= dateStart && Convert.ToDateTime(m.DischargeDate) <= dateEnd && m.WorkingOrFinal == finalOrWorking).ToArrayAsync();
            return inpatients.ToList();
        }

        [HttpGet("{enterpriseId}/{dateStart}/{dateEnd}/{finalOrWorking}")]
        [Route("api/Inpatient/{enterpriseId}/{dateStart}/{dateEnd}/{finalOrWorking}")]
        // GET: Inpatient/List/5
        public async Task<List<vwInpatient>> List(int enterpriseId, DateTime dateStart, DateTime dateEnd, string finalOrWorking)
        {
            vwInpatient[] inpatients = await DBContext.vwInpatient.Where(m => Convert.ToDateTime(m.DischargeDate) >= dateStart && Convert.ToDateTime(m.DischargeDate) <= dateEnd && m.WorkingOrFinal == finalOrWorking).ToArrayAsync();
            return inpatients.ToList();
        }
    }
}
