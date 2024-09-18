using HumanResources.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Configuration
{
	public class ProfessionConfiguration : IEntityTypeConfiguration<Profession>
	{
		public void Configure(EntityTypeBuilder<Profession> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(255);

			builder.Property(x => x.Salary)
				.IsRequired();

			builder.HasMany(x => x.Vacancies)
				.WithOne(v => v.Profession)
				.HasForeignKey(v => v.ProffesionId);
		}
	}
}
