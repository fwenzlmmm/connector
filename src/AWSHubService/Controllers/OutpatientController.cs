using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AWSHubService.Data;
using AWSHubService.Models;
using Microsoft.Extensions.Options;

namespace AWSHubService.Controllers
{
    [Route("api/[controller]")]
    public class OutpatientController : Controller
    {
        private readonly ClientDBContext _context;
        private readonly IOptions<AppSettings> _config;
        public OutpatientController(IOptions<AppSettings> config, ClientDBContext context)
        {
            _config = config;
            _context = context;
        }

        // GET: Inpatient/Details/5
        public async Task<vwOutpatient> Details(string id)
        {
            if (id == null)
            {
                return null;
            }
            vwOutpatient outpatient = await _context.vwOutpatient.Include(x => x.OutpatientDetails).SingleOrDefaultAsync(m => m.ExportQueueKey == id);
            if (outpatient == null)
            {
                return outpatient;
            }
            return outpatient;
        }

        [HttpGet]
        public async Task<IEnumerable<vwOutpatient>> GetAll()
        {
            int enterpriseId = 237006;
            DateTime dateStart = new DateTime(2013, 1, 1);
            DateTime dateEnd = new DateTime(2013, 12, 31);
            string finalOrWorking = "Final";

            vwOutpatient[] outpatients = await _context.vwOutpatient.Include(x => x.OutpatientDetails).Where(m => Convert.ToDateTime(m.DischargeDate) >= dateStart && Convert.ToDateTime(m.DischargeDate) <= dateEnd && m.WorkingOrFinal == finalOrWorking).ToArrayAsync();
            return outpatients.ToList();
        }

        [HttpGet("{enterpriseId}/{dateStart}/{dateEnd}/{finalOrWorking}")]
        public async Task<List<vwOutpatient>> List(int enterpriseId, DateTime dateStart, DateTime dateEnd, string finalOrWorking)
        {
            vwOutpatient[] outpatients = await _context.vwOutpatient.Include(x => x.OutpatientDetails).Where(m => Convert.ToDateTime(m.DischargeDate) >= dateStart && Convert.ToDateTime(m.DischargeDate) <= dateEnd && m.WorkingOrFinal == finalOrWorking).ToArrayAsync();
            var oPatients = outpatients.ToList();
            return oPatients;
        }
    }
}
