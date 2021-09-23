using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using Domain.Students.Models;
using Infrastructure.Data;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StudentRepository: BaseRepository<Student>, IStudentRepository
    {
        public sealed override DbSet<Student> Collection { get; set; }
        public StudentRepository(StudentContext context) : base(context)
        {
            Collection = context.Students;
        }
    }
}
