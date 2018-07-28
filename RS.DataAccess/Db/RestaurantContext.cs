using Microsoft.EntityFrameworkCore;
using RS.Entities.Entity;

namespace RS.DataAccess.Db
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<SecondaryServicesMenu> SecondaryServicesMenus { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<HookahMenu> HookahMenus { get; set; }
        public DbSet<FoodMenu> FoodMenus { get; set; }
        public DbSet<BarMenu> BarMenus { get; set; }
        public DbSet<Share> Shares { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().HasMany(s => s.FoodMenus).WithOne(s => s.Menu);
        }
    }
}
