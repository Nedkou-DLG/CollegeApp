using System;
using College.API.Application.Interfaces;
using College.API.Helpers;
using College.Domain.Entities;
using College.Domain.Models.Course;
using Microsoft.AspNetCore.Mvc;

namespace College.API.Controllers
{
    [ApiController]
    [Route("course")]
    public class CourseContoller : AbstractController
    {
        private readonly ICourseService _courseService;
        public CourseContoller(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("add")]
        [Authorize(UserType.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCourse(CreateCourseModel model)
        {
            try
            {
                await _courseService.CreateCourse(model);
                return Ok("Successfully created course");
            }
            catch (Exception ex)
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
                var response = await _courseService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

