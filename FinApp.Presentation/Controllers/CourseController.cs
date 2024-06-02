using ShinyCollectorPlatform.Application;
using ShinyCollectorPlatform.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ShinyCollectorPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly IGenericService<Course> CourseService;

        public CourseController(IGenericService<Course> courseService)
        {
            this.CourseService = courseService;
        }

        [HttpGet]
        public ActionResult<List<Course>> Get()
        {
            return Ok(CourseService.GetAll());
        }
    }
}
