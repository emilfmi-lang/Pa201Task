using AcademyApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApp.DLL.Data.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(x => x.LastName)
                .HasMaxLength(50);
            builder.Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired(true)
                .HasAnnotation("RegularExpression", @"^[a-zA-Z0-9._%+-]+@code\.edu\.az$");
            builder.HasOne(x => x.Group)
                .WithMany(y => y.Students)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

 //           builder.HasData(
 //    new Student { Id = 1, FirstName = "Alice", LastName = "Johnson", Email = "alice@code.edu.az", GroupId = 1 },
 //    new Student { Id = 2, FirstName = "Bob", LastName = "Smith", Email = "bob@code.edu.az", GroupId = 1 },
 //    new Student { Id = 3, FirstName = "Charlie", LastName = "Brown", Email = "charlie@code.edu.az", GroupId = 1 },
 //    new Student { Id = 4, FirstName = "Diana", LastName = "Clark", Email = "diana@code.edu.az", GroupId = 2 },
 //    new Student { Id = 5, FirstName = "Edward", LastName = "Wilson", Email = "edward@code.edu.az", GroupId = 2 },
 //    new Student { Id = 6, FirstName = "Fiona", LastName = "Adams", Email = "fiona@code.edu.az", GroupId = 2 },
 //    new Student { Id = 7, FirstName = "George", LastName = "White", Email = "george@code.edu.az", GroupId = 3 },
 //    new Student { Id = 8, FirstName = "Hannah", LastName = "Miller", Email = "hannah@code.edu.az", GroupId = 3 },
 //    new Student { Id = 9, FirstName = "Ivan", LastName = "Garcia", Email = "ivan@code.edu.az", GroupId = 3 },
 //    new Student { Id = 10, FirstName = "Jessica", LastName = "Martinez", Email = "jessica@code.edu.az", GroupId = 3 }
 //);


        }
    }
}
