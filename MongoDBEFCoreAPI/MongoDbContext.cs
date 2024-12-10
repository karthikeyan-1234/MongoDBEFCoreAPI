using Microsoft.EntityFrameworkCore;

using MongoDB.EntityFrameworkCore.Extensions;

using MongoDBEFCoreAPI.Models;

namespace MongoDBEFCoreAPI
{
    public class MongoDbContext: DbContext
    {
        public MongoDbContext(DbContextOptions<MongoDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToCollection("Products");
        }
    }
}
