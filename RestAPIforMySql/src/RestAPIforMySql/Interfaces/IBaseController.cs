using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestAPIforMySql.DAL;
using RestAPIforMySql.Models;

namespace RestAPIforMySql.Interfaces
{
    interface IBaseController
    {
        IOptions<AppSettings> Config { get; }
        ILogger Logger { get; }
        HubConnectorContext DBContext { get; }
    }
}
