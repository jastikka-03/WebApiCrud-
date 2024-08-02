using CrudWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Database
{
    public class EmplyoyeeDbContext : DbContext
    {
        public EmplyoyeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
