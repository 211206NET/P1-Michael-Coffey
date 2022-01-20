using Microsoft.AspNetCore.Mvc;
using Models;
using DL;
using BL;
using CustomExceptions;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace storeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IBL _bl;
        private IMemoryCache _memoryCache;

        public ProductController(IBL bl, IMemoryCache memoryCache)
        {
            _bl = bl;
            _memoryCache = memoryCache;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public List<Product> GetProducts(int invID)
        {
            return _bl.GetInventory(invID);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string GetProductByID(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void PostProducts([FromBody] Product newPro)
        {
            _bl.AddProduct(newPro.InventoryID, newPro.ProductName, newPro.Price, newPro.ReleaseYearID, newPro.DirectorID, newPro.MPARatingID);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void PutIntoProduct(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
        }
    }
}
