using Microsoft.EntityFrameworkCore;
using DDetective.Models;

namespace DDetective.Data
{
    public class SessionDbContext : DbContext
    {
        public SessionDbContext(DbContextOptions<SessionDbContext> options)
            : base(options) { }

        public DbSet<SessionModel> Session { get; set; }
    }

}