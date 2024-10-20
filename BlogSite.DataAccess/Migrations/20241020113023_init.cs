using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogSite.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Post_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_Id = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_Post_Id",
                        column: x => x.Post_Id,
                        principalTable: "Posts",
                        principalColumn: "PostId");
                    table.ForeignKey(
                        name: "FK_Comments_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreateTime", "CategoryName", "UpdateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Csharp", null },
                    { 2, new DateTime(2023, 1, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "Javascript", null },
                    { 3, new DateTime(2021, 12, 25, 18, 45, 0, 0, DateTimeKind.Unspecified), "React", null },
                    { 4, new DateTime(2024, 7, 10, 23, 59, 59, 0, DateTimeKind.Unspecified), "Bootstrap", null },
                    { 5, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Html", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedDate", "Email", "FirstName", "LastName", "Password", "UpdatedDate", "Username" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 10, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "myusuf@gmail.com", "Muhammed Yusuf", "Aydın", "12345!61", null, "myusuf" },
                    { 2L, new DateTime(2024, 10, 10, 17, 15, 0, 0, DateTimeKind.Unspecified), "eyilmaz@gmail.com", "Esra", "Yılmaz", "esra123!", null, "esraylmz" },
                    { 3L, new DateTime(2024, 10, 15, 9, 45, 0, 0, DateTimeKind.Unspecified), "berk@gmail.com", "Berk", "Aydoğdu", "berk456!", null, "berkayd" },
                    { 4L, new DateTime(2024, 10, 18, 15, 30, 0, 0, DateTimeKind.Unspecified), "öznur@gmail.com", "Öznur", "Altın", "öznur789!", null, "oznuraltn" },
                    { 5L, new DateTime(2024, 10, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "fatih@gmail.com", "Fatih", "Şan", "fatih246!", null, "fatihsn" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author_Id", "Category_Id", "Content", "CreateTime", "Title", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("284a37ec-2675-4fa0-bca5-becc691abd63"), 4L, 5, "HTML, or HyperText Markup Language, is the fundamental building block of the web. It provides the structure and semantics for web content, defining elements like headings, paragraphs, links, and images. HTML is crucial for ensuring that web pages are accessible and searchable. It works seamlessly with CSS and JavaScript to create rich, interactive web experiences. Understanding HTML is essential for any web developer, as it forms the basis upon which all web technologies are built.", new DateTime(2024, 10, 17, 14, 45, 0, 0, DateTimeKind.Unspecified), "HTML: The Foundation of the Web", null },
                    { new Guid("53e2d227-bff2-4588-9e89-541cccfb9e02"), 3L, 3, "React is a powerful library for building user interfaces, developed by Facebook. It’s particularly well-suited for creating dynamic and interactive web applications. With its component-based architecture, React allows developers to break down complex UIs into manageable, reusable pieces. This modular approach enhances maintainability and scalability. React’s virtual DOM ensures efficient updates and rendering, boosting performance. By embracing a declarative style, React makes it easier to reason about the state of your application and predict its behavior.", new DateTime(2024, 10, 14, 8, 30, 0, 0, DateTimeKind.Unspecified), "React: Building Interactive User Interfaces", null },
                    { new Guid("702fe6ef-9dba-4219-b8a5-3a710e128e39"), 1L, 1, "C# is a versatile and powerful programming language that has become a cornerstone of modern software development. Developed by Microsoft, C# is known for its robustness, simplicity, and efficiency, making it a popular choice for building a wide range of applications, from web and mobile apps to desktop software and games. One of the key strengths of C# lies in its strong typing and object-oriented nature, which promotes clear and maintainable code. With features like Language Integrated Query (LINQ), async/await for asynchronous programming, and the powerful .NET ecosystem, C# enables developers to write high-performance, scalable applications.", new DateTime(2024, 10, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "Exploring the Power of C# in Modern Software Development", null },
                    { new Guid("94ebf6ec-9264-4c8e-b27f-428c1dfa3867"), 5L, 2, "JavaScript is the cornerstone of modern web development, infusing interactivity and dynamism into web pages. From simple scripts that handle form validations to complex frameworks and libraries like React and Angular, JavaScript powers the responsive and engaging experiences users expect from contemporary websites. It allows developers to create real-time updates, handle asynchronous operations, and manipulate the DOM, making web applications more user-friendly and efficient.", new DateTime(2024, 10, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript: The Dynamic Heart of Web Development", null },
                    { new Guid("a0340a0c-a702-4b19-b808-fce464311f43"), 2L, 4, "Bootstrap is a powerful front-end framework that simplifies the development of responsive and mobile-first websites. With its grid system, pre-styled components, and utility classes, Bootstrap makes it easy to create layouts that adapt to different screen sizes and devices. It includes a variety of customizable UI elements like buttons, modals, and navigation bars, allowing developers to build polished and professional-looking websites quickly. Bootstrap’s extensive documentation and community support make it a go-to choice for both beginners and experienced developers.", new DateTime(2024, 10, 19, 11, 15, 0, 0, DateTimeKind.Unspecified), "Bootstrap: Streamlining Responsive Web Design", null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CreateTime", "Post_Id", "Text", "UpdateTime", "User_Id" },
                values: new object[,]
                {
                    { new Guid("58124570-a62a-4297-a6ea-c6a5a79c931a"), new DateTime(2024, 10, 19, 16, 45, 0, 0, DateTimeKind.Unspecified), new Guid("a0340a0c-a702-4b19-b808-fce464311f43"), "Yazıyı beğenmedim.", null, 3L },
                    { new Guid("e329227c-ee67-409a-b64e-46a7be585e89"), new DateTime(2024, 10, 17, 11, 15, 0, 0, DateTimeKind.Unspecified), new Guid("702fe6ef-9dba-4219-b8a5-3a710e128e39"), "Çok güzel bir yazı.", null, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Post_Id",
                table: "Comments",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_User_Id",
                table: "Comments",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Author_Id",
                table: "Posts",
                column: "Author_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Category_Id",
                table: "Posts",
                column: "Category_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
