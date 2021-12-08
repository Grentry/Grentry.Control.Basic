using Grentry.Control.Basic.Models;
using Grentry.Control.Basic.Services.Interfaces;
using Grentry.SDK;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grentry.Control.Basic.Services
{
    public class ControllerService : IControllerService
    {
        private readonly ILogger<ControllerService> logger;
        private readonly IValidationService _validationService;
        private readonly IWebsiteService _websiteService;
        GrentryClient grentryClient;

        public ControllerService(
            ILogger<ControllerService> logger,
            IValidationService validationService,
            IWebsiteService websiteService)
        {
            this.logger = logger;
            this._validationService = validationService;
            this._websiteService = websiteService;
            this._websiteService.SetWebsiteModelAsync(GetStartWebsiteDto());
        }
        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
#if DEBUG
            this.grentryClient = new GrentryClient("http://192.168.0.20:5000/");
#else
            this.grentryClient = new GrentryClient("http://locahost:5000/");
#endif
            this.grentryClient.BarcodeReceived += async (o, data) => await GrentryClient_BarcodeReceived(o, data);
            this.grentryClient.CardReceived += async (o, data) => await GrentryClient_CardReceived(o, data);
            await this.grentryClient.Start();
        }

        private async Task GrentryClient_CardReceived(object sender, SDK.Models.CardInfoDto cardInfo)
        {
            if(await this._validationService.IsCardValidAsync(cardInfo.Uid))
            {
                await this._websiteService.SetWebsiteModelAsync(GetSuccessWebsiteDto());
                await this.grentryClient.TriggerRelay(0, 1000);
                await Task.Delay(7000);
                await this._websiteService.SetWebsiteModelAsync(GetStartWebsiteDto());
            }
            else
            {
                await this._websiteService.SetWebsiteModelAsync(GetFailedWebsiteDto());
                await Task.Delay(7000);
                await this._websiteService.SetWebsiteModelAsync(GetStartWebsiteDto());
            }
        }

        private async Task GrentryClient_BarcodeReceived(object sender, SDK.Models.BarcodeDto barcodeInfo)
        {
            if (await this._validationService.IsBarcodeValidAsync(barcodeInfo.Barcode.TrimEnd('\r')))
            {
                await this._websiteService.SetWebsiteModelAsync(GetSuccessWebsiteDto());
                await this.grentryClient.TriggerRelay(0, 1000);
                await Task.Delay(7000);
                await this._websiteService.SetWebsiteModelAsync(GetStartWebsiteDto());
            }
            else
            {
                await this._websiteService.SetWebsiteModelAsync(GetFailedWebsiteDto());
                await Task.Delay(7000);
                await this._websiteService.SetWebsiteModelAsync(GetStartWebsiteDto());
            }
        }

        private WebsiteDto GetSuccessWebsiteDto()
        {
            var response = new WebsiteDto();
            response.BackgroundColor = "#00FF00";
            response.TextItems.Add(new TextItem
            {
                Height = 150,
                Width = 400,
                Text = "Enter please",
                TextSize = 40,
                XPosition = 200,
                YPosition = 165
            });

            return response;
        }

        private WebsiteDto GetFailedWebsiteDto()
        {
            var response = new WebsiteDto();
            response.BackgroundColor = "#FF0000";
            response.TextItems.Add(new TextItem
            {
                Height = 150,
                Width = 400,
                Text = "Not authorized",
                TextSize = 40,
                XPosition = 200,
                YPosition = 165
            });

            return response;
        }

        private WebsiteDto GetStartWebsiteDto()
        {
            var response = new WebsiteDto();
            response.BackgroundColor = "#C0C0C0";
            response.TextItems.Add(new TextItem
            {
                Height = 150,
                Width = 500,
                Text = "Please tap or scan your card",
                TextSize = 40,
                XPosition = 150,
                YPosition = 165
            });

            return response;
        }


        public async Task StopAsync(CancellationToken cancellationToken = default)
        {
            this.grentryClient = null;
        }
    }
}
