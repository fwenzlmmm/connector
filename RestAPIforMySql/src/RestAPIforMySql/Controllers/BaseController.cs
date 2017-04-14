using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestAPIforMySql.Interfaces;
using RestAPIforMySql.DAL;
using RestAPIforMySql.Models;

namespace RestAPIforMySql.Controllers
{
    public abstract class BaseController : Controller, IBaseController
    {
        private readonly IOptions<AppSettings> _config;
        private readonly ILogger _logger;
        private readonly HubConnectorContext _context;

        public IOptions<AppSettings> Config
        {
            get { return _config; }
        }
        public ILogger Logger
        {
            get { return _logger; }
        }

        public HubConnectorContext DBContext
        {
            get { return _context; }
        }

        IOptions<AppSettings> IBaseController.Config
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        ILogger IBaseController.Logger
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        HubConnectorContext IBaseController.DBContext
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public BaseController(IOptions<AppSettings> config, ILogger<Controller> logger)
        {
            _config = config;
            _logger = logger;
        }

        public BaseController(IOptions<AppSettings> config, ILogger<Controller> logger, HubConnectorContext context)
        {
            _config = config;
            _logger = logger;
            _context = context;
        }
    }
}
