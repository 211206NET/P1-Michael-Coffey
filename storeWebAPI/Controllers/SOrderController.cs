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
    public class SOrderController : ControllerBase
    {

        private IBL _bl;
        private IMemoryCache _memoryCache;

        public SOrderController(IBL bl, IMemoryCache memoryCache)
        {
            _bl = bl;
            _memoryCache = memoryCache;
        }
        /// <summary>
        /// Gets Orders based on cost
        /// </summary>
        /// <returns>List of Orders</returns>
        // GET: api/<SOrderController>
        [HttpGet]
        public List<Order> GetOrdersCost()
        {
            return _bl.GetOrdersCost();
        }

        /// <summary>
        /// Gets Store Order history based on cost
        /// </summary>
        /// <param name="id">ID of the selected store</param>
        /// <returns>Store's order history</returns>
        // GET api/<SOrderController>/5
        [HttpGet("{id}")]
        public List<Order> GetSOrdersCost(int id)
        {
            return _bl.GetStorefrontOrderHistoryCost(id);
        }

        /// <summary>
        /// Gets Store order history based on date or order
        /// </summary>
        /// <param name="did">ID of the selected store</param>
        /// <returns>Store's order history</returns>
        // GET api/<SOrderController>/5
        [HttpGet("{did}")]
        public List<Order> GetSOrderDate(int did)
        {
            return _bl.GetStorefrontOrderHistoryDate(did);
        }

        /// <summary>
        /// Places an order
        /// </summary>
        /// <param name="itemId">ID of the selected item</param>
        /// <param name="itemNum">nuber of items bought</param>
        /// <param name="storeId">Id of the item's store</param>
        /// <param name="cusID">ID of the customer buying the item</param>
        // POST api/<SOrderController>
        [HttpPost]
        public void PostStoreOrder(int itemId, int itemNum, int storeId, int cusID)
        {
            _bl.PlaceAnOrder(itemId, itemNum, storeId, cusID);
        }

        /// <summary>
        /// Puts an order into the StorefrontOrderHistory table
        /// </summary>
        /// <param name="id">ID of the item</param>
        /// <param name="ohId">SOrderHistoryID</param>
        // PUT api/<SOrderController>/5
        [HttpPut("{id}")]
        public void PutIntoStoreOrder(int id, int ohId)
        {
            _bl.PutOHInSOrderHistory(ohId, id);
        }

        /// <summary>
        /// Deletes an order from the database
        /// </summary>
        /// <param name="id">ID of the selected order</param>
        // DELETE api/<SOrderController>/5
        [HttpDelete("{id}")]
        public void DeleteStoreOrder(int id)
        {
            _bl.DeleteOrder(id);
        }
    }
}
