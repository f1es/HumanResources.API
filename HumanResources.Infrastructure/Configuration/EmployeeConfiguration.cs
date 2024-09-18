using HumanResources.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Infrastructure.Configuration
{
	public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.FirstName)
				.IsRequired()
				.HasMaxLength(255);

			builder.Property(e => e.LastName)
				.IsRequired()
				.HasMaxLength(255);

			builder.Property(e => e.Birthday)
				.IsRequired();
		}
	}
}
