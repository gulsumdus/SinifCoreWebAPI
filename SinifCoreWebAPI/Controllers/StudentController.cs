using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinifCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;// ToListAsync(); gib fonklar kullanılır


namespace SinifCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _dbContext;

        public StudentController(StudentContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet] // bütün datayı siteye getirir// listeleme

        public async Task<ActionResult<IEnumerable<Student>>> GetInfo()
        {
            if (_dbContext.Students == null)
            {
                return NotFound();
            }
            return await _dbContext.Students.ToListAsync();

        }


        [HttpGet("{id}")] //ISTENILEN datayı siteye getirir

        public async Task<ActionResult<Student>> GetAStudent(int id)
        {
            if (_dbContext.Students == null)
            {
                return NotFound();
            }
            var ogr = await _dbContext.Students.FindAsync(id);
            if (ogr == null)
            {

                return NotFound();
            }
            return  Ok(ogr);

        }


        [HttpPost]
        public async Task<ActionResult<Student>>PostStudent(Student student)
        {
             _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return Ok(student);

        }


        [HttpPut("{id}")]

        public async Task<ActionResult<Student>> PutStudent(int id, Student student1)
        {
            if (id != student1.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(student1).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAvaible(id))
                {
                    return NotFound();

                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }
        private bool StudentAvaible(int id)
        {
            return (_dbContext.Students?.Any(x => x.Id == id)).GetValueOrDefault();

        }




        [HttpDelete("{id}")] // ISTENILEN veriyi silmek için

        public async Task<IActionResult> DeleteBrand(int id)
        {
            if (_dbContext.Students == null)
            {
                return NotFound();
            }
            var ogrenci = await _dbContext.Students.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            _dbContext.Students.Remove(ogrenci);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }


    }

}
