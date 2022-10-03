using JobService.Models;
using Microsoft.EntityFrameworkCore;

namespace JobService.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
            base(options) { }

        public DbSet<User> Users { get; set; }

    }
}
