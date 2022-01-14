using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace storeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorefrontController : ControllerBase
    {
        // GET: api/<StorefrontController>
        [HttpGet]
        public List<Storefront> Get()
        {
            return new List<Storefront>();
        }

        // GET api/<StorefrontController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StorefrontController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StorefrontController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StorefrontController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
