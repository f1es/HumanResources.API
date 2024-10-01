using HumanResources.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Configuration
{
	public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
	{
		public void Configure(EntityTypeBuilder<Worker> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.FirstName)
				.IsRequired()
				.HasMaxLength(255);

			builder.Property(x => x.LastName)
				.IsRequired()
				.HasMaxLength(255);

			builder.Property(x => x.Birthday)
				.IsRequired()
				.HasMaxLength(255);

			builder.HasMany(x => x.Departments)
				.WithMany(d => d.Workers);
		}
	}
}
