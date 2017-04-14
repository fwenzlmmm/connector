using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestAPIforMySql.DAL;
using RestAPIforMySql.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace RestAPIforMySql.Controllers
{
    [Route("api/[controller]")]
    public class DefinitionsController : BaseController
    {
        private readonly IOptions<AppSettings> _config;
        ILogger<DefinitionsController> _logger;
        private readonly HubConnectorContext _dbContext;

        public DefinitionsController(IOptions<AppSettings> config, ILogger<DefinitionsController> logger, HubConnectorContext dbContext) : base(config, logger, dbContext)
        {
            _config = config;
            _logger = logger;
            _dbContext = dbContext;
        }

        // GET api/definitions
        [HttpGet]
        public IActionResult Get()
        {
            var data = from b in _dbContext.ExtractDefinitions
                        orderby b.Name
                        select b;
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data.ToArray());
            }
        }

        // GET api/definitions/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogDebug("Inside DefinitionsController GET Method. Id: " + id);

            var data = from b in _dbContext.ExtractDefinitions
                       where b.Id != null && object.Equals(b.Id, id)  
                       orderby b.Name
                        select b;
         
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data.FirstOrDefault());
            }
        }

        // POST api/definitions
        [HttpPost]
        //public void Post(HttpRequestMessage value)
        public IActionResult Post([FromBody] dynamic value)
        {
            try
            {
                string result = null;
                if (value == null)
                    _logger.LogDebug("Inside DefinitionsController POST Method. Received: NULL");
                else
                { 
                    _logger.LogDebug("Inside DefinitionsController POST Method. Received: SOMETHING");
                    if (value == null)
                        _logger.LogDebug("value.Content: NULL");
                    else
                    {
                        result = JsonConvert.SerializeObject(value);
                        if (result == null)
                            _logger.LogDebug("result: NULL");
                        else
                            _logger.LogDebug("result: " + result);
                    }
                }
                if (!string.IsNullOrWhiteSpace(result))
                {
                    _logger.LogDebug("Deserializing POST data...");
                    ExtractDefinitions extractDefinition = JsonConvert.DeserializeObject<ExtractDefinitions>(result);
                    extractDefinition.Id = null; //be sure to clear this value so we can auto-increment in the database
                    _logger.LogDebug("Insert into Database...");
                    _dbContext.ExtractDefinitions.Add(extractDefinition);
                    _dbContext.SaveChanges();
                    _logger.LogDebug("Insert completed...");
                }
                return Ok();
            }
            catch //if the record does not exist, don't throw an error
            {
                _logger.LogDebug("DefinitionsController POST Method. Could not insert new record.");
                return BadRequest();
            }
        }

        // PUT api/definitions/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] dynamic value)
        {
            try
            {
                string result = null;
                if (value == null)
                    _logger.LogDebug("Inside DefinitionsController PUT Method. Received: NULL");
                else
                {
                    _logger.LogDebug("Inside DefinitionsController PUT Method. Received: SOMETHING");
                    if (value == null)
                        _logger.LogDebug("value.Content: NULL");
                    else
                    {
                        result = JsonConvert.SerializeObject(value);
                        if (result == null)
                            _logger.LogDebug("result: NULL");
                        else
                            _logger.LogDebug("result: " + result);
                    }
                }
                if (!string.IsNullOrWhiteSpace(result))
                {
                    _logger.LogDebug("Deserializing PUT data...");
                    ExtractDefinitions extractDefinition = JsonConvert.DeserializeObject<ExtractDefinitions>(result);
                    extractDefinition.Id = id;
                    _logger.LogDebug("Update Database record: " + id);
                    _dbContext.ExtractDefinitions.Update(extractDefinition);
                    _dbContext.SaveChanges();
                    _logger.LogDebug("Update completed...");
                }
                return Ok();
            }
            catch //if the record does not exist, don't throw an error
            {
                _logger.LogDebug("DefinitionsController PUT Method. Could not find record for Id: " + id);
                return NotFound();
            }
        }

        // DELETE api/definitions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogDebug("Inside DefinitionsController DEL Method. Id: " + id);
            try
            {
                var extractDefinitions = new ExtractDefinitions { Id = id };
                _dbContext.ExtractDefinitions.Attach(extractDefinitions);
                _dbContext.ExtractDefinitions.Remove(extractDefinitions);
                _dbContext.SaveChanges();
                return Ok();
            }
            catch //if the record does not exist, don't throw an error
            {
                _logger.LogDebug("DefinitionsController DEL Method. Could not find record for Id: " + id);
                return NotFound();
            }
        }
    }
}
