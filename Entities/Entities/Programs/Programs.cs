using System.ComponentModel.DataAnnotations;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public class Programs : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    public List<Archive> Archives { get; set; }
}
#region relations
public class ProgramsTypeConfiguration : IEntityTypeConfiguration<Programs>
{
    public void Configure(EntityTypeBuilder<Programs> builder)
    {
        builder.HasMany(a => a.Archives)
            .WithOne(b => b.Programs)
            .HasForeignKey(c => c.programsId);
    }
}
#endregion