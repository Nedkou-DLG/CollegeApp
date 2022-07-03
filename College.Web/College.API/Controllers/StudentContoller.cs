using System;
using College.API.Application.Interfaces;
using College.API.Helpers;
using College.Domain.Entities;
using College.Domain.Models;
using College.Domain.Models.Student;
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

        [HttpPost("add")]
        [Authorize(UserType.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateStudentModel model)
        {
            try
            {
				await studentService.CreateStudent(model);

				return Ok("Successfully created student");
            }
			catch(Exception ex)
            {
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("all")]
        [Authorize(UserType.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var response = await studentService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

