using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.Api.Application.Commands;
using Loja.Domain.Categorias;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoriasController : Controller
    {

        private readonly IMediator _mediator;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController(IMediator mediator, ICategoriaRepository categoriaRepository)
        {
            _mediator = mediator;
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        //[Authorize(Policy = "PodeLer")]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            var categorias = await _categoriaRepository.ListarAsync();

            return Json(categorias);
        }

        [HttpGet("{categoriaId}")]
        //[Authorize(Policy = "PodeLer")]
        public async Task<ActionResult<Categoria>> Get(int categoriaId)
        {
            var categoria = await _categoriaRepository.ObterAsync(categoriaId);

            if (categoria != null)
                return Ok(categoria);

            return BadRequest();
        }


        


        [HttpPost]
        public async Task<ActionResult<Categoria>> Post([FromBody] CategoriaCommand categoria)
        {
            var commandResult = await _mediator.Send(categoria);

            if (commandResult.Valido)
                return Ok(new
                {
                    success = true,
                    data = categoria
                });

            return BadRequest(commandResult.Notificacao);

            //return Ok();
        }




        [HttpPut]
        public async Task<ActionResult<Categoria>> Put([FromBody] CategoriaEditarStatusCommand categoria)
        {
            var commandResult = await _mediator.Send(categoria);

            if (commandResult.Valido)
                return Ok(new
                {
                    success = true,
                    data = categoria
                });

            return BadRequest(commandResult.Notificacao);

        }


    }
}