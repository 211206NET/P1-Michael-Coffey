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

        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public List<Product> GetInventoryByID(int id)
        {
            return _bl.GetInventory(id);
        }

        // POST api/<InventoryController>
        [HttpPost]
        public void PostInventories([FromBody] Inventory newInv, int nam)
        {
            _bl.AddInventory(newInv.ItemID, nam);
        }

        // PUT api/<InventoryController>/5
        [HttpPut("{id}")]
        public void PutIntoInventories(int id, [FromBody] Inventory nInvent, int newam)
        {
            _bl.ReplenishStock(id, nInvent.StoreId, newam);
        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public void DeleteInventory(int id)
        {
            _bl.DeleteInventory(id);
        }
    }
}
