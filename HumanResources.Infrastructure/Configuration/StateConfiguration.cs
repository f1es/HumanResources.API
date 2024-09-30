using HumanResources.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.Infrastructure.Configuration;

//public class StateConfiguration : IEntityTypeConfiguration<State>
//{
//	public void Configure(EntityTypeBuilder<State> builder)
//	{
//		builder.HasKey(x => x.Id);

//		builder.Property(x => x.Name)
//			.IsRequired()
//			.HasMaxLength(255);

//		builder.HasMany(x => x.Workers)
//			.WithOne(w => w.State)
//			.HasForeignKey(w => w.StateId);
//	}
//}
