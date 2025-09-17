using Microsoft.EntityFrameworkCore;
using TaskAplication.Models;

namespace TaskAplication.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Tasca> Tasks { get; set; }
        public DbSet<Persona> Persones { get; set; }

    }
}
