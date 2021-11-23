using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluguelCarro.Models
{
    public class Carro
    {
        public int CarroId { get; set; }

        public string Nome { get; set; }

        public string Marca { get; set; }

        public string Foto { get; set; }

        public int PrecoDiaria { get; set; }

        public ICollection<Aluguel> Alugueis { get; set; }
    }
}
