using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.DataAccess.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
  public void Configure(EntityTypeBuilder<Comment> builder)
  {
    builder.ToTable("Comments").HasKey(c => c.Id);
    builder.Property(c => c.Id).HasColumnName("CommentId");
    builder.Property(c => c.CreatedDate).HasColumnName("CreateTime");
    builder.Property(c => c.UpdatedDate).HasColumnName("UpdateTime");
    builder.Property(c => c.Text).HasColumnName("Text").IsRequired();
    builder.Property(c => c.PostId).HasColumnName("Post_Id");
    builder.Property(c => c.UserId).HasColumnName("User_Id");

    builder.HasOne(c => c.User)
      .WithMany(u => u.Comments)
      .HasForeignKey(c => c.UserId)
      .OnDelete(DeleteBehavior.NoAction);

    builder.HasOne(p => p.Post)
      .WithMany(c => c.Comments)
      .HasForeignKey(p => p.PostId)
      .OnDelete(DeleteBehavior.NoAction);

    builder.HasData(new Comment()
    {
      Id = new Guid("E329227C-EE67-409A-B64E-46A7BE585E89"),
      CreatedDate = new DateTime(2024, 10, 17, 11, 15, 0),
      Text = "Çok güzel bir yazı.",
      PostId = new Guid("702FE6EF-9DBA-4219-B8A5-3A710E128E39"),
      UserId = 2
    },
    new Comment()
    {
      Id = new Guid("58124570-A62A-4297-A6EA-C6A5A79C931A"),
      CreatedDate = new DateTime(2024, 10, 19, 16, 45, 0),
      Text = "Yazıyı beğenmedim.",
      PostId = new Guid("A0340A0C-A702-4B19-B808-FCE464311F43"),
      UserId = 3
    });
  }
}
