using chatAppServer.Webapi.Context;
using chatAppServer.Webapi.Dtos;
using chatAppServer.Webapi.Models;
using GenericFileService.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace chatAppServer.Webapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public sealed class AuthController(ApplicationDbContext context) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto request, CancellationToken cancellationToken)
        {

            bool isNameExist = await context.Users.AnyAsync(p => p.Name == request.Name, cancellationToken);

            if (isNameExist)
            {
                return BadRequest(new { Message = "Bu kullanıcı adı daha önce kullanılmıştır" });
            }

            string avatar = FileService.FileSaveToServer(request.File, "wwroot/avatar/");
            User user = new()
            {
                Name = request.Name,
                Avatar=avatar
            };

            await context.AddAsync(user, cancellationToken);
            await context.SaveChangesAsync();


            return NoContent();
        }











    }
}
