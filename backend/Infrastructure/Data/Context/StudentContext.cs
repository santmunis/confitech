using System;
using System.Linq;
using Domain.Students.Models;
using Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class StudentContext: DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(DateTimeOffset))))
                property.SetColumnType("datetimeoffset(7)");

            modelBuilder.ApplyConfiguration(new StudentMap());

            base.OnModelCreating(modelBuilder);
        }
    }

    
}
