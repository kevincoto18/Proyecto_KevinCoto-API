using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_KevinCoto_API.Data;
using Proyecto_KevinCoto_API.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_KevinCoto_API.Controllers
{
    [Route("Datos/[controller]")]
    [ApiController]
    public class FacturasGeneralesController : ControllerBase
    {
        private readonly ApiDBContext context;
        public FacturasGeneralesController(ApiDBContext context)
        {
            this.context = context;
        }
        //  private static FacturaGeneralData data = new FacturaGeneralData();
        // GET: api/<FacturasGeneralesController>
        #region MetodoGet
        //[HttpGet]
        //public List<FacturaGeneral> Get()
        //{
        //    List<FacturaGeneral> list = new List<FacturaGeneral>();
        //    list = data.ListarFacturaGenerals();
        //    return list;
        //}
        #endregion
        [HttpGet]
        public List<FacturaGeneral> Get()
        {
            List<FacturaGeneral> list = context.FacturaGeneral.ToList();
            return list;
        }

        // GET api/<FacturasGeneralesController>/5
        #region metodogetporID
        //[HttpGet("{id}")]
        //public FacturaGeneral Get(string id)
        //{
        //    FacturaGeneral factura = data.BuscarFacturaGeneral(id);
        //    return factura;
        //}
        #endregion
        [HttpGet("{id}")]
        public FacturaGeneral Get(string id)
        {
            FacturaGeneral General = context.FacturaGeneral.Find(id);
            return General;
        }

        // POST api/<FacturasGeneralesController>
        #region MetodoPost
        //[HttpPost]
        //public IActionResult Post([FromBody] FacturaGeneral factura)
        //{
        //    var resultado = data.AgregarFacturaGeneral(factura);
        //    if (resultado)
        //        return Ok(factura);
        //    else
        //        return BadRequest();
        //}
        #endregion
        [HttpPost]
        public IActionResult Post([FromBody] FacturaGeneral factura)
        {
            bool agregado;
            bool comprobarexistencia = false;
            try
            {
                foreach (var i in context.FacturaGeneral.ToList())
                {
                    if (i.Id_Cliente == factura.Id_Cliente && i.activo == "Activa")
                    {
                        comprobarexistencia = true;
                    }
                }
                if (!comprobarexistencia)
                {
                    string Date = DateTime.Now.ToString("dd-MM-yyyy");

                    FacturaGeneral FacturaNueva = new FacturaGeneral();
                    FacturaNueva.Id = factura.Id;
                    FacturaNueva.Id_Cliente = factura.Id_Cliente;

                    FacturaNueva.fecha = Date;
                    FacturaNueva.activo = "Activa";
                    context.FacturaGeneral.Add(FacturaNueva);
                    context.SaveChanges();
                    agregado = true;
                }
                else

                    agregado = true;
            }
            catch (Exception)
            {

                agregado = false;
            }
            if (agregado)
            {
                return Ok(factura);
            }
            else
                return BadRequest();
        }

        // PUT api/<FacturasGeneralesController>/5
        #region metodoPut
        //[HttpPut]
        //public IActionResult Put([FromBody] FacturaGeneral factura)
        //{
        //    if (data.EditarFacturaGeneral(factura))
        //        return Ok(factura);
        //    else
        //        return BadRequest();

        //}
        #endregion
        [HttpPut]
        public IActionResult Put([FromBody] FacturaGeneral factura)
        {
            context.Entry(factura).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;

            }
            return Ok();

        }

        // DELETE api/<FacturaGeneralsController>/5
        #region MetodoDelete
        //[HttpDelete("{id}")]
        //public IActionResult Delete(string factura)
        //{
        //    if (data.EliminarFacturaGeneral(factura))
        //        return Ok();
        //    else
        //        return BadRequest();
        //}
        #endregion
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (context.FacturaGeneral == null)
            {
                return BadRequest();
            }
            FacturaGeneral general = context.FacturaGeneral.Find(id);
            if (general == null)
            {
                return BadRequest();
            }
            var ejemplo = context.FacturaDetalle.Where(p => p.Id_FacturaGeneral == general.Id).ToList();
            context.FacturaGeneral.Remove(general);
            context.FacturaDetalle.RemoveRange(ejemplo);
            context.SaveChanges();
            return Ok();
        }
    }
}
