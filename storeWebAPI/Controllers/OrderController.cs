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
    public class OrderController : ControllerBase
    {

        private IBL _bl;
        private IMemoryCache _memoryCache;

        public OrderController(IBL bl, IMemoryCache memoryCache)
        {
            _bl = bl;
            _memoryCache = memoryCache;
        }
        /// <summary>
        /// Gets the Orders based on Date of Order
        /// </summary>
        /// <returns>List of Orders</returns>
        // GET: api/<OrderController>
        [HttpGet]
        public List<Order> GetOrdersDate()
        {
            return _bl.GetOrdersDate();
        }

        /// <summary>
        /// Gets Customer Orders based on Date of Order
        /// </summary>
        /// <param name="id">ID of the selected customer</param>
        /// <returns>Customer's order history</returns>
        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public List<Order> GetCOrdersDate(int id)
        {
            return _bl.GetCustomerOrderHistoryDate(id);
        }

        /// <summary>
        /// Gets Customer Orders based on total cost
        /// </summary>
        /// <param name="nid">ID of the selected customer</param>
        /// <returns>Customer's order history</returns>
        // GET api/<OrderController>/5
        [HttpGet("{nid}")]
        public List<Order> GetCOrdersCost(int nid)
        {
            return _bl.GetCustomerOrderHistoryCost(nid);
        }

        /// <summary>
        /// Places a new order
        /// </summary>
        /// <param name="itemId">ID of the selected item</param>
        /// <param name="itemNum">Number of items being bought</param>
        /// <param name="storeId">ID of the store of the item</param>
        /// <param name="cusID">ID of the customer buying the item</param>
        // POST api/<OrderController>
        [HttpPost]
        public void PostOrders(int itemId, int itemNum, int storeId, int cusID)
        {
            _bl.PlaceAnOrder(itemId, itemNum, storeId, cusID);
        }

        /// <summary>
        /// Puts an order into the Customer Order History table
        /// </summary>
        /// <param name="id">ID of the new order</param>
        /// <param name="ohId">ID of the COrderHistory</param>
        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void PutIntoOrder(int id, int ohId)
        {
            _bl.PutOHInCOrderHistory(ohId, id);
        }

        /// <summary>
        /// Deletes an order from the database
        /// </summary>
        /// <param name="id">ID of the selected order</param>
        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void DeleteOrder(int id)
        {
            _bl.DeleteOrder(id);
        }
    }
}
