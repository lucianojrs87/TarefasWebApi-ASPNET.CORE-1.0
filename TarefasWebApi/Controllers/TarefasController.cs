using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TarefasWebApi;
using TarefasWebApi.Models;
using TarefasWebApi.Models.Enums;
using Microsoft.AspNetCore.Mvc.Routing;

namespace TarefasWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tarefas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas()
        {
            try
            {
                return StatusCode(200, await _context.Tarefas.ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Tarefa>> GetTarefa(int codigo)
        {
            var tarefa = await _context.Tarefas.FindAsync(codigo);

            if (tarefa == null)
            {
                return NotFound(
                    "Código de tarefa inexistente em nossa base de dados.");
            }
            else
            {
                return StatusCode(200, tarefa);
            }
        }

        [HttpPost]

        public async Task<ActionResult> PostTarefa(Tarefa tarefa)
        {
            if (TarefaExists(tarefa.Codigo))
            {
                return BadRequest("O código já existe na nossa base de dados.");
            }


            tarefa.Status = Status.Pendente;

            if (tarefa.Descricao == null)
            {
                return BadRequest(
                    "Descrição da tarefa não pode ser nula.");
            }

            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarefa", new { codigo = tarefa.Codigo }, tarefa);
        }

        [HttpPut("{codigo}")]

        public async Task<ActionResult> PutTarefa(int codigo, Tarefa tarefa)
        {
            if (codigo != tarefa.Codigo)
            {
                return BadRequest("Não é permitido alterar o código.");
            }

            if (tarefa.Status == Status.Pendente)
            {
                return BadRequest("O Status só poderá ser passado para o status CONCLUÍDO");
            }

            if (tarefa.Descricao == null)
            {
                return BadRequest(
                    "Descrição da tarefa não pode ser nula.");
            }

            _context.Entry(tarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(codigo))
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

        private bool TarefaExists(int codigo)
        {
            return _context.Tarefas.Any(e => e.Codigo == codigo);
        }
    }
}
