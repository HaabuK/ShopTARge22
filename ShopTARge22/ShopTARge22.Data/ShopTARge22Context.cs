using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.Domain;

namespace ShopTARge22.Data
{
	public class ShopTARge22Context : IdentityDbContext<ApplicationUser>
	{
		public ShopTARge22Context(DbContextOptions<ShopTARge22Context> options) : base(options)
		{
		}

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToApi> FileToApis { get; set; }
		public DbSet<RealEstate> RealEstates { get; set; }
		public DbSet<FileToDatabase> FileToDatabases { get; set; }
        public DbSet<Kindergarten> Kindergartens { get; set; }

		public DbSet<IdentityRole> identityRoles { get; set; }

    }
	
}

