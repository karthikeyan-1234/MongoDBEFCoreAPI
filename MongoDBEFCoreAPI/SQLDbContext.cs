using Microsoft.EntityFrameworkCore;

using MongoDB.EntityFrameworkCore.Extensions;

using MongoDBEFCoreAPI.Models;


namespace MongoDBEFCoreAPI
{
    public class SQLDbContext:DbContext
    {
        public SQLDbContext(DbContextOptions<SQLDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
