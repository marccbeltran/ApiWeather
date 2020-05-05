using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiWeather.Models;

namespace ApiWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataWeatherController : ControllerBase
    {
        private readonly WeatherContext _context;

        public DataWeatherController(WeatherContext context)
        {
            _context = context;
        }

        // GET: api/DataWeather
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataWeather>>> GetDataWeathers()
        {
            return await _context.DataWeathers.ToListAsync();
        }

        // GET: api/DataWeather/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataWeather>> GetDataWeather(long id)
        {
            var dataWeather = await _context.DataWeathers.FindAsync(id);

            if (dataWeather == null)
            {
                return NotFound();
            }

            return dataWeather;
        }

        // PUT: api/DataWeather/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataWeather(long id, DataWeather dataWeather)
        {
            if (id != dataWeather.Id)
            {
                return BadRequest();
            }

            _context.Entry(dataWeather).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataWeatherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DataWeather
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataWeather>> PostDataWeather(DataWeather dataWeather)
        {
            _context.DataWeathers.Add(dataWeather);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataWeather", new { id = dataWeather.Id }, dataWeather);
        }

        // DELETE: api/DataWeather/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataWeather>> DeleteDataWeather(long id)
        {
            var dataWeather = await _context.DataWeathers.FindAsync(id);
            if (dataWeather == null)
            {
                return NotFound();
            }

            _context.DataWeathers.Remove(dataWeather);
            await _context.SaveChangesAsync();

            return dataWeather;
        }

        private bool DataWeatherExists(long id)
        {
            return _context.DataWeathers.Any(e => e.Id == id);
        }
    }
}
