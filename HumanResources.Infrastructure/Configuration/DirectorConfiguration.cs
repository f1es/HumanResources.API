using HumanResources.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Configuration;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
	public void Configure(EntityTypeBuilder<Director> builder)
	{
		builder.HasKey(d => d.Id);

		builder.Property(d => d.FirstName)
			.IsRequired()
			.HasMaxLength(255);

		builder.Property(d => d.LastName)
			.IsRequired()
			.HasMaxLength(255);

		builder.Property(d => d.Birthday)
			.IsRequired();
	}
}
