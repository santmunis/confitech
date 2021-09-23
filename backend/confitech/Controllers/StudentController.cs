using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using confitech.Base;
using Domain.Students.Commands;
using Domain.Students.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace confitech.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : BaseController
    {
        public StudentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] CreateStudentCommand.Contract request)
        {
            var result = await Send(request);
            return result;

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(DeleteStudentCommand.Contract request)
        {
            var result = await Send(request);
            return result;

        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand.Contract request)
        {
            var result = await Send(request);
            return result;

        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllStudent(GetAllStudentsQuery.Contract request)
        {
            var result = await Send(request);
            return result;

        }
        [HttpGet("ByID")]
        public async Task<IActionResult> GetByIdStudent(GetStudentByIdQuery.Contract request)
        {
            var result = await Send(request);
            return result;

        }
    }
}
