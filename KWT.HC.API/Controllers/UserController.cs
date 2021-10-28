using System;
using System.Threading.Tasks;
using EDT_Contract.Controller;
using KWT.HC.API.Manager.Contract;
using KWT.HC.API.Model;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KWT.HC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseSQLController<HC_UserModel, Guid, IUserManager>
    {
        public UserController(IUserManager manager, ILogger<UserController> logger, TelemetryClient telemetry) : base(manager, logger, telemetry)
        {
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<HC_UserModel>> GetModelByName(string email)
        {
            try
            {
                return Ok(await _manager.GetUserByEmail(email));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To retrieve Model, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<HC_UserModel>> DeleteModelById(Guid id)
        {
            try
            {
                return Ok(await _manager.DeleteUser(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed To retrieve Model, LogTrackerId:{TrackException(ex)}");
            }
        }
    }
}
