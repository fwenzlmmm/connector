using System;
using AWSHubService.Data;
using AWSHubService.Interfaces;
using AWSHubService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace AWSHubService.Controllers
{
    public abstract class BaseController : Controller, IBaseController
    {
        private readonly IOptions<AppSettings> _config;
        private readonly ILogger _logger;
        private readonly ClientDBContext _context;

        public IOptions<AppSettings> Config
        {
            get { return _config; }
        }
        public ILogger Logger
        {
            get { return _logger; }
        }

        public ClientDBContext DBContext
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

        ClientDBContext IBaseController.DBContext
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

        public BaseController(IOptions<AppSettings> config, ILogger<Controller> logger, ClientDBContext context)
        {
            _config = config;
            _logger = logger;
            _context = context;
        }
    }
}
