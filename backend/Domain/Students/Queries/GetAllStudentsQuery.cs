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
    public class GetAllStudentsQuery
    {
        public class Contract : BaseContract<List<Student>>
        {
        }

        public class Handler : IRequestHandler<Contract, List<Student>>
        {
            private readonly IStudentRepository _studentRepository;

            public Handler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }

            public async Task<List<Student>> Handle(Contract request, CancellationToken cancellationToken)
            {
                var result = await _studentRepository.GetAll(cancellationToken);
                return result;
            }
        }
    }
}
