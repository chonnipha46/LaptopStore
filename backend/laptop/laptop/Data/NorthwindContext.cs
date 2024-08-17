using laptop.Models;
using Microsoft.EntityFrameworkCore;

namespace labtop.Data
{
	public class NorthwindContext : DbContext
	{

		//Constructor
		public NorthwindContext(
			DbContextOptions<NorthwindContext> options) : base(options) { }

		public DbSet<laptops> laptop_data { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Mapping + จัดการ relations
			modelBuilder.Entity<laptops>().ToTable("laptop_data");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string server = "localhost";
			string database = "project";
			string uid = "root";
			string password = "12345678";
			string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
			database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";PORT=3307;SslMode=Required;";
			optionsBuilder.UseMySQL(connectionString);
		}

	}
}
