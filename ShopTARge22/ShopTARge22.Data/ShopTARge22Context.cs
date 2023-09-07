using Microsoft.EntityFrameworkCore;

namespace ShopTARge22.Data
{
	public class ShopTARge22Context : DbContext
	{
		public ShopTARge22Context(DbContextOptions<ShopTARge22Context> options) : base(options)
		{
		}

		public DbSet<Spaceship> Spaceships { get; set; }
	}
}

