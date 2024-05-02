using DemoApplicationWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApplicationWeb.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options) { 

        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
