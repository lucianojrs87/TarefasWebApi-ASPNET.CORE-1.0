using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TarefasWebApi.Models.Enums;


namespace TarefasWebApi.Models
{
    public class Tarefa
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        public string Descricao { get; set; }
        
        public Status Status { get; set; }
    }
}
