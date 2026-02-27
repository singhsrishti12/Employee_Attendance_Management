using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Policy> Policies { get; set; }

        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasIndex(r => r.Email)
                .IsUnique();

            modelBuilder.Entity<AttendanceRecord>()
               .HasIndex(r => new { r.EmployeeId ,r.AttendanceDate})
               .IsUnique();

            modelBuilder.Entity<Employee>()
               .HasOne(r => r.Policy)
               .WithMany(e => e.Employees)
               .HasForeignKey(r => r.PolicyId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AttendanceRecord>()
             .HasOne(r => r.Employee)
             .WithMany(e => e.AttendanceRecords)
             .HasForeignKey(r => r.EmployeeId)
             .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
