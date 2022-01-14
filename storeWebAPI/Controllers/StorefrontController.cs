using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using DL;
using CustomExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace storeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorefrontController : ControllerBase
    {
        private IBL _bl;
        public StorefrontController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<StorefrontController>
        [HttpGet]
        public List<Storefront> Get()
        {
            return _bl.GetAllStorefronts();
        }

        // GET api/<StorefrontController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StorefrontController>
        [HttpPost]
        public ActionResult Post([FromBody] Storefront storefrontToAdd)
        {
            try
            {
                _bl.AddStorefront(storefrontToAdd.Name, storefrontToAdd.Address, storefrontToAdd.InventoryID);
                return Created("Successfully added", storefrontToAdd);
            }
            catch(DuplicateException ex)
            {
                return Conflict(ex.Message);
            }
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
