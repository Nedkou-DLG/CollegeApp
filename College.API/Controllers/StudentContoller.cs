using System;
using College.API.Application.Interfaces;
using College.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace College.API.Controllers
{
	[ApiController]
	[Route("student")]
	public class StudentContoller : ControllerBase
	{
		private IStudentService studentService;
		public StudentContoller(IStudentService studentService) 
		{
			this.studentService = studentService;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] StudentModel model)
        {
            try
            {
				var response = await studentService.CreateStudent(model);

				return Ok(response);
            }
			catch(Exception ex)
            {
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
	}
}

