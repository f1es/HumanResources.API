using HumanResources.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Configuration;

public class DepartmentWorkerConfiguration : IEntityTypeConfiguration<DepartmentWorkers>
{
	public void Configure(EntityTypeBuilder<DepartmentWorkers> builder)
	{
		builder.HasKey(dw => new { dw.WorkerId, dw.DepartmentId });

		builder.HasOne(dw => dw.Department)
			.WithMany(d => d.DepartmentWorkers)
			.HasForeignKey(dw => dw.DepartmentId);

		builder.HasOne(dw => dw.Worker)
			.WithMany(w => w.DepartmentWorkers)
			.HasForeignKey(dw => dw.WorkerId);
	}
}
