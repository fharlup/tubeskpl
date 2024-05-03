using API.Class;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuruController : ControllerBase
    {
        private static List<Guru> listGuru = new List<Guru>();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(listGuru);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id < 0 || id >= listGuru.Count)
                    throw new IndexOutOfRangeException("Invalid ID");

                return Ok(listGuru[id]);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Guru guru)
        {
            try
            {
                listGuru.Add(guru);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Guru guru)
        {
            try
            {
                if (id < 0 || id >= listGuru.Count)
                    throw new IndexOutOfRangeException("Invalid ID");

                listGuru[id] = guru;
                return Ok();
            }
            catch (IndexOutOfRangeException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id < 0 || id >= listGuru.Count)
                    throw new IndexOutOfRangeException("Invalid ID");

                listGuru.RemoveAt(id);
                return Ok();
            }
            catch (IndexOutOfRangeException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
