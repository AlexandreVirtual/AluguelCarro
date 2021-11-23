using AluguelCarro.AcessoDados.Interfaces;
using AluguelCarro.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluguelCarro.AcessoDados.Repositorios
{
    public class NivelAcessoRepositorio:RepositorioGenerico<NiveisAcesso>, INivelAcessoRepositorio
    {
        private readonly RoleManager<NiveisAcesso> _gerenciadorNiveisAcesso;
        private readonly Contexto _contexto;

        public NivelAcessoRepositorio(Contexto contexto, RoleManager<NiveisAcesso> gerenciadorNiveisAcesso): base(contexto)
        {
            _contexto = contexto;
            _gerenciadorNiveisAcesso = gerenciadorNiveisAcesso;
        }

        public async Task<bool> NivelAcessoExiste(string nivel)
        {
            return await _gerenciadorNiveisAcesso.RoleExistsAsync(nivel);
        }
    }
}
