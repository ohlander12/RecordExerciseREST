using Microsoft.AspNetCore.Mvc;
using Record_Exercise_REST.Models;
using Record_Exercise_REST.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecordsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MusicRecord> Post([FromBody] MusicRecord value)
        {
            try 
            { 
            MusicRecord newMusicRecord = _records.Add(value);
                string uri = Url.RouteUrl(RouteData.Values) + "/" + newMusicRecord.Id;
                return Created(uri, newMusicRecord);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<RecordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecordsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
