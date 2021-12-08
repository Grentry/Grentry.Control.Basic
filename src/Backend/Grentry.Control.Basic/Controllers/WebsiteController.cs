using Grentry.Control.Basic.Models;
using Grentry.Control.Basic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grentry.Control.Basic.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class WebsiteController : ControllerBase
    {
        private readonly ILogger<WebsiteController> _logger;
        private readonly IWebsiteService _websiteService;

        public WebsiteController(
            ILogger<WebsiteController> logger,
            IWebsiteService websiteService)
        {
            this._logger = logger;
            this._websiteService = websiteService;
        }

        [HttpGet]
        public async Task<ActionResult<WebsiteDto>> GetCategoriesAsync()
        {
            var response = await this._websiteService.GetWebsiteModelAsync();
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
