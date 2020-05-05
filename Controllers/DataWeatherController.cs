using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWeather.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataWeatherController : ControllerBase
    {
        // GET: api/DataWeather
        [HttpGet]
        public IEnumerable<DataWeather> Get()
        {
            DataWeather data = new DataWeather();
            yield return data;
        }

        // GET: api/DataWeather/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DataWeather
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/DataWeather/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
