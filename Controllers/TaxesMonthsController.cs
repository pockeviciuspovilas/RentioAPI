using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentioAPI.Models;

namespace RentioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxesMonthsController : ControllerBase
    {
        private readonly RentioDBContext _context;

        public TaxesMonthsController(RentioDBContext context)
        {
            _context = context;
        }

        // GET: api/TaxesMonths
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxesMonth>>> Get()
        {
            return await _context.TaxesMonth.ToListAsync();
        }

        // GET: api/TaxesMonths/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxesMonth>> Get(int id)
        {
            var taxesMonth = await _context.TaxesMonth.FindAsync(id);

            if (taxesMonth == null)
            {
                return NotFound();
            }

            return taxesMonth;
        }

        // GET: api/TaxesMonths/5/Tax/5
        [Route("{monthId:int}/Tax/{taxId:int}")]
        public ActionResult<Tax> Get(int monthId, int taxId)
        {
            var taxesMonth = _context.TaxesMonth.Where(x => x.Id == monthId).FirstOrDefault();

            if (taxesMonth == null)
            {
                return NotFound();
            }
            else
            {
                var tax = _context.Tax.Include(x => x.TaxesMonth).Where(x => x.Id == taxId).FirstOrDefault();
                if (tax == null)
                {
                    return NotFound();
                }
                return tax;
            }

        }


        // PUT: api/TaxesMonths/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TaxesMonth taxesMonth)
        {
            if (id != taxesMonth.Id)
            {
                return BadRequest();
            }

            _context.Entry(taxesMonth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxesMonthExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/TaxesMonths
        [HttpPost]
        public async Task<ActionResult<TaxesMonth>> Post(TaxesMonth taxesMonth)
        {
            _context.TaxesMonth.Add(taxesMonth);
            await _context.SaveChangesAsync();

            return taxesMonth;
        }

        // DELETE: api/TaxesMonths/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaxesMonth>> Delete(int id)
        {
            var taxesMonth = await _context.TaxesMonth.FindAsync(id);
            if (taxesMonth == null)
            {
                return NotFound();
            }

            _context.TaxesMonth.Remove(taxesMonth);
            await _context.SaveChangesAsync();

            return taxesMonth;
        }

        private bool TaxesMonthExists(int id)
        {
            return _context.TaxesMonth.Any(e => e.Id == id);
        }
    }
}
