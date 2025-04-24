using Microsoft.AspNetCore.Mvc;
using ProjetoDB.Data;
using ProjetoDB.Models;
using System.Linq;

namespace ProjetoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraficoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GraficoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id_usuario}")]
        public ActionResult<Grafico> GetGrafico(int id_usuario)
        {
            var grafico = _context.Graficos.FirstOrDefault(g => g.Id_Usuario == id_usuario);
            if (grafico == null)
            {
                return NotFound();
            }
            return Ok(grafico);
        }

        [HttpPost]
        public ActionResult<Grafico> PostGrafico(Grafico grafico)
        {
            _context.Graficos.Add(grafico);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetGrafico), new { id_usuario = grafico.Id_Usuario }, grafico);
        }

        [HttpPut("{id_usuario}")]
        public IActionResult PutGrafico(int id_usuario, Grafico grafico)
        {
            var g = _context.Graficos.FirstOrDefault(g => g.Id_Usuario == id_usuario);
            if (g == null) return NotFound();

            g.Total_Tarefas = grafico.Total_Tarefas;
            g.Tarefas_Pendentes = grafico.Tarefas_Pendentes;
            g.Tarefas_Concluidas = grafico.Tarefas_Concluidas;
            g.Tarefas_Atrasadas = grafico.Tarefas_Atrasadas;

            _context.SaveChanges();
            return NoContent();
        }
    }
}
