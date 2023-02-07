using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Task.Bal.Dto;
using Task.Task.Dal.Models;
using Task.Task.Dal.Persistence;

namespace Task.Task.Pal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InvoicesController(AppDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Invoices
        [HttpGet]
        public IActionResult GetInvoices()
        {
            var invoices = _context.Invoices.Include(i => i.Customer);
            return Ok(invoices);
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public IActionResult GetInvoice(int id)
        {
            var invoice = _context.Invoices.Include(i => i.Customer).FirstOrDefault(i => i.InvoiceId == id);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (id != invoice.InvoiceId)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
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

        // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostInvoice(InvoiceDto invoice)
        {
            var mappedInvoice = _mapper.Map<Invoice>(invoice);
            _unitOfWork.Invoices.Add(mappedInvoice);
            _unitOfWork.Complete();

            return CreatedAtAction("GetInvoice", new { id = invoice.InvoiceId }, invoice);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public IActionResult DeleteInvoice(int id)
        {
            var invoice = _unitOfWork.Invoices.GetById(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _unitOfWork.Invoices.Remove(invoice);
            _unitOfWork.Complete();

            return NoContent();
        }

        [Route("count")]
        [HttpGet]
        public IActionResult InvoicesCount() 
        {
            return Ok(_unitOfWork.Invoices.Count());
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.InvoiceId == id);
        }
    }
}