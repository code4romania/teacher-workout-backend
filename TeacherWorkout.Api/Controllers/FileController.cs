using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeacherWorkout.Data;

namespace TeacherWorkout.Api.Controllers
{   
    [Route("file")]
    [ApiController]
    public class FileController(TeacherWorkoutContext context) : ControllerBase
    {
        private readonly TeacherWorkoutContext _context = context;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImage(string id)
        {
            var fileBlob = await _context.FileBlobs.FindAsync(id);
            if (fileBlob == null)
            {
                return NotFound();
            }

            return File(fileBlob.Content, fileBlob.Mimetype);
        }
    }
}
