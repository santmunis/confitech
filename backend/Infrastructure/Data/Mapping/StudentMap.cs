using System;
using System.Collections.Generic;
using System.Text;
using Domain.Students.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class StudentMap :  IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .HasColumnName("Id")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            
            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Scholarity)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.BornDate)
                .HasColumnType("datetimeoffset")
                .IsRequired();
        }
    }
}
