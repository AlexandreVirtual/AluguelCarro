
using AluguelCarro.AcessoDados.Interfaces;
using AluguelCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluguelCarro.AcessoDados.Repositorios
{
    public class EnderecoRepositorio : RepositorioGenerico<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}