using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.DataAccess.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    // Hepsini yazmamız ve custom nameler belirlememiz beklenir.
    builder.ToTable("Categories").HasKey(c => c.Id);
    builder.Property(c => c.Id).HasColumnName("CategoryId");
    builder.Property(c => c.CreatedDate).HasColumnName("CreateTime");
    builder.Property(c => c.UpdatedDate).HasColumnName("UpdateTime");
    builder.Property(c => c.Name).HasColumnName("CategoryName");
    builder
      .HasMany(c => c.Posts)
      .WithOne(p => p.Category)
      .HasForeignKey(c => c.CategoryId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasData(new Category()
    {
      Id = 1,
      Name = "Csharp",
      CreatedDate = new DateTime(2022, 5, 1, 14, 30, 0)
    },
    new Category()
    {
      Id = 2,
      Name = "Javascript",
      CreatedDate = new DateTime(2023, 1, 15, 9, 0, 0)
    },
    new Category()
    {
      Id = 3,
      Name = "React",
      CreatedDate = new DateTime(2021, 12, 25, 18, 45, 0)
    },
    new Category()
    {
      Id = 4,
      Name = "Bootstrap",
      CreatedDate = new DateTime(2024, 7, 10, 23, 59, 59)
    },
    new Category()
    {
      Id = 5,
      Name = "Html",
      CreatedDate = new DateTime(2020, 3, 20, 0, 0, 0)
    });
  }
}
