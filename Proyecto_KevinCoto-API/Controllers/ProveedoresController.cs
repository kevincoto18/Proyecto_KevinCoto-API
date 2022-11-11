using Microsoft.AspNetCore.Mvc;
using Proyecto_KevinCoto_API.Data;
using Proyecto_KevinCoto_API.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_KevinCoto_API.Controllers
{
    [Route("Datos/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private static ProveedoresData data = new ProveedoresData();
        // GET: api/<ProveedoresController>
        [HttpGet]
        public List<Proveedor> Get()
        {
            List<Proveedor> list = new List<Proveedor>();
            list = data.ListarProveedores();
            return list;
        }

        // GET api/<ProveedorsController>/5
        [HttpGet("{id}")]
        public Proveedor Get(string id)
        {
            Proveedor provider = data.BuscarProveedor(id);
            return provider;
        }



        // POST api/<ProveedorsController>
        [HttpPost]
        public IActionResult Post([FromBody] Proveedor provider)
        {
            var resultado = data.AgregarProveedor(provider);
            if (resultado)
                return Ok(provider);
            else
                return BadRequest();
        }

        // PUT api/<ProveedorsController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Proveedor provider)
        {
            if (data.EditarProveedor(provider))
                return Ok(provider);
            else
                return BadRequest();

        }

        // DELETE api/<ProveedorsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (data.EliminarProveedor(id))
                return Ok();
            else
                return BadRequest();
        }
    }
}
