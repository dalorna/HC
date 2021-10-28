using EDT_Contract.Controller;
using KWT.HC.API.Model;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using KWT.HC.API.Manager.Contract;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;

namespace KWT.HC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoController : BaseSQLController<LogoModel, int, ILogoManager>
    {
        public LogoController(ILogoManager manager, ILogger<LogoController> logger, TelemetryClient telemetry) : base(manager, logger, telemetry)
        {
        }

        [HttpPost("upload/{name}")]
        public async Task<ActionResult<bool>> UploadLogo(IFormFile formFile, string name)
        {
            try
            {
                return Ok(await _manager.UploadLogoFile(formFile, name));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed UploadLogo, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpPatch("update/{logoId}/{name}")]
        public async Task<ActionResult<bool>> UploadLogo(IFormFile formFile, int logoId, string name)
        {
            try
            {
                return Ok(await _manager.UpdateLogoFile(formFile, logoId, name));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed UploadLogo, LogTrackerId:{TrackException(ex)}");
            }
        }

        [HttpDelete("deleteLogo/{logoId}")]
        public async Task<ActionResult<bool>> DeleteLogo (int logoId)
        {
            try
            {
                return Ok(await _manager.DeleteLogo(logoId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed UploadLogo, LogTrackerId:{TrackException(ex)}");
            }
        }
    }
}
