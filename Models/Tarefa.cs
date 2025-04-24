using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDB.Models
{
    public class Tarefa
    {
        [Key]
        public int Id_Tarefa { get; set; }

        [Required]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime Data_Criacao { get; set; } = DateTime.Now;

        public DateTime? Data_Vencimento { get; set; }

        [Required]
        public string Status { get; set; } = "pendente";

        [Required]
        public string Prioridade { get; set; } = "média";

        [ForeignKey("Usuario")]
        public int Id_Usuario { get; set; }

        public Usuario Usuario { get; set; }
    }
}
