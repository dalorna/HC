using EDT_Contract.Controller;
using KWT.HC.API.Model;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using KWT.HC.API.Manager.Contract;
using System.Threading.Tasks;
using System;

namespace KWT.HC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityNoteController : BaseSQLController<ActivityNoteModel, int, IActivityNoteManager>
    {
        public ActivityNoteController(IActivityNoteManager manager, ILogger<ActivityNoteController> logger, TelemetryClient telemetry) : base(manager, logger, telemetry)
        {
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteModelById(int id)
        {
            try
            {
                return Ok(await _manager.DeleteActivityNoteById(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To retrieve Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpDelete("schedule/{scheduleId}")]
        public async Task<ActionResult<bool>> DeleteActivityNoteByScheduleDayId(int scheduleId)
        {
            try
            {
                return Ok(await _manager.DeleteActivityNoteByScheduleDayId(scheduleId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To retrieve Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("schedule/{scheduleDayId}")]
        public async Task<ActionResult<ActivityNoteStyleModel>> GetActivityNoteByScheduleDayId(int scheduleDayId)
        {
            try
            {
                return Ok(await _manager.GetActivityNoteByScheduleDayId(scheduleDayId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed GetScheduleTurbineModelsByScheduleId, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("scheduleById/{scheduleId}")]
        public async Task<ActionResult<ActivityNoteStyleModel>> GetActivityNoteStyleByScheduleId(int scheduleId)
        {
            try
            {
                return Ok(await _manager.GetActivityNoteStyleByScheduleId(scheduleId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed GetActivityNoteStyleByScheduleId, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("position/{scheduleDayId}/{position}/{forward}")]
        public async Task<ActionResult<int>> updateNotePosition(int scheduleDayId, int position, bool forward)
        {

            try
            {
                return Ok(await _manager.updateNotePosition(scheduleDayId, position, forward));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed updateNotePosition, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpGet("paste/{fromScheduleDayId}/{toScheduleDayId}")]
        public async Task<ActionResult<int>> pasteAllNotes(int fromScheduleDayId, int toScheduleDayId)
        {

            try
            {
                return Ok(await _manager.pasteAllNotes(fromScheduleDayId, toScheduleDayId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed updateNotePosition, LogTrackerId:{TrackException(ex)}");
            }
        }
    }
}
