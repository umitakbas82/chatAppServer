using Microsoft.EntityFrameworkCore;

namespace chatAppServer.Webapi.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
       
        }
    }
}
