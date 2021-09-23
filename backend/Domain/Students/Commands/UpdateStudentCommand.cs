using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Base;
using Domain.Interfaces;
using Domain.Students.Enumerations;
using Domain.Students.Models;
using MediatR;

namespace Domain.Students.Commands
{
    public class UpdateStudentCommand
    {
        public class Contract : BaseContract<Student>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public DateTimeOffset BornDate { get; set; }
            public EUserScholarity Scholarity { get; set; }
        }

        public class Handler : IRequestHandler<Contract, Student>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
            {
                _studentRepository = studentRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Student> Handle(Contract request, CancellationToken cancellationToken)
            {
                var student = new Student(request.Id, request.Name, request.LastName, request.Email, request.BornDate, request.Scholarity);
                _studentRepository.Update(student);
                await _unitOfWork.Commit();


                return student;
            }
        }
    }
}
