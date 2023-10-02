using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoleBased.Model;
using RoleBased.Shared.Enums;
using System.Numerics;

namespace RoleBased.Infractructure.Presistance.Configurations;

public class StudentInfoDbConfiguration : IEntityTypeConfiguration<StudentInfo_M>
{
    public void Configure(EntityTypeBuilder<StudentInfo_M> builder)
    {
        builder.ToTable("StudentInfo");
        builder.HasKey(x => x.RegNo);
        builder.HasIndex(x => x.Name);
    }
}
