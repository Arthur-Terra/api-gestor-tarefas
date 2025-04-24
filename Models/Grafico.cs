using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDB.Models
{
    public class Grafico
    {
        [Key, ForeignKey("Usuario")]
        public int Id_Usuario { get; set; }

        public int Total_Tarefas { get; set; } = 0;
        public int Tarefas_Pendentes { get; set; } = 0;
        public int Tarefas_Concluidas { get; set; } = 0;
        public int Tarefas_Atrasadas { get; set; } = 0;

        public Usuario Usuario { get; set; }
    }
}
