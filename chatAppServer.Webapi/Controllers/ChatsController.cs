using chatAppServer.Webapi.Context;
using chatAppServer.Webapi.Dtos;
using chatAppServer.Webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace chatAppServer.Webapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public sealed class ChatsController(ApplicationDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            List<User> users = await context.Users.OrderBy(p => p.Name).ToListAsync();
            return Ok(users);
        }




        [HttpGet]
        public async Task<IActionResult> GetChats(Guid userId, Guid toUserId, CancellationToken cancellationToken)
        {
            List<Chat> chats = await context.Chats.Where(p => p.UserId == userId && p.ToUserId == toUserId 
            || p.ToUserId == userId && p.UserId == toUserId).OrderBy(p => p.Date).ToListAsync(cancellationToken);


            return Ok(chats);
        }


        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageDto request, CancellationToken cancellationToken)
        {
            Chat chat = new()
            {
                UserId = request.UserID,
                ToUserId = request.ToUserId,
                Message = request.Message,
                Date = DateTime.Now
            };
            await context.AddAsync(chat, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);



            return Ok();
        }
    }
}
