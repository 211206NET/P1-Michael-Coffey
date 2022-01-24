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
        // GET: api/<ProductController>
        [HttpGet]
        public List<Product> GetProducts(int invID)
        {
            return _bl.GetInventory(invID);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string GetProductByID(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void PostProducts([FromBody] Product newPro)
        {
            _bl.AddProduct(newPro.InventoryID, newPro.ProductName, newPro.Price, newPro.ReleaseYearID, newPro.DirectorID, newPro.MPARatingID);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void PutDirectorIntoProduct(int id, [FromBody] string value)
        {
            _bl.AddDirectorToProduct(id, value);
        }

        //PUT api/<ProductController>/5
        [HttpPut("{pid}")]
        public void PutReleaseYearIntoProduct(int pid, [FromBody] int value)
        {
            _bl.AddReleaseYearToProduct(pid, value);
        }

        //PUT api/<ProductController>/5
        [HttpPut("{mid}")]
        public void PutMPARatingIntoProduct(int mid, [FromBody] string value)
        {
            _bl.AddRatingToProduct(mid, value);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void DeleteProduct([FromBody] Product selectedProduct)
        {
            _bl.DeleteProduct(selectedProduct.ProductName);
        }
    }
}
