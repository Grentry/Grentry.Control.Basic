using Grentry.Control.Basic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grentry.Control.Basic.Services.Interfaces
{
    public interface IWebsiteService
    {
        Task SetWebsiteModelAsync(WebsiteDto info);
        Task<WebsiteDto> GetWebsiteModelAsync();
    }
}
