using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fist_api.Models;
using fist_api.Context;

namespace fist_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
        }

        [HttpGet]
        public IActionResult List()
        {
            var contatos = _context.Contatos.ToList();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contato contato)
        {
            var contatoExistente = _context.Contatos.Find(id);

            if (contatoExistente == null)
            {
                return NotFound();
            }

            contatoExistente.Nome = contato.Nome;
            contatoExistente.Telefone = contato.Telefone;
            contatoExistente.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoExistente);
            _context.SaveChanges();

            return Ok(contatoExistente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contato);
            _context.SaveChanges();

            return NoContent();
        }
    }
}