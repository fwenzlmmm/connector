using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;
using AWSHubService.Attributes;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace AWSHubService.Models
{
    //class used to provide a means for Dependancy Injection from Controllers to Attributes
    public class ApplicationModelProvider : IApplicationModelProvider
    {
        private readonly IOptions<AppSettings> _config;
        private readonly ILogger _logger;

        // constructor injection
        public ApplicationModelProvider(IOptions<AppSettings> config, ILoggerFactory logger)
        {
            _config = config;
            _logger = logger.CreateLogger("ApplicationModelProvider.Attributes.RequireClientCert"); ;
        }

        public int Order { get { return -1000 + 10; } }

        public void OnProvidersExecuted(ApplicationModelProviderContext context)
        {
            foreach (var controllerModel in context.Result.Controllers)
            {
                // pass the depencency to controller attibutes
                controllerModel.Attributes
                    .OfType<RequireClientCert>().ToList()
                    .ForEach(a => a.Config = _config);
                controllerModel.Attributes
                    .OfType<RequireClientCert>().ToList()
                    .ForEach(b => b.Logger = _logger);

                // pass the dependency to action attributes
                controllerModel.Actions.SelectMany(a => a.Attributes)
                    .OfType<RequireClientCert>().ToList()
                    .ForEach(a => a.Config = _config);
                controllerModel.Actions.SelectMany(a => a.Attributes)
                    .OfType<RequireClientCert>().ToList()
                    .ForEach(b => b.Logger = _logger);
       
            }
        }

        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
            // intentionally empty
        }
    }
}
