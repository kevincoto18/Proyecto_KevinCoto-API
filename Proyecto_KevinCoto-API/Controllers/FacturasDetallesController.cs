using Microsoft.AspNetCore.Mvc;
using Proyecto_KevinCoto_API.Data;
using Proyecto_KevinCoto_API.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_KevinCoto_API.Controllers
{
    [Route("Datos/[controller]")]
    [ApiController]
    public class FacturasDetallesController : ControllerBase
    {
        // GET: api/<FacturasDetallesController>
        private static FacturaDetalleData data = new FacturaDetalleData();
        // GET: api/<FacturasGeneralesController>
        [HttpGet]
        public List<FacturaDetalle> Get()
        {
            List<FacturaDetalle> list = new List<FacturaDetalle>();
            list = data.ListarFacturaDetalles();
            return list;
        }

        // GET api/<FacturasDetallesController>/5
        [HttpGet("{id}")]
        public List<FacturaDetalle> Get(string id)
        {
            List<FacturaDetalle> factura = data.BuscarFacturaDetalle(id);
            return factura;
        } 
       

        // POST api/<FacturasDetallesController>
        [HttpPost]
        public IActionResult Post([FromBody] FacturaDetalle factura)
        {
            var resultado = data.AgregarFacturaDetalle(factura);
            if (resultado)
                return Ok(factura);
            else
                return BadRequest();
        }

        // PUT api/<FacturasDetallesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] FacturaDetalle factura)
        {
            if (data.EditarFacturaDetalle(factura))
                return Ok(factura);
            else
                return BadRequest();

        }

        // DELETE api/<FacturasDetallesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (data.EliminarFacturaDetalle(id))
                return Ok();
            else
                return BadRequest();
        }

     
    }
}
