using Microsoft.EntityFrameworkCore;
using GroceryListApi.Models;

namespace GroceryListApi.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor receives DbContextOptions via dependency injection
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet represents a table in the database
        public DbSet<GroceryItem> GroceryItems { get; set; }
    }
}