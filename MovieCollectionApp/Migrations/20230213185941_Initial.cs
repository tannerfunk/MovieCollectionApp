using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCollectionApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inputs",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Note = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inputs", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "Inputs",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Note", "Rating", "Title", "Year" },
                values: new object[] { 1, "Action/Adventure", "Joss Whedon", false, "", "", "PG-13", "The Avengers", 2012 });

            migrationBuilder.InsertData(
                table: "Inputs",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Note", "Rating", "Title", "Year" },
                values: new object[] { 2, "Comedy", "Eric Darnell, Tom McGrath", false, "", "", "PG", "Madagascar", 2005 });

            migrationBuilder.InsertData(
                table: "Inputs",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Note", "Rating", "Title", "Year" },
                values: new object[] { 3, "Family", "Ron Clements, John Musker", false, "", "", "PG", "Moana", 2016 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inputs");
        }
    }
}
