using Microsoft.EntityFrameworkCore;
using DDetective.Models;

public class EventDbContext : DbContext
{
    public EventDbContext(DbContextOptions<EventDbContext> options)
        : base(options)
    {
    }

    public DbSet<AddEventModel> Events { get; set; }
}