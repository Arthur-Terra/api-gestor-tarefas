using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProjetoDB.Models
{
    public class Personagem
    {
        [Key]
        public int Id {get; set;}

        [Required (ErrorMessage ="Nome é um campo obrigatorio")]
        [MaxLength(150 ,ErrorMessage = "Nome pdoe ter no maximo 150 caracteres")]
        public string Nome {get;set;}

        [Required (ErrorMessage ="Tipo é um campo obrigatorio")]
        [MaxLength(150 ,ErrorMessage = "tipo pdoe ter no maximo 150 caracteres")]
        public string Tipo {get;set;}
        
    }
}