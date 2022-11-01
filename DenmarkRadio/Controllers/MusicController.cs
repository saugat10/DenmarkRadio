using DenmarkRadio.Managers;
using DenmarkRadio.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DenmarkRadio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly MusicManager _manager = new MusicManager();
        // GET: api/<MusicController>
        [HttpGet]
        public IEnumerable<Music> Get()
        {
            return _manager.GetAll();
        }


        [HttpGet("{id}")]
        public ActionResult<Music> Get(int id)
        {
            Music music = _manager.GetById(id);
            if (music == null) return NotFound("No such music, id: " + id);
            return Ok(music);
        }


        [HttpPost]
        public ActionResult<Music> Post([FromBody] Music value)
        {
            Music music = _manager.Add(value);
            if (music == null) return NotFound("No such music, id: " + music.Id);
            return Created("api/[controller]", music);
        }

        [HttpPut("{id}")]
        public ActionResult<Music> Put(int id, [FromBody] Music value)
        {
            Music music = _manager.Update(id, value);
            if (music == null) return NotFound("No such music, id: " + id);
            return Ok(music);
        }

        [HttpDelete("{id}")]
        public ActionResult<Music> Delete(int id)
        {
            Music music = _manager.Delete(id);
            if (music == null) return NotFound("No such music, id: " + id);
            return Ok(music);
        }
    }
}
