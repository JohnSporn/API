﻿using System;
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
    public class RecurringExpensesController : ControllerBase
    {
        private readonly APIContext _context;

        public RecurringExpensesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/RecurringExpenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecurringExpense>>> GetRecurringExpense()
        {
            return await _context.RecurringExpense.ToListAsync();
        }

        // GET: api/RecurringExpenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecurringExpense>> GetRecurringExpense(int id)
        {
            var recurringExpense = await _context.RecurringExpense.FindAsync(id);

            if (recurringExpense == null)
            {
                return NotFound();
            }

            return recurringExpense;
        }

        // PUT: api/RecurringExpenses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecurringExpense(int id, RecurringExpense recurringExpense)
        {
            if (id != recurringExpense.Id)
            {
                return BadRequest();
            }

            _context.Entry(recurringExpense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecurringExpenseExists(id))
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

        // POST: api/RecurringExpenses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecurringExpense>> PostRecurringExpense(RecurringExpense recurringExpense)
        {
            _context.RecurringExpense.Add(recurringExpense);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecurringExpense", new { id = recurringExpense.Id }, recurringExpense);
        }

        // DELETE: api/RecurringExpenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecurringExpense(int id)
        {
            var recurringExpense = await _context.RecurringExpense.FindAsync(id);
            if (recurringExpense == null)
            {
                return NotFound();
            }

            _context.RecurringExpense.Remove(recurringExpense);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecurringExpenseExists(int id)
        {
            return _context.RecurringExpense.Any(e => e.Id == id);
        }
    }
}