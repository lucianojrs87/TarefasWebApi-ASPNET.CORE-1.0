using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TarefasWebApi.Models.Enums
{
    public enum Status
    {
        [Description("Pendente")]
        Pendente = 1,

        [Description("Concluído")]
        Concluido = 2,
    }
}
