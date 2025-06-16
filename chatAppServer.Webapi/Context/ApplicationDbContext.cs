using chatAppServer.Webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace chatAppServer.Webapi.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
       
        }

        public DbSet<User> Users { get; set; }
        public DbSet <Chat> Chats { get; set; }

    }
}
