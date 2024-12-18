﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUsersController : ControllerBase
    {
        private readonly APIContext _context;

        public SystemUsersController(APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemUser>>> GetSystemUser()
        {
            return await _context.SystemUser.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SystemUser>> GetSystemUser(int id)
        {
            var systemUser = await _context.SystemUser.FindAsync(id);

            if (systemUser == null)
            {
                return NotFound();
            }

            return systemUser;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemUser(int id, SystemUser systemUser)
        {
            if (id != systemUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemUserExists(id))
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
        public async Task<ActionResult<SystemUser>> PostSystemUser(SystemUser systemUser)
        {
            _context.SystemUser.Add(systemUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemUser", new { id = systemUser.Id }, systemUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemUser(int id)
        {
            var systemUser = await _context.SystemUser.FindAsync(id);
            if (systemUser == null)
            {
                return NotFound();
            }

            _context.SystemUser.Remove(systemUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemUserExists(int id)
        {
            return _context.SystemUser.Any(e => e.Id == id);
        }
    }
}
