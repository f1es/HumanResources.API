using HumanResources.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Configuration;

public class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
{
	public void Configure(EntityTypeBuilder<Vacancy> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.ReceiptDate)
			.IsRequired();

		builder.HasOne(x => x.Profession)
			.WithMany(p => p.Vacancies)
			.HasForeignKey(x => x.ProffesionId);

		builder.HasOne(x => x.Company)
			.WithMany(c => c.Vacancies)
			.HasForeignKey(x => x.ComapnyId);
	}
}
