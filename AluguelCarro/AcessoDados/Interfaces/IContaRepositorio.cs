using AluguelCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluguelCarro.AcessoDados.Interfaces
{
    public interface IContaRepositorio: IRepositorioGenerico<Conta>
    {
        new Task<IEnumerable<Conta>> PegarTodos();
        int PegarSaldoPeloId(string Id);
    }
}
