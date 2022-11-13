using Microsoft.AspNetCore.Mvc;
using Proyecto_KevinCoto_API.Data;
using Proyecto_KevinCoto_API.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_KevinCoto_API.Controllers
{
    [Route("Datos/[controller]")]
    [ApiController]
    public class FacturasGeneralesController : ControllerBase
    {
        private static FacturaGeneralData data = new FacturaGeneralData();
        // GET: api/<FacturasGeneralesController>
        [HttpGet]
        public List<FacturaGeneral> Get()
        {
            List<FacturaGeneral> list = new List<FacturaGeneral>();
            list = data.ListarFacturaGenerals();
            return list;
        }

        // GET api/<FacturasGeneralesController>/5
        [HttpGet("{id}")]
        public FacturaGeneral Get(string id)
        {
            FacturaGeneral factura = data.BuscarFacturaGeneral(id);
            return factura;
        }

        // POST api/<FacturasGeneralesController>
        [HttpPost]
        public IActionResult Post([FromBody] FacturaGeneral factura)
        {
            var resultado = data.AgregarFacturaGeneral(factura);
            if (resultado)
                return Ok(factura);
            else
                return BadRequest();
        }

        // PUT api/<FacturasGeneralesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] FacturaGeneral factura)
        {
            if (data.EditarFacturaGeneral(factura))
                return Ok(factura);
            else
                return BadRequest();

        }

        // DELETE api/<FacturaGeneralsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string factura)
        {
            if (data.EliminarFacturaGeneral(factura))
                return Ok();
            else
                return BadRequest();
        }
    }
}
