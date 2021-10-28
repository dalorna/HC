using System;
using System.Threading.Tasks;
using EDT_Contract.Controller;
using KWT.HC.API.Model;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using KWT.HC.API.Manager.Contract;
using KWT.HC.API.Entity;
using System.Collections.Generic;

namespace KWT.HC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : BaseSQLController<ScheduleModel, int, IScheduleManager>
    {
        public ScheduleController(IScheduleManager manager, ILogger<ScheduleController> logger, TelemetryClient telemetry) : base(manager, logger, telemetry)
        {
        }

        [HttpDelete("Schedule/{scheduleId}")]
        public async Task<ActionResult<bool>> DeleteSchedule(int scheduleId)
        {
            try
            {
                return Ok(await _manager.DeleteScheduleById(scheduleId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed DeleteSchedule, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpDelete("ScheduleTurbine/{scheduleId}/{turbineId}")]
        public async Task<ActionResult<bool>> DeleteScheduleTurbine(int scheduleId, int turbineId)
        {
            try
            {
                return Ok(await _manager.DeleteScheduleTurbineById(scheduleId, turbineId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed DeleteScheduleTurbine, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("ScheduleTurbine/Schedule/{scheduleId}")]
        public async Task<ActionResult<ScheduleTurbineModel>> GetScheduleTurbineModelsByScheduleId(int scheduleId)
        {
            try
            {
                return Ok(await _manager.GetScheduleTurbineModelsByScheduleId(scheduleId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed GetScheduleTurbineModelsByScheduleId, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("ScheduleTurbine/Turbine/{turbineId}")]
        public async Task<ActionResult<ScheduleTurbineModel>> GetScheduleTurbineModelsByTurbineId(int turbineId)
        {
            try
            {
                return Ok(await _manager.GetScheduleTurbineModelsByTurbineId(turbineId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed GetScheduleTurbineModelsByTurbineId, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("ScheduleTurbine")]
        public async Task<ActionResult<ScheduleTurbineModel>> GetScheduleTurbine()
        {
            try
            {
                return Ok(await _manager.GetScheduleTurbineModels());
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed GetScheduleTurbine, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpPost("SaveScheduleTurbine")]
        public async Task<ActionResult<ScheduleTurbineModel>> SaveScheduleTurbine(ScheduleTurbineModel model)
        {
            try
            {
                return Ok(await _manager.SaveScheduleTurbine(model));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed SaveScheduleTurbine, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("GetScheduleDay/{scheduleId}")]
        public async Task<ActionResult<List<ScheduleDayModel>>> GetScheduleDaysModelByScheduleId(int scheduleId)
        {
            try
            {
                return Ok(await _manager.GetScheduleDaysModelByScheduleId(scheduleId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed GetScheduleDay, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpPost("SaveScheduleDay")]
        public async Task<ActionResult<ScheduleDayModel>> SaveScheduleDay(ScheduleDayModel model)
        {
            try
            {
                return Ok(await _manager.SaveScheduleDay(model));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed SaveScheduleDay, LogTrackerId:{TrackException(ex)}");
            }
        }
    
        [HttpPut("UpdateScheduleDay")]
        public async Task<ActionResult<ScheduleDayModel>> UpdateScheduleDay(ScheduleDayModel model)
        {
            try
            {
                return Ok(await _manager.UpdateScheduleDay(model));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed UpdateScheduleDay, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpPost("CopySchedule")]
        public async Task<ActionResult<bool>> CopySchedule(ScheduleModel schedule)
        {
            try
            {
                return Ok(await _manager.CopySchedule(schedule));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed CopySchedule, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpPost("addDay")]
        public async Task<ActionResult<bool>> AddDay(ScheduleDayModel addDay)
        {
            try
            {
                return Ok(await _manager.AddDay(addDay));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed CopySchedule, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpPost("deleteDay")]
        public async Task<ActionResult<bool>> DeleteDay(ScheduleDayModel addDay)
        {
            try
            {
                return Ok(await _manager.DeleteDay(addDay));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed CopySchedule, LogTrackerId:{TrackException(ex)}");
            }
        }
    }
}
