using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluguelCarro.Models
{
    public class Aluguel
    {
        public int AluguelId { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int CarroId { get; set; }
        public Carro Carro { get; set; }

        public string Inicio { get; set; }

        public string Fim { get; set; }

        public int PrecoTotal { get; set; }
    }
}
