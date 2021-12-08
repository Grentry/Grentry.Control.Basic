using Grentry.Control.Basic.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grentry.Control.Basic.HostedServices
{
    public class ControllerHostedService : IHostedService
    {
        private readonly ILogger<ControllerHostedService> _logger;
        private readonly IControllerService _controllerService;

        public ControllerHostedService(
            ILogger<ControllerHostedService> logger,
            IControllerService controllerService)
        {
            this._logger = logger;
            this._controllerService = controllerService;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await this._controllerService.StartAsync(cancellationToken);
            this._logger.LogInformation("ControllerHostedService started");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await this._controllerService.StopAsync(cancellationToken);
            this._logger.LogInformation("ControllerHostedService stopped");
        }
    }
}
