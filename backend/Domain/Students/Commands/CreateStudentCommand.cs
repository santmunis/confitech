using Domain.Base;
using Domain.Students.Enumerations;
using Domain.Students.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Students.Commands
{
    public class CreateStudentCommand
    {
        public class Contract : BaseContract<Student>
        {
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
                var student = new Student(request.Name, request.LastName,request.Email, request.BornDate, request.Scholarity);

                try
                {
                    _studentRepository.Add(student, cancellationToken);
                    await _unitOfWork.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return student;
            }
        }
    }
}
