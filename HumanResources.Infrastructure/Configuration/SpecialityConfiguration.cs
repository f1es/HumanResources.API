using HumanResources.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Configuration;

public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
{
	public void Configure(EntityTypeBuilder<Speciality> builder)
	{
		builder.HasKey(s => s.Id);

		builder.Property(s => s.Name)
			.IsRequired()
			.HasMaxLength(255);
	}
}
