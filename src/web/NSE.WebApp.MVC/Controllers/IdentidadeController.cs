using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class IdentidadeController : Controller
    {
        private readonly IAutenticacaoServices _autenticacaoServiecs;

        public IdentidadeController(IAutenticacaoServices autenticacaoServiecs)
        {
            _autenticacaoServiecs = autenticacaoServiecs;
        }

        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
        {
            if(!ModelState.IsValid) return View(usuarioRegistro);

            var resposta = await _autenticacaoServiecs.Registro(usuarioRegistro);

            if (false) return View(usuarioRegistro);

            //Realizar o login na App

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return View(usuarioLogin);

            var resposta =  await _autenticacaoServiecs.Login(usuarioLogin);

            if (false) return View(usuarioLogin);

            //Realizar o login na App

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        {
            //limpar os cookies
            return RedirectToAction("Index", "home");
        }

    }
}
