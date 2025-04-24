using Microsoft.AspNetCore.Mvc;
using ProjetoDB.Data;
using ProjetoDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tarefa>> GetTarefas()
        {
            return Ok(_context.Tarefas.ToList());
        }

        [HttpPost]
        public ActionResult<Tarefa> PostTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTarefas), new { id = tarefa.Id_Tarefa }, tarefa);
        }
    }
}
