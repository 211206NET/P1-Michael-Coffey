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
        /// <summary>
        /// Gets all Products in an inventory
        /// </summary>
        /// <param name="invID">ID of the Inventory</param>
        /// <returns>List of an Inventory's Products</returns>
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

        /// <summary>
        /// Adds a new Product
        /// </summary>
        /// <param name="newPro">Product that will be added</param>
        // POST api/<ProductController>
        [HttpPost]
        public void PostProducts([FromBody] Product newPro)
        {
            _bl.AddProduct(newPro.InventoryID, newPro.ProductName, newPro.Price, newPro.ReleaseYearID, newPro.DirectorID, newPro.MPARatingID);
        }

        /// <summary>
        /// Adds a director to a film in the database
        /// </summary>
        /// <param name="id">ID of the Film</param>
        /// <param name="value">Name of the director</param>
        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void PutDirectorIntoProduct(int id, [FromBody] string value)
        {
            _bl.AddDirectorToProduct(id, value);
        }

        /// <summary>
        /// Adds a release year to a film in the database
        /// </summary>
        /// <param name="pid">ID of the film</param>
        /// <param name="value">year of the film's release</param>
        //PUT api/<ProductController>/5
        [HttpPut("{pid}")]
        public void PutReleaseYearIntoProduct(int pid, [FromBody] int value)
        {
            _bl.AddReleaseYearToProduct(pid, value);
        }

        /// <summary>
        /// Adds an MPA rating to a film in the database
        /// </summary>
        /// <param name="mid">ID of the film</param>
        /// <param name="value">Rating of the film</param>
        //PUT api/<ProductController>/5
        [HttpPut("{mid}")]
        public void PutMPARatingIntoProduct(int mid, [FromBody] string value)
        {
            _bl.AddRatingToProduct(mid, value);
        }

        /// <summary>
        /// Deletes a product from the database
        /// </summary>
        /// <param name="selectedProduct">Product that will be deleted</param>
        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void DeleteProduct(string selectedProduct)
        {
            _bl.DeleteProduct(selectedProduct);
        }
    }
}
