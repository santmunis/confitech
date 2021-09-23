using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Base;
using Domain.Interfaces;
using Domain.Students.Models;
using MediatR;

namespace Domain.Students.Queries
{
    public class GetStudentByIdQuery
    {
        public class Contract : BaseContract<Student>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Contract, Student>
        {
            private readonly IStudentRepository _studentRepository;
            public Handler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }

            public async Task<Student> Handle(Contract request, CancellationToken cancellationToken)
            {
                var student = await _studentRepository.GetById(request.Id, cancellationToken);

                return student;
            }
        }
    }
}
