using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AluguelCarro.Models;
using AluguelCarro.AcessoDados.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace AluguelCarro.Controllers
{
    [Authorize]
    public class EnderecosController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        private readonly ILogger<EnderecosController> _logger;

        public EnderecosController(IUsuarioRepositorio usuarioRepositorio, IEnderecoRepositorio enderecoRepositorio, ILogger<EnderecosController> logger)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _enderecoRepositorio = enderecoRepositorio;
            _logger = logger;
        }

        public async Task<IActionResult> Create()
        {
            _logger.LogInformation("Novo endereço");
            var usuario = await _usuarioRepositorio.PegarUsuarioLogado(User);
            var endereco = new Endereco { UsuarioId = usuario.Id };
            return View(endereco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnderecoId,Rua,Numero,Bairro,Cidade,Estado,UsuarioId")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                await _enderecoRepositorio.Inserir(endereco);
                _logger.LogInformation("Novo endereço cadastrado");
                return RedirectToAction("Index", "Usuarios");
            }
            _logger.LogError("Erro no cadastro de endereço");
            return View(endereco);
        }

        public async Task<IActionResult> Edit(int id)
        {

            _logger.LogInformation("Atualizando endereço");

            var endereco = await _enderecoRepositorio.PegarPeloId(id);
            if (endereco == null)
            {
                _logger.LogError("Endereço não encontrado");
                return NotFound();
            }
            return View(endereco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnderecoId,Rua,Numero,Bairro,Cidade,Estado,UsuarioId")] Endereco endereco)
        {
            if (id != endereco.EnderecoId)
            {
                _logger.LogError("Endereço não encontrado");
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await _enderecoRepositorio.Atualizar(endereco);
                _logger.LogInformation("Endereço atualizado");
                return RedirectToAction("Index", "Usuarios");
            }
            _logger.LogError("Endereço inválido");
            return View(endereco);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _enderecoRepositorio.Excluir(id);
            _logger.LogInformation("Endereço excluído");
            return Json("Endereço excluído");
        }
    }
}