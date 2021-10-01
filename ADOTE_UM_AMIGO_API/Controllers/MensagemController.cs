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
    [Route("api/mensagem")]
    public class MensagemControler : ControllerBase
    {
        private readonly DataContext _context;
        public MensagemControler(DataContext context)
        {
            _context = context;
        }

        // POST: api/mensagem/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] Mensagem mensagem)
        {
            _context.Mensagens.Add(mensagem);
            await _context.SaveChangesAsync();
            return Created("Mensagem Enviada com sucesso", mensagem);
        }

        // GET: api/mensagem/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ListAsync() => Ok(await _context.Mensagens.ToListAsync());

        // GET: api/mensagem/getbyid/5
        // Implementar também busca por Id_sender
        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            Mensagem mensagem = await _context.Mensagens.FindAsync(id);
            if (mensagem != null)
            {
                return Ok(mensagem);
            }
            return NotFound("Nenhuma Mensagem encontrada com esse ID");
        }

        // DELETE: api/mensagem/delete/"Id_sender"
        [HttpDelete]
        [Route("delete/{name}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int name)
        {
            Mensagem mensagem = _context.Mensagens.FirstOrDefault
            (
                mensagem => mensagem.Id_Sender == name
            );
            _context.Mensagens.Remove(mensagem);
            await _context.SaveChangesAsync();
            return Ok("Registro Removido com sucesso");
        }

        // PUT: api/mensagem/delete/
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Mensagem mensagem)
        {
            _context.Mensagens.Update(mensagem);
            await _context.SaveChangesAsync();
            return Ok(mensagem);
        }
    }
}