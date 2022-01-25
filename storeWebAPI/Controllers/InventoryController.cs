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
    public class InventoryController : ControllerBase
    {

        private IBL _bl;
        private IMemoryCache _memoryCache;

        public InventoryController(IBL bl, IMemoryCache memoryCache)
        {
            _bl = bl;
            _memoryCache = memoryCache;
        }
        /// <summary>
        /// Gets all Invenotries in the database
        /// </summary>
        /// <returns>List of Inventory objects</returns>
        // GET: api/<InventoryController>
        [HttpGet]
        public async Task<List<Inventory>> GetInventories()
        {
            List<Inventory> nInventories = new List<Inventory>();
            if(!_memoryCache.TryGetValue("inventory", out nInventories))
            {
                nInventories = await _bl.GetAllInventoriesAsync();
                _memoryCache.Set("inventory", nInventories, new TimeSpan(0, 0, 30));
            }
            return nInventories;
        }

        /// <summary>
        /// Gets an Inventory based on its ID
        /// </summary>
        /// <param name="id">ID of the selected Inventory</param>
        /// <returns>Inventory with its Products</returns>
        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public List<Product> GetInventoryByID(int id)
        {
            return _bl.GetInventory(id);
        }

        /// <summary>
        /// Adds an Inventory to the database
        /// </summary>
        /// <param name="itemid">ID of the Inventory's item</param>
        /// <param name="nam">number of the specific item</param>
        // POST api/<InventoryController>
        [HttpPost]
        public void PostInventories(int itemid, int nam)
        {
            _bl.AddInventory(itemid, nam);
        }

        /// <summary>
        /// Replenishes the stock of an inventory
        /// </summary>
        /// <param name="id">ID of the Invnetory</param>
        /// <param name="stoID">ID of the store</param>
        /// <param name="newam">Amount that will be added</param>
        // PUT api/<InventoryController>/5
        [HttpPut("{id}")]
        public void PutIntoInventories(int id, int stoID, int newam)
        {
            _bl.ReplenishStock(id, stoID, newam);
        }

        /// <summary>
        /// Deletes an Inventory
        /// </summary>
        /// <param name="id">ID of the selected Inventory</param>
        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public void DeleteInventory(int id)
        {
            _bl.DeleteInventory(id);
        }
    }
}
