using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SignalRBasicSetup.Controllers
{
    [Route("api/signalRController")]
    [ApiController]
    [EnableCors("ReactCORS")]
    public class SignalRController : ControllerBase
    {
   
        private readonly SignalR _signalR;
        public SignalRController(SignalR signalR)
        {
            _signalR = signalR;
        }

        [HttpGet]
        [Route("count")]
        public async Task<ActionResult> GetCount([FromQuery] int value)
        {
            int result = await _signalR.GetUpdatedCount(value);
            return Ok(result);
        }
    }
}
