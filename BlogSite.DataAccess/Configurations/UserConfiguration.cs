using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.ToTable("Users").HasKey(u => u.Id);
    builder.Property(u => u.Id).HasColumnName("UserId");
    builder.Property(u => u.FirstName).HasColumnName("FirstName");
    builder.Property(u => u.LastName).HasColumnName("LastName");
    builder.Property(u => u.Email).HasColumnName("Email");
    builder.Property(u => u.Username).HasColumnName("Username");
    builder.Property(u => u.Password).HasColumnName("Password");

    builder.HasMany(u => u.Posts)
      .WithOne(p => p.Author)
      .HasForeignKey(p => p.AuthorId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasMany(u => u.Comments)
      .WithOne(c => c.User)
      .HasForeignKey(c => c.UserId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasData(new User()
    {
        Id = 1,
        CreatedDate = new DateTime(2024, 10, 5, 12, 0, 0),
        FirstName = "Muhammed Yusuf",
        LastName = "Aydın",
        Email = "myusuf@gmail.com",
        Username = "myusuf",
        Password = "12345!61"
    },
    new User()
    {
        Id = 2,
        CreatedDate = new DateTime(2024, 10, 10, 17, 15, 0),
        FirstName = "Esra",
        LastName = "Yılmaz",
        Email = "eyilmaz@gmail.com",
        Username = "esraylmz",
        Password = "esra123!"
    },
    new User()
    {
        Id = 3,
        CreatedDate = new DateTime(2024, 10, 15, 9, 45, 0),
        FirstName = "Berk",
        LastName = "Aydoğdu",
        Email = "berk@gmail.com",
        Username = "berkayd",
        Password = "berk456!"
    },
    new User()
    {
        Id = 4,
        CreatedDate = new DateTime(2024, 10, 18, 15, 30, 0),
        FirstName = "Öznur",
        LastName = "Altın",
        Email = "öznur@gmail.com",
        Username = "oznuraltn",
        Password = "öznur789!"
    },
    new User()
    {
        Id = 5,
        CreatedDate = new DateTime(2024, 10, 20, 10, 0, 0),
        FirstName = "Fatih",
        LastName = "Şan",
        Email = "fatih@gmail.com",
        Username = "fatihsn",
        Password = "fatih246!"
    });
  }
}
