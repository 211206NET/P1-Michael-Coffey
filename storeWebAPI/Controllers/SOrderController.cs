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
        // GET: api/<SOrderController>
        [HttpGet]
        public List<Order> GetOrdersCost()
        {
            return _bl.GetOrdersCost();
        }

        // GET api/<SOrderController>/5
        [HttpGet("{id}")]
        public List<Order> GetSOrdersCost(int id)
        {
            return _bl.GetStorefrontOrderHistoryCost(id);
        }
        [HttpGet("{id}")]
        public List<Order> GetSOrderDate(int id)
        {
            return _bl.GetStorefrontOrderHistoryDate(id);
        }

        // POST api/<SOrderController>
        [HttpPost]
        public void Post([FromBody] Order nOrder)
        {
        }

        // PUT api/<SOrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SOrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
