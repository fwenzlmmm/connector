using AWSHubService.Data;
using AWSHubService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSHubService.Interfaces
{
    interface IBaseController
    {
        IOptions<AppSettings> Config { get; }
        ILogger Logger { get; }
        ClientDBContext DBContext { get; }
    }
}
