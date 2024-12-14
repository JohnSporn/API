using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomesController : ControllerBase
    {
        private readonly APIContext _context;

        public IncomesController(APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Income>>> GetIncome()
        {
            return await _context.Income.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Income>> GetIncome(int id)
        {
            var income = await _context.Income.FindAsync(id);

            if (income == null)
            {
                return NotFound();
            }

            return income;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncome(int id, Income income)
        {
            if (id != income.Id)
            {
                return BadRequest();
            }

            _context.Entry(income).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Income>> PostIncome(Income income)
        {
            _context.Income.Add(income);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncome", new { id = income.Id }, income);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            var income = await _context.Income.FindAsync(id);
            if (income == null)
            {
                return NotFound();
            }

            _context.Income.Remove(income);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncomeExists(int id)
        {
            return _context.Income.Any(e => e.Id == id);
        }
    }
}
