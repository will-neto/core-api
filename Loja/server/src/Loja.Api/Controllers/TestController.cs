using System.Collections.Generic;
using System.Threading.Tasks;
using Loja.Domain.Categorias;
using Microsoft.AspNetCore.Mvc;


namespace Loja.Api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public TestController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            var categorias = await _categoriaRepository.ListarAsync();

            return Json(categorias);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
