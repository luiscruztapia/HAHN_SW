using Customers.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Customers.Infra.Context
{
    public class AppDbContext : DbContext
    {
         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}