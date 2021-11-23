using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluguelCarro.Models
{
    public class Conta
    {
        public int ContaId { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int Saldo { get; set; }
    }
}
