using Microsoft.AspNetCore.Mvc;
using ADOTE_UM_AMIGO_API.Models;
using ADOTE_UM_AMIGO_API.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ADOTE_UM_AMIGO_API.Controllers
{
    [ApiController]
    [Route("api/dog")]
    public class DogController : ControllerBase
    {
        private readonly DataContext _context;
        public DogController(DataContext context)
        {
            _context = context;
        }

        // POST: api/dog/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] Dog dog)
        {
            _context.Dogs.Add(dog);
            await _context.SaveChangesAsync();
            return Created("", dog);
        }

        // GET: api/dog/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ListAsync() => Ok(await _context.Dogs.ToListAsync());

        // GET: api/produto/getbyid/5
        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            Dog dog = await _context.Dogs.FindAsync(id);
            if (dog != null)
            {
                return Ok(dog);
            }
            return NotFound();
        }

        // DELETE: api/dog/delete/"nome do cahorro"
        [HttpDelete]
        [Route("delete/{name}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string name)
        {
            Dog dog = _context.Dogs.FirstOrDefault
            (
                dog => dog.Nome == name
            );
            _context.Dogs.Remove(dog);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT: api/dog/delete/
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Dog dog)
        {
            _context.Dogs.Update(dog);
            await _context.SaveChangesAsync();
            return Ok(dog);
        }
    }
}