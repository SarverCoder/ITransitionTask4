using Microsoft.EntityFrameworkCore;
using UserManager.Domain.Entities;

namespace UserManager.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {
        }

        public DbSet<User> Users { get; set; }


    }
}
