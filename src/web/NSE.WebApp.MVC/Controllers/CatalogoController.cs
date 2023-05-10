using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using NSE.WebApp.MVC.Services;

namespace NSE.WebApp.MVC.Controllers
{
    public class CatalogoController : MainController
    {

        private readonly ICatalogoServiceRefit _catalogoSerivce;

        public CatalogoController(ICatalogoServiceRefit catalagoService)
        {
            _catalogoSerivce = catalagoService;
        }

        [HttpGet]
        [Route("")]
        [Route("vitrine")]
        public async Task<IActionResult> Index()
        {
            var produtos = await _catalogoSerivce.ObterTodos();

            return View(produtos);
        }

        [HttpGet]
        [Route("produto-detalhe/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id)
        {
            var produto = await  _catalogoSerivce.ObterPorId(id);

            return View(produto);
        }
    }
}
