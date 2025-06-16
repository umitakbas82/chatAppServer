using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chatAppServer.Webapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public sealed class AuthController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto request, CancellationToken cancellationToken)
        {
            return NoContent();
        }
    }
}
