using Microsoft.AspNetCore.Mvc;
using Record_Exercise_REST.Models;
using Record_Exercise_REST.Repositories;
using System.Collections.Generic;

namespace Record_Exercise_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly RecordsRepository _records = new RecordsRepository();

        // GET: api/<RecordsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<MusicRecord> Get([FromQuery] string title, [FromQuery] string sort_by)
        {
            return _records.GetAll(title, sort_by);
        }

        // GET api/<RecordsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MusicRecord> Get(int id)
        {
         MusicRecord? musicRecord = _records.GetById(id);
            if (musicRecord == null) return NotFound("No such record, id:" + id);
            return Ok(musicRecord);
            
        }

        // POST api/<RecordsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MusicRecord> Post([FromBody] MusicRecord newMusicRecord)
        { 
                MusicRecord createdMusicRecord = _records.Add(newMusicRecord);
                if (createdMusicRecord == null)
                {
                    return BadRequest();
                }
                else
               {
                return Created("MusicRecord object created", createdMusicRecord);
               }
             }

        // PUT api/<RecordsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] MusicRecord value)
        {
            var existingRecord = _records.GetById(id);
            if (existingRecord == null)
            {
                return NotFound();
            }
            _records.Update(id, value);
            return NoContent();
        }

        // DELETE api/<RecordsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var record = _records.GetById(id);
            if (record == null)
            {
                return NotFound();
            }
            _records.Delete(id);
            return NoContent();
        }
    }
}
