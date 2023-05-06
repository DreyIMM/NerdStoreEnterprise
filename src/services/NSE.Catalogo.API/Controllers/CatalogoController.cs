﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Catalogo.API.Models;
using NSE.WebApi.Core.Identidade;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Catalogo.API.Controllers
{
    [ApiController]
    [Authorize]
    public class CatalogoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public CatalogoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [AllowAnonymous]
        [HttpGet("catalogo/produto")]
        public async Task<IEnumerable<Produto>> Index()
        {
            return await _produtoRepository.ObterTodos();
        }

        [ClaimsAuthorize("Catalogo", "Ler")]
        [HttpGet("catalogo/produto/{id}")]
        public async Task<Produto> ProdutoDetalhe(Guid id)
        {
            return await _produtoRepository.ObterPorId(id);
        }

    }
}
