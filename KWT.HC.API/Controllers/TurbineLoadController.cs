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
    public class TurbineLoadController : BaseSQLController<TurbineLoadModel, int, ITurbineLoadManager>
    {
        public TurbineLoadController(ITurbineLoadManager manager, ILogger<TurbineLoadController> logger, TelemetryClient telemetry) : base(manager, logger, telemetry)
        {
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<TurbineLoad>> DeleteModelById(int id)
        {
            try
            {
                return Ok(await _manager.DeleteById(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To delete Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpDelete("delete/turbineTime/{turbineTimeId}")]
        public async Task<ActionResult<TurbineLoad>> DeleteTurbineTime(int turbineTimeId)
        {
            try
            {
                return Ok(await _manager.DeleteTurbineTime(turbineTimeId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To delete Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpPost("delete/turbineTimes")]
        public async Task<ActionResult<TurbineLoad>> DeleteTurbineTimes(List<int> turbineTimeIds)
        {
            try
            {
                return Ok(await _manager.DeleteTurbineTimes(turbineTimeIds));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To delete Models, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpDelete("deleteload/{turbineId}")]
        public async Task<ActionResult<TurbineLoad>> DeleteLoadByTurbineId(int turbineId)
        {
            try
            {
                return Ok(await _manager.DeleteByTurbineId(turbineId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To deleteload Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("byturbine/{turbineId}")]
        public async Task<ActionResult<TurbineLoad>> GetByTurbineId(int turbineId)
        {
            try
            {
                return Ok(await _manager.GetLoadsByTurbineId(turbineId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To retrieve byturbine Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("byScheduleId/{scheduleId}")]
        public async Task<ActionResult<TurbineLoad>> GetByScheduleID(int scheduleId)
        {
            try
            {
                return Ok(await _manager.GetLoadsByScheduleId(scheduleId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To retrieve byScheduleId Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("turbineTimeSchedule/{ScheduleId}")]
        public async Task<ActionResult<List<TurbineTimeModel>>> GetTurbineTimeByScheduleId(int ScheduleId)
        {
            try
            {
                return Ok(await _manager.GetTurbineTimeByScheduleId(ScheduleId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To retrieve byturbine Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("turbineTimeScheduleDay/{ScheduleDayId}")]
        public async Task<ActionResult<List<TurbineTimeModel>>> GetTurbineTimeByScheduleDayId(int ScheduleDayId)
        {
            try
            {
                return Ok(await _manager.GetTurbineTimeByScheduleDayId(ScheduleDayId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To retrieve turbineTimeScheduleDay Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpPost("turbineTime")]
        public async Task<ActionResult<TurbineTimeModel>> SaveTurbineTime(TurbineTimeModel model)
        {
            try
            {
                return Ok(await _manager.SaveTurbineTime(model));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To SaveTurbineTime Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpPut("turbineTime")]
        public async Task<ActionResult<TurbineTimeModel>> UpdateTurbineTime(TurbineTimeModel model)
        {
            try
            {
                return Ok(await _manager.UpdateTurbineTime(model));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To UpdateTurbineTime Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("data/{ScheduleId}/{day}")]
        public async Task<ActionResult<List<TurbineDataModel>>> GetTurbineTimeData(int ScheduleId, int day)
        {
            try
            {
                return Ok(await _manager.GetTurbineTimeData(ScheduleId, day));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To retrieve turbineTimeScheduleDay Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("dataByScheduleId/{ScheduleId}")]
        public async Task<ActionResult<List<TurbineDataModel>>> GetTurbineTimeData(int ScheduleId)
        {
            try
            {
                return Ok(await _manager.GetTurbineTimeData(ScheduleId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To retrieve turbineTimeScheduleDay Model, LogTrackerId:{TrackException(ex)}");
            }
        }
       
        [HttpGet("totalHours/{ScheduleId}/{day}")]
        public async Task<ActionResult<List<TurbineHourModel>>> GetTurbineHourData(int ScheduleId, int day)
        {
            try
            {
                return Ok(await _manager.GetTurbineHourData(ScheduleId, day));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To retrieve turbineTimeScheduleDay Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("totalHoursByScheduleId/{ScheduleId}")]
        public async Task<ActionResult<List<TurbineHourModel>>> GetTurbineHourDataByScheduleId(int ScheduleId)
        {
            try
            {
                return Ok(await _manager.GetTurbineHourDataByScheduleId(ScheduleId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To retrieve turbineTimeScheduleDay Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpPost("turbineTimes")]
        public async Task<ActionResult<TurbineTimeModel>> SaveTurbineTimes(List<TurbineTimeModel> model)
        {
            try
            {
                return Ok(await _manager.SaveTurbineTimes(model));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To SaveTurbineTime Model, LogTrackerId:{TrackException(ex)}");
            }
        }
    }
}
