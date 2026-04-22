using Microsoft.EntityFrameworkCore;
using University_System.Models;
namespace University_System.Context
{
    public class UniContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=ESRAA-SHIREF\\SQLEXPRESS;Database=Uni_DB;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    SSN = "123-45-6789",
                    Name = "Alice Johnson",
                    Email = "alice.johnson@university.edu",
                    Phone = "+1 (555) 101-2020",
                    Address = "12 Maple Street, New York, NY 10001",
                    Image = "https://randomuser.me/api/portraits/women/44.jpg"
                },
                new Student
                {
                    Id = 2,
                    SSN = "987-65-4321",
                    Name = "Bob Martinez",
                    Email = "bob.martinez@university.edu",
                    Phone = "+1 (555) 303-4040",
                    Address = "45 Oak Avenue, Los Angeles, CA 90001",
                    Image = "https://randomuser.me/api/portraits/men/32.jpg"
                },
                new Student
                {
                    Id = 3,
                    SSN = "456-78-9012",
                    Name = "Clara Smith",
                    Email = "clara.smith@university.edu",
                    Phone = "+1 (555) 505-6060",
                    Address = "78 Pine Road, Chicago, IL 60601",
                    Image = "https://randomuser.me/api/portraits/women/68.jpg"
                },
                new Student
                {
                    Id = 4,
                    SSN = "321-54-8765",
                    Name = "David Lee",
                    Email = "david.lee@university.edu",
                    Phone = "+1 (555) 707-8080",
                    Address = "99 Birch Blvd, Houston, TX 77001",
                    Image = "https://randomuser.me/api/portraits/men/75.jpg"
                },
                new Student
                {
                    Id = 5,
                    SSN = "654-32-1987",
                    Name = "Emma Wilson",
                    Email = "emma.wilson@university.edu",
                    Phone = "+1 (555) 909-1010",
                    Address = "33 Cedar Lane, Phoenix, AZ 85001",
                    Image = "https://randomuser.me/api/portraits/women/12.jpg"
                }
            );
        }
    }
}
