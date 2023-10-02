using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoleBased.Model;
using RoleBased.Shared.Enums;

namespace RoleBased.Infractructure.Presistance.Configurations;

public class LoginDbConfiguration : IEntityTypeConfiguration<LoginDb_M>
{
    public void Configure(EntityTypeBuilder<LoginDb_M> builder)
    {
        builder.ToTable("LoginDb");
        builder.HasKey(x => x.RegNo);
        builder.HasIndex(x => x.RegNo);
    }
}
