using System;
using College.API.Application.Interfaces;
using College.API.Helpers;
using College.Domain.Entities;
using College.Domain.Models.Teacher;
using Microsoft.AspNetCore.Mvc;

namespace College.API.Controllers
{
    [ApiController]
    [Route("teacher")]
    public class TeacherController : AbstractController
    {
        public readonly ITeacherService _teacherService;
        
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet("all")]
        [Authorize(UserType.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllTeachers()
        {
            try
            {
                var response = await _teacherService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("add")]
        [Authorize(UserType.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateTeacher(CreateTeacherModel model)
        {
            try
            {
                await _teacherService.CreateTeacher(model);
                return Ok("Successfully created teacher");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("assign-department")]
        [Authorize(UserType.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AssignDepartment(TeacherDepartmentModel model)
        {
            try
            {
                await _teacherService.AssignTeacherToDepartment(model);
                return Ok("Successfully assigned teacher");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

