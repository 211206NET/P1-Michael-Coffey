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
    public class CustomerController : ControllerBase
    {
        private IBL _bl;
        private IMemoryCache _memoryCache;
        public CustomerController(IBL bl, IMemoryCache memoryCache)
        {
            _bl = bl;
            _memoryCache = memoryCache;
        }
        /// <summary>
        /// Gets all Customers in the database
        /// </summary>
        /// <returns>A list of all Customers</returns>
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<List<Customer>> GetCustomers()
        {
            List<Customer> allCus;
            if(!_memoryCache.TryGetValue("customer", out allCus)){
                allCus = await _bl.GetAllCustomersAsync();
                _memoryCache.Set("customer", allCus, new TimeSpan(0, 0, 30));
            }

            return allCus;
        }

        /// <summary>
        /// Gets a specific Customer based on its ID
        /// </summary>
        /// <param name="id">ID of the selected Customer</param>
        /// <returns>The selected Customer</returns>
        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer GetCustomerByID(int id)
        {
            return _bl.GetCustomerByID(id);
        }

        /// <summary>
        /// Adds a Customer to the database
        /// </summary>
        /// <param name="_username">UserName of the new Customer</param>
        /// <param name="_email">Email Address of the new Customer</param>
        /// <param name="_password">Password for the new account</param>
        /// <returns>Action result showing the success or failure of the code</returns>
        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult PostCustomer(string _username, string _email, string _password)
        {
            try
            {
                Customer ncust = new Customer(_username, _password, _email);
                _bl.AddCustomer(_username, _email, _password);
                return Created("Successfully added", ncust);
            }
            catch(DuplicateException ex)
            {
                return Conflict(ex.Message);
            }
        }

        /// <summary>
        /// Login for a customer
        /// </summary>
        /// <param name="username">username of the user</param>
        /// <param name="email">email input</param>
        /// <param name="password">password input</param>
        /// <returns>Action result relating to the validity of the info</returns>
        [HttpGet("{username} {email} {password}")]
        public ActionResult CustomerLogin(string username, string email, string password)
        {
            if (_bl.Login(username, email, password))
            {
                return Ok("Welcome!");
            }
            else
            {
                return BadRequest("Who are you?");
            }
        }

        /// <summary>
        /// Adds a COrderHistoryID to a Customer
        /// </summary>
        /// <param name="id">ID of the selected customer</param>
        /// <param name="value">COrderHistoryID</param>
        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void PutIntoCustomer(int id, int value)
        {
            _bl.PutCOHIDIntoCustomer(id, value);
        }

        /// <summary>
        /// Deletes a customer from the database
        /// </summary>
        /// <param name="lostCustomer">Customer that will be deleted</param>
        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void DeleteCustomer([FromBody] Customer lostCustomer)
        {
            _bl.DeleteCustomer(lostCustomer.UserName);
        }
    }
}
