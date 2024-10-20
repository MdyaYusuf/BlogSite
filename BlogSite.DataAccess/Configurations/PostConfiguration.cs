using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.DataAccess.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
  public void Configure(EntityTypeBuilder<Post> builder)
  {
    builder.ToTable("Posts").HasKey(c => c.Id);
    builder.Property(p => p.Id).HasColumnName("PostId");
    builder.Property(p => p.CreatedDate).HasColumnName("CreateTime");
    builder.Property(p => p.UpdatedDate).HasColumnName("UpdateTime");
    builder.Property(p => p.Title).HasColumnName("Title");
    builder.Property(p => p.Content).HasColumnName("Content");
    builder.Property(p => p.AuthorId).HasColumnName("Author_Id");
    builder.Property(p => p.CategoryId).HasColumnName("Category_Id");

    builder.HasOne(p => p.Author)
      .WithMany(a => a.Posts)
      .HasForeignKey(p => p.AuthorId)
      .OnDelete(DeleteBehavior.NoAction);

    builder.HasOne(p => p.Category)
      .WithMany(c => c.Posts)
      .HasForeignKey(p => p.CategoryId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasMany(p => p.Comments)
      .WithOne(c => c.Post)
      .HasForeignKey(c => c.PostId)
      .OnDelete(DeleteBehavior.NoAction);

    builder.HasData(new Post()
    {
      Id = new Guid("702FE6EF-9DBA-4219-B8A5-3A710E128E39"),
      CreatedDate = new DateTime(2024, 10, 20, 10, 0, 0),
      Title = "Exploring the Power of C# in Modern Software Development",
      Content = "C# is a versatile and powerful programming language that has become a cornerstone of modern software development. Developed by Microsoft, C# is known for its robustness, simplicity, and efficiency, making it a popular choice for building a wide range of applications, from web and mobile apps to desktop software and games. One of the key strengths of C# lies in its strong typing and object-oriented nature, which promotes clear and maintainable code. With features like Language Integrated Query (LINQ), async/await for asynchronous programming, and the powerful .NET ecosystem, C# enables developers to write high-performance, scalable applications.",
      CategoryId = 1,
      AuthorId = 1
    },
    new Post()
    {
      Id = new Guid("94EBF6EC-9264-4C8E-B27F-428C1DFA3867"),
      CreatedDate = new DateTime(2024, 10, 12, 19, 0, 0),
      Title = "JavaScript: The Dynamic Heart of Web Development",
      Content = "JavaScript is the cornerstone of modern web development, infusing interactivity and dynamism into web pages. From simple scripts that handle form validations to complex frameworks and libraries like React and Angular, JavaScript powers the responsive and engaging experiences users expect from contemporary websites. It allows developers to create real-time updates, handle asynchronous operations, and manipulate the DOM, making web applications more user-friendly and efficient.",
      CategoryId = 2,
      AuthorId = 5
    },
    new Post()
    {
      Id = new Guid("53E2D227-BFF2-4588-9E89-541CCCFB9E02"),
      CreatedDate = new DateTime(2024, 10, 14, 8, 30, 0),
      Title = "React: Building Interactive User Interfaces",
      Content = "React is a powerful library for building user interfaces, developed by Facebook. It’s particularly well-suited for creating dynamic and interactive web applications. With its component-based architecture, React allows developers to break down complex UIs into manageable, reusable pieces. This modular approach enhances maintainability and scalability. React’s virtual DOM ensures efficient updates and rendering, boosting performance. By embracing a declarative style, React makes it easier to reason about the state of your application and predict its behavior.",
      CategoryId = 3,
      AuthorId = 3
    },
    new Post()
    {
      Id = new Guid("284A37EC-2675-4FA0-BCA5-BECC691ABD63"),
      CreatedDate = new DateTime(2024, 10, 17, 14, 45, 0),
      Title = "HTML: The Foundation of the Web",
      Content = "HTML, or HyperText Markup Language, is the fundamental building block of the web. It provides the structure and semantics for web content, defining elements like headings, paragraphs, links, and images. HTML is crucial for ensuring that web pages are accessible and searchable. It works seamlessly with CSS and JavaScript to create rich, interactive web experiences. Understanding HTML is essential for any web developer, as it forms the basis upon which all web technologies are built.",
      CategoryId = 5,
      AuthorId = 4
    },
    new Post()
    {
      Id = new Guid("A0340A0C-A702-4B19-B808-FCE464311F43"),
      CreatedDate = new DateTime(2024, 10, 19, 11, 15, 0),
      Title = "Bootstrap: Streamlining Responsive Web Design",
      Content = "Bootstrap is a powerful front-end framework that simplifies the development of responsive and mobile-first websites. With its grid system, pre-styled components, and utility classes, Bootstrap makes it easy to create layouts that adapt to different screen sizes and devices. It includes a variety of customizable UI elements like buttons, modals, and navigation bars, allowing developers to build polished and professional-looking websites quickly. Bootstrap’s extensive documentation and community support make it a go-to choice for both beginners and experienced developers.",
      CategoryId = 4,
      AuthorId = 2
    });

    // Linq ile include yapmaya gerek bırakmaz.
    builder.Navigation(p => p.Author).AutoInclude();
    builder.Navigation(p => p.Category).AutoInclude();
    builder.Navigation(p => p.Comments).AutoInclude();
  }
}
