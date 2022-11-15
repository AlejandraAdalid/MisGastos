using API.DTOs;
using DATOS.Entidades;
using Microsoft.AspNetCore.Mvc;
using NEGOCIO.Servicios;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {

        private CategoriaService _categoriaService;

        public CategoriasController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public List<Categorias> GetAll(string? nombre)
        {
            return _categoriaService.GetAll(nombre);
        }
        [HttpGet("{id}")]
        public Categorias GetOne(int id)
        {
            return _categoriaService.GetOne(id);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CategoriaDto categoria)
        {
            var categoriaParaElService = new Categorias { Nombre = categoria.Nombre };
            _categoriaService.CrearCategoria(categoriaParaElService);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoriaService.Delete(id);
        }

        [HttpPut("{id}")]
        public Categorias Update(int id, [FromBody] CategoriaDto categoria)
        {
            var cat = new Categorias { Id = id, Nombre = categoria.Nombre };
            return _categoriaService.Update(cat);
        }
    }
}