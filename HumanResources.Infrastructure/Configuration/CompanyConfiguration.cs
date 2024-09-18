using HumanResources.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Configuration;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
	public void Configure(EntityTypeBuilder<Company> builder)
	{
		builder.HasKey(c => c.Id);

		builder.Property(c => c.Name)
			.IsRequired()
			.HasMaxLength(255);

		builder.HasOne(c => c.Director)
			.WithOne(d => d.Company)
			.HasForeignKey<Director>(d => d.CompanyId);

		builder.HasMany(c => c.Departments)
			.WithOne(d => d.Company)
			.HasForeignKey(d => d.CompanyID);

		builder.HasMany(c => c.Vacancies)
			.WithOne(v => v.Company)
			.HasForeignKey(v => v.ComapnyId);
	}
}
