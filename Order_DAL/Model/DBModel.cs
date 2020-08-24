namespace Order_DAL.Model
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class DBModel : DbContext
	{
		public DBModel()
			: base("name=DBModel")
		{
		}

		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>()
				.HasMany(e => e.Orders)
				.WithRequired(e => e.Customer)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Order>()
				.Property(e => e.Amount)
				.HasPrecision(18, 5);

			modelBuilder.Entity<Order>()
				.Property(e => e.VAT)
				.HasPrecision(18, 5);
		}
	}
}
