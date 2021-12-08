using Grentry.Control.Basic.Models;
using Grentry.Control.Basic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grentry.Control.Basic.Services
{
    public class WebsiteService : IWebsiteService
    {
        WebsiteDto actualModel;
        public WebsiteService()
        {
            actualModel = new WebsiteDto();
        }
        public async Task<WebsiteDto> GetWebsiteModelAsync()
        {
            return this.actualModel;
        }

        public async Task SetWebsiteModelAsync(WebsiteDto info)
        {
            this.actualModel = info;
        }
    }
}
