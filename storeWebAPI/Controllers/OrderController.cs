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
        // GET: api/<OrderController>
        [HttpGet]
        public List<Order> GetOrdersDate()
        {
            return _bl.GetOrdersDate();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public List<Order> GetCOrdersDate(int id)
        {
            return _bl.GetCustomerOrderHistoryDate(id);
        }

        // GET api/<OrderController>/5
        [HttpGet("{nid}")]
        public List<Order> GetCOrdersCost(int nid)
        {
            return _bl.GetCustomerOrderHistoryCost(nid);
        }

        // POST api/<OrderController>
        [HttpPost]
        public void PostOrders(int itemId, int itemNum, int storeId, int cusID)
        {
            _bl.PlaceAnOrder(itemId, itemNum, storeId, cusID);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void PutIntoOrder(int id, [FromBody] int ohId)
        {
            _bl.PutOHInCOrderHistory(ohId, id);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void DeleteOrder(int id)
        {
            _bl.DeleteOrder(id);
        }
    }
}
