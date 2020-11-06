using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reciclagem.Models;

namespace reciclagem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly StockpileContext _context;

        public MaterialsController(StockpileContext context)
        {
            _context = context;
        }

        // GET: api/Materials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materials>>> GetMaterials()
        {
            return await _context.Materials.ToListAsync();
        }

        // GET: api/Materials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materials>> GetMaterials(int id)
        {
            var materials = await _context.Materials.FindAsync(id);

            if (materials == null)
            {
                return NotFound();
            }

            return materials;
        }

        // PUT: api/Materials/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterials(int id, Materials materials)
        {
            if (id != materials.Id)
            {
                return BadRequest();
            }

            _context.Entry(materials).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialsExists(id))
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

        // POST: api/Materials
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Materials>> PostMaterials(Materials materials)
        {
            _context.Materials.Add(materials);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MaterialsExists(materials.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMaterials", new { id = materials.Id }, materials);
        }

        // DELETE: api/Materials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Materials>> DeleteMaterials(int id)
        {
            var materials = await _context.Materials.FindAsync(id);
            if (materials == null)
            {
                return NotFound();
            }

            _context.Materials.Remove(materials);
            await _context.SaveChangesAsync();

            return materials;
        }

        private bool MaterialsExists(int id)
        {
            return _context.Materials.Any(e => e.Id == id);
        }
    }
}
