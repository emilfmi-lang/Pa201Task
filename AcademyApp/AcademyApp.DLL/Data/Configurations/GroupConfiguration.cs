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
    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        //fluent api
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(20);
            builder.HasIndex(x => x.Name)
                .IsUnique();
                
            builder.Property(x => x.Description)
                .IsRequired(true)
                .HasMaxLength(100);
            builder.Property(x => x.Limit)
                .IsRequired(true);

            builder.HasMany(x => x.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
           


            builder.HasData(
                 new Group
                 {
                     Id = 1,
                     Name = "P110",
                     Description = "Backend .NET qrup",
                     Limit = 20
                 },
            new Group
            {
                Id = 2,
                Name = "P210",
                Description = "Frontend JS qrup",
                Limit = 18
            },
            new Group
            {
                Id = 3,
                Name = "P310",
                Description = "QA Software Testing qrup",
                Limit = 15
            }
        );
                
        }
    }
}
