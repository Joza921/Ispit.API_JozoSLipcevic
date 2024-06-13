using Ispit.API.Models.Dbo;
using Microsoft.EntityFrameworkCore;

namespace Ispit.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<TodoList> TodoLists { get; set; }
    }
}
