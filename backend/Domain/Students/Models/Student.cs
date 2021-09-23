using System;
using Domain.Base;
using Domain.Students.Enumerations;
using System.Collections.Generic;
using System.Text;

namespace Domain.Students.Models
{
    public class Student: Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset BornDate { get; set; }
        public EUserScholarity Scholarity { get; set; }

        public Student()
        {

        }
        public Student(string name, string lastName, string email, DateTimeOffset bornDate, EUserScholarity eUserScholarity)
        {
            //TODO adicionar validação
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.BornDate = bornDate;
            this.Scholarity = eUserScholarity;
        }
        public Student(int id, string name, string lastName, string email, DateTimeOffset bornDate, EUserScholarity eUserScholarity)
        {
            //TODO adicionar validação
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.BornDate = bornDate;
            this.Scholarity = eUserScholarity;
            this.UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
