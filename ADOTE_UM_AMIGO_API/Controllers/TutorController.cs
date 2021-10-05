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
    [Route("api/tutor")]
    public class TutorController : ControllerBase
    {
        private readonly DataContext _context;
        public TutorController(DataContext context)
        {
            _context = context;
        }

        // POST: api/tutor/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] Tutor tutor)
        {   
            _context.Tutores.Add(tutor);
            await _context.SaveChangesAsync();
            return Created("Cadastro Realizado com sucesso", tutor);
        }

        // GET: api/tutor/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ListAsync() => 
        Ok(await _context.Tutores);

        // GET: api/tutor/getbyid/5
        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            Tutor tutor = await _context.Tutores.FindAsync(id);
            if (tutor != null)
            {
                return Ok(tutor);
            }
            return NotFound("Nenhum dado encontrado com esse ID");
        }

        // DELETE: api/tutor/delete/"nome do tutor"
        [HttpDelete]
        [Route("delete/{name}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string name)
        {
            Tutor tutor = _context.Tutores.FirstOrDefault
            (
                tutor => tutor.Nome == name
            );
            _context.Tutores.Remove(tutor);
            await _context.SaveChangesAsync();
            return Ok("Registro Removido com sucesso");
        }

        // PUT: api/tutor/delete/
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Tutor tutor)
        {
            _context.Tutores.Update(tutor);
            await _context.SaveChangesAsync();
            return Ok(tutor);
        }
    }
}