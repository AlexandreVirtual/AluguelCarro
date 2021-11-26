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

namespace AluguelCarro.Controllers
{
    public class ContasController : Controller
    {
        private readonly IContaRepositorio _contaRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ILogger<ContasController> _logger;

        public ContasController(IContaRepositorio contaRepositorio, IUsuarioRepositorio usuarioRepositorio, ILogger<ContasController> logger)
        {
            _contaRepositorio = contaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _logger = logger;
        }
                
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Listando os saldos");
            return View(await _contaRepositorio.PegarTodos());
        }
        
        // GET: Contas/Create
        public IActionResult Create()
        {
            _logger.LogInformation("Criar novo saldo");
            ViewData["UsuarioId"] = new SelectList(_usuarioRepositorio.PegarTodos(), "Id", "Email");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContaId,UsuarioId,Saldo")] Conta conta)
        {
            if (ModelState.IsValid)
            {
                await _contaRepositorio.Inserir(conta);
                _logger.LogInformation("Novo saldo criado");
                return RedirectToAction(nameof(Index));
            }
            _logger.LogError("informações inválidas");
            ViewData["UsuarioId"] = new SelectList(_usuarioRepositorio.PegarTodos(), "Id", "Email", conta.UsuarioId);
            return View(conta);
        }

        // GET: Contas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            _logger.LogInformation("Atualizar conta");

            var conta = await _contaRepositorio.PegarPeloId(id);
            if (conta == null)
            {
                _logger.LogError("Conta não encontrada");
                return NotFound();
            }
            _logger.LogError("Info. Inválida");
            ViewData["UsuarioId"] = new SelectList(_usuarioRepositorio.PegarTodos(), "Id", "Email", conta.UsuarioId);
            return View(conta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContaId,UsuarioId,Saldo")] Conta conta)
        {
            if (id != conta.ContaId)
            {
                _logger.LogError("Conta não encontrada");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _contaRepositorio.Atualizar(conta);

                _logger.LogInformation("Atualizar conta");

                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(await _contaRepositorio.PegarTodos(), "Id", "Email", conta.UsuarioId);
            return View(conta);
        }
        public async Task<JsonResult> Delete(int id)
        {
            _logger.LogInformation("Excluindo conta");
            await _contaRepositorio.Excluir(id);
            _logger.LogInformation("Conta excluída");
            return Json("Conta excluída");
        }
    }
}
