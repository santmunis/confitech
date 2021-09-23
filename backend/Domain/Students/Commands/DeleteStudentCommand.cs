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
    public class DeleteStudentCommand
    {
        public class Contract : BaseContract<bool>
        {
            public int Id { get; set; }
           
        }

        public class Handler : IRequestHandler<Contract, bool>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
            {
                _studentRepository = studentRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(Contract request, CancellationToken cancellationToken)
            {
                _studentRepository.Remove(request.Id);
                var result =  await _unitOfWork.Commit();
                return result;
            }
        }
    }
}
