using Microsoft.AspNetCore.Mvc;
using Proyecto_KevinCoto_API.Data;
using Proyecto_KevinCoto_API.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_KevinCoto_API.Controllers
{
    [Route("Datos/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private static ProductosData data = new ProductosData();
        // GET: api/<ProductosController>
        [HttpGet]
        public List<Producto> Get()
        {
            List<Producto> list = new List<Producto>();
            list = data.ListarProductos();
            return list;
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public Producto Get(string id)
        {
            Producto product = data.BuscarProducto(id);
            return product;
        }

        // POST api/<ProductosController>
        [HttpPost]
        public IActionResult Post([FromBody] Producto product)
        {
            data.AgregarProducto(product);
            return Ok(product);
        }

        // PUT api/<ProductosController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Producto product)
        {
            if (data.EditarProducto(product))
                return Ok(product);
            else
                return BadRequest();
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            data.EliminarProducto(id);
            return Ok();
        }
    }
}
