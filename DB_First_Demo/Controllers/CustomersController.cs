using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DB_First_Demo.Models;
using Castle.Core.Resource;

namespace DB_First_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly BikeStoresContext _context;

        public CustomersController(BikeStoresContext context)
        {
            _context = context;
        }

        [HttpGet("{customerId:int}/lazy")]
        public async Task<ActionResult> GetCustomersLazyLoading(int customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);

            if (customer == null)
            {
                return NotFound();
            }

            // Access the Orders navigation property to trigger lazy loading
            var orders = customer.Orders.Count;
            var firstOrderDetails = customer.Orders.FirstOrDefault()?.OrderItems.Count;

            return Ok(
                new
                {
                    Customer = $"{customer.FirstName} {customer.LastName}",
                    OrdersCount = orders,
                    FirstOrderItems = firstOrderDetails ?? 0
                });
        }

        [HttpGet("{customerId:int}/eager")]
        public async Task<ActionResult> GetCustomersByeagerLoading(int customerId)
        {
            //var customer = await _context.Customers
            //    .Include(c => c.Orders)
            //    .ThenInclude(o => o.OrderItems)
            //     .FirstOrDefaultAsync(c => c.CustomerId == customerId);
            //if (customer == null)
            //{
            //    return NotFound();
            //}
            //var result = new
            //{
            //    Customer = $"{customer.FirstName} {customer.LastName}",
            //    OrdersCount = customer.Orders.Count,
            //    FirstOrderItems = customer.Orders.FirstOrDefault()?.OrderItems.Count ?? 0
            //};
            //return Ok(result);
            var cust=await _context.Customers
                                .Where(c => c.CustomerId == customerId)
                                .Include(c => c.Orders)
                                .ThenInclude(o => o.OrderItems)
                                .ThenInclude(oi => oi.Product)
                                .AsSplitQuery()
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

            var result =  cust.Orders
                .OrderByDescending(o => o.OrderDate)
                .Select(o1 => new
                {
                    o1.OrderId,
                    o1.OrderDate,
                    o1.OrderStatus,
                    Items = o1.OrderItems.Select(oi => new
                    {
                        oi.Product.ProductName,
                        oi.Quantity,
                        oi.ListPrice,
                        oi.Discount
                    })
                }).ToList();
            return Ok(result);

        }


        [HttpGet("{customerId:int}/explicit")]
        public async Task<ActionResult> GetCustomersByExplicitLoading(int customerId)
        {
            var cust= await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId==customerId);
            if(cust is null) return NotFound();
            await _context.Entry(cust).Collection(c => c.Orders).LoadAsync();
            var orders = cust.Orders
                .OrderByDescending(o => o.OrderDate).FirstOrDefault();
            if(orders is null) return Ok(new { Message = "No Orders" });
            await _context.Entry(orders).Collection(o => o.OrderItems).LoadAsync();
            await _context.Entry(orders).Collection(o => o.OrderItems)
                .Query()
                .Include(oi => oi.Product)
                .LoadAsync();
            var result = new
            {
                Customer = $"{cust.FirstName} {cust.LastName}",
                OrdersCount = cust.Orders.Count,
                FirstOrderItems = orders.OrderItems.Select(oi => new
                {
                    oi.Product.ProductName,
                    oi.Quantity,
                    oi.ListPrice,
                    oi.Discount
                })
            };

            return Ok(result);

        }
            // GET: api/Customers
            [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
