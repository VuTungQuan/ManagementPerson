using Microsoft.EntityFrameworkCore;
using ManagementPerson.Models;
using ManagementPerson;
using Microsoft.Extensions.Logging;

namespace ManagementPerson
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Professor> professors { get; set; }
        public DbSet<Student> students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Professor>().ToTable("Professor");
            modelBuilder.Entity<Person>().ToTable("Person");

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Address)
                .WithOne(a => a.Person)
                .HasForeignKey<Address>(a => a.PersonId)
                .IsRequired();

            // Seed data
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, Name = "Hà Nội", Number = "30", PersonId = 1 },
                new Address { Id = 2, Name = "Hải Dương", Number = "34", PersonId = 2 },
                new Address { Id = 3, Name = "Hải Phòng", Number = "15", PersonId = 3 },
                new Address { Id = 4, Name = "Hưng Yên", Number = "89", PersonId = 4 },
                new Address { Id = 5, Name = "Hải Dương", Number = "34", PersonId = 5 },
                new Address { Id = 6, Name = "Hải Phòng", Number = "15", PersonId = 6 }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { PersonId = 1, Name = "Vu Tung Quan", PhoneNumber = "1234567891", EmailAddress = "person1@example.com", StudentNumber = "000001", AverageMark = 9.5 },
                new Student { PersonId = 2, Name = "Nguyen Ai Dan", PhoneNumber = "1234567892", EmailAddress = "person2@example.com", StudentNumber = "000002", AverageMark = 9.0 },
                new Student { PersonId = 3, Name = "Duc Minh Hoang", PhoneNumber = "1234567893", EmailAddress = "person3@example.com", StudentNumber = "000003", AverageMark = 8.5 }
            );

            modelBuilder.Entity<Professor>().HasData(
                new Professor { PersonId = 4, Name = "Vu Minh Duc", PhoneNumber = "1234567894", EmailAddress = "person4@example.com", Salary = 50000 },
                new Professor { PersonId = 5, Name = "Nguyen Huong Duyen", PhoneNumber = "1234567895", EmailAddress = "person5@example.com", Salary = 60000 },
                new Professor { PersonId = 6, Name = "Hoang Thi Lan", PhoneNumber = "1234567896", EmailAddress = "person6@example.com", Salary = 70000 }
            );
        }
    }
}
