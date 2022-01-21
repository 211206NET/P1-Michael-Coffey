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
        // GET: api/<ValuesController>
        [HttpGet]
        public List<Order> GetOrdersDate()
        {
            return _bl.GetOrdersDate();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public List<Order> GetCOrdersDate(int id)
        {
            return _bl.GetCustomerOrderHistoryDate(id);
        }
        public List<Order> GetCOrdersCost(int id)
        {
            return _bl.GetCustomerOrderHistoryCost(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void PostOrders([FromBody] Order nOrder)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void PutIntoOrder(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void DeleteOrder(int id)
        {
        }
    }
}
