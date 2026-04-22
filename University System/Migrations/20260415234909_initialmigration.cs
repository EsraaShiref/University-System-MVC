using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace University_System.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Email", "Image", "Name", "Phone", "SSN" },
                values: new object[,]
                {
                    { 1, "12 Maple Street, New York, NY 10001", "alice.johnson@university.edu", "https://randomuser.me/api/portraits/women/44.jpg", "Alice Johnson", "+1 (555) 101-2020", "123-45-6789" },
                    { 2, "45 Oak Avenue, Los Angeles, CA 90001", "bob.martinez@university.edu", "https://randomuser.me/api/portraits/men/32.jpg", "Bob Martinez", "+1 (555) 303-4040", "987-65-4321" },
                    { 3, "78 Pine Road, Chicago, IL 60601", "clara.smith@university.edu", "https://randomuser.me/api/portraits/women/68.jpg", "Clara Smith", "+1 (555) 505-6060", "456-78-9012" },
                    { 4, "99 Birch Blvd, Houston, TX 77001", "david.lee@university.edu", "https://randomuser.me/api/portraits/men/75.jpg", "David Lee", "+1 (555) 707-8080", "321-54-8765" },
                    { 5, "33 Cedar Lane, Phoenix, AZ 85001", "emma.wilson@university.edu", "https://randomuser.me/api/portraits/women/12.jpg", "Emma Wilson", "+1 (555) 909-1010", "654-32-1987" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
