using EDT_Contract.Controller;
using KWT.HC.API.Model;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using KWT.HC.API.Manager.Contract;
using System;
using System.Threading.Tasks;

namespace KWT.HC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphOptionController : BaseSQLController<GraphOptionModel, int, IGraphOptionManager>
    {
        public GraphOptionController(IGraphOptionManager manager, ILogger<GraphOptionController> logger, TelemetryClient telemetry) : base(manager, logger, telemetry)
        {
        }

        [HttpGet("options/{optionType}")]
        public async Task<ActionResult<GraphOptionModel>> GetOptionsByType(string optionType)
        {
            try
            {
                return Ok(await _manager.GetOptionsByType(optionType));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To retrieve Model, LogTrackerId:{TrackException(ex)}");

            }
        }
    }
}