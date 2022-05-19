using System;
using Microsoft.EntityFrameworkCore;
using publisher.Models.AddressBook;
using publisher.Models.ContactInformation;
using publisher.Models.Report;

namespace publisher.Models
{
		public class ApplicationDbContext : DbContext
		{

			public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
			{
			}


			public DbSet<AddressBookModel> AddressBookModels { get; set; }
			public DbSet<ContactInformationModel> ContactInformationModels { get; set; }
			public DbSet<ReportModel> ReportModels { get; set; }

			protected override void OnModelCreating(ModelBuilder modelBuilder)
			{
				modelBuilder
					.Entity<ReportModel>()
					.Property(e => e.Date)
					.HasDefaultValueSql("now()");
			}


	}
	
}

