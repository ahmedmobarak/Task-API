using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Task.Bal.Dto;
using Task.Task.Dal.Models;
using Task.Task.Dal.Persistence;

namespace Task.Task.Pal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomersController(AppDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Customers
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var res = _context.Customers.Include(c => c.Invoices).ToList();
            var customers = _mapper.Map<List<Customer>, List<CustomerResponseDto>>(res);
            return Ok(customers);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var res = _context.Customers.Include(c => c.Invoices).Where(c => c.CustomerId == id).FirstOrDefault();
            var customer = _mapper.Map<Customer, CustomerResponseDto>(res);


            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
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
        public IActionResult PostCustomer(CustomerDto customer)
        {
            var mappedCustomer = _mapper.Map<Customer>(customer);
            _unitOfWork.Customers.Add(mappedCustomer);
            _unitOfWork.Complete();

            return Ok(mappedCustomer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _unitOfWork.Customers.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            _unitOfWork.Customers.Remove(customer);
            _unitOfWork.Complete();

            return NoContent();
        }

        [Route("count")]
        [HttpGet]
        public IActionResult CustomersCount()
        {
            return Ok(_unitOfWork.Customers.Count());
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
