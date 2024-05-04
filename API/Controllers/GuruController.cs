using Microsoft.AspNetCore.Mvc;
using Utama.Class;
using Utama.Enum;

namespace API.Controllers
{
    [Route("guru/[controller]")]
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
            catch (IndexOutOfRangeException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult Register(Guru guru)
        {
            foreach (Guru g in listGuru)
            {
                if (g.username == guru.username)
                {
                    return Conflict("Username sudah terdaftar");
                }
            }

            try
            {
                listGuru.Add(guru);
                return Ok("Registrasi berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(Guru guru)
        {
            Guru existingGuru = null;
            foreach (Guru g in listGuru)
            {
                if (g.username == guru.username && g.password == guru.password)
                {
                    existingGuru = g;
                }
            }
            if (existingGuru == null)
            {
                return Unauthorized("Username atau password salah");
            }

            return Ok(new { message = "Login berhasil"});
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
