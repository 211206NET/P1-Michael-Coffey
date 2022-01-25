using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using DL;
using CustomExceptions;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace storeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorefrontController : ControllerBase
    {
        private IBL _bl;
        private IMemoryCache _memoryCache;
        public StorefrontController(IBL bl, IMemoryCache memoryCache)
        {
            _bl = bl;
            _memoryCache = memoryCache;
        }
        /// <summary>
        /// Gets all stores from the database
        /// </summary>
        /// <returns>A list of Storefronts</returns>
        // GET: api/<StorefrontController>
        [HttpGet]
        public async Task<List<Storefront>> GetStores()
        {
            List<Storefront> allSto;
            if(!_memoryCache.TryGetValue("storefront", out allSto)){
                allSto = await _bl.GetAllStorefrontsAsync();
                _memoryCache.Set("storefront", allSto, new TimeSpan(0,0,30));
            }
            return allSto;
        }

        /// <summary>
        /// Gets a Storefront by its ID
        /// </summary>
        /// <param name="id">ID of the selected Storefront</param>
        /// <returns>Selected Storefront</returns>
        // GET api/<StorefrontController>/5
        [HttpGet("{id}")]
        public Storefront GetStoreByID(int id)
        {
            return _bl.GetStorefrontByID(id);
        }

        /// <summary>
        /// Adds a Storefront to the database
        /// </summary>
        /// <param name="address">Address of the new Storefront</param>
        /// <param name="name">Name of the new Storefront</param>
        /// <param name="invID">ID of the new Storefornt's Inventory</param>
        /// <returns></returns>
        // POST api/<StorefrontController>
        [HttpPost]
        public ActionResult PostStore(string address, string name, int invID)
        {
            try
            {
                Storefront nsto = new Storefront(address, name, invID);
                _bl.AddStorefront(name, address, invID);
                return Created("Successfully added", nsto);
            }
            catch(DuplicateException ex)
            {
                return Conflict(ex.Message);
            }
        }

        /// <summary>
        /// Puts a Store Order History ID into a Storefront
        /// </summary>
        /// <param name="id">ID of the selected store</param>
        /// <param name="value">SOrderHistoryID</param>
        // PUT api/<StorefrontController>/5
        [HttpPut("{id}")]
        public void PutIntoStore(int id, int value)
        {
            _bl.PutSOHIDIntoStorefront(id, value);
        }

        /// <summary>
        /// Deletes a Storefront from the database
        /// </summary>
        /// <param name="nStore">Store that will be deleted</param>
        // DELETE api/<StorefrontController>/5
        [HttpDelete("{id}")]
        public void DeleteStore(string nStore)
        {
            _bl.DeleteStorefront(nStore);
        }
    }
}
