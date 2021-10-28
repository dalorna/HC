using System;
using System.Threading.Tasks;
using EDT_Contract.Controller;
using KWT.HC.API.Model;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using KWT.HC.API.Manager.Contract;
using KWT.HC.API.Entity;

namespace KWT.HC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurbineController : BaseSQLController<TurbineModel, int, ITurbineManager>
    {
        public TurbineController(ITurbineManager manager, ILogger<TurbineController> logger, TelemetryClient telemetry) : base(manager, logger, telemetry)
        {
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Turbine>> DeleteModelById(int id)
        {
            try
            {
                return Ok(await _manager.DeleteById(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To retrieve Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("turbinesByScheduleId/{scheduleId}")]
        public async Task<ActionResult<ScheduleTurbineModel>> GetTurbinesByScheduleId(int scheduleId)
        {
            try
            {
                return Ok(await _manager.GetTurbinesByScheduleId(scheduleId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed GetScheduleTurbineModelsByScheduleId, LogTrackerId:{TrackException(ex)}");
            }
        }
    }
}
