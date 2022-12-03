using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_KevinCoto_API.Data;
using Proyecto_KevinCoto_API.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_KevinCoto_API.Controllers
{
    [Route("Datos/[controller]")]
    [ApiController]
    public class FacturasDetallesController : ControllerBase
    {
        private readonly ApiDBContext context;
        public FacturasDetallesController(ApiDBContext context)
        {
            this.context = context;
        }
        //private static FacturaDetalleData data = new FacturaDetalleData();
        #region metodoget
        //[HttpGet]
        //public List<FacturaDetalle> Get()
        //{
        //    List<FacturaDetalle> list = new List<FacturaDetalle>();
        //    list = data.ListarFacturaDetalles();
        //    return list;
        //}
        #endregion
        [HttpGet]
        public List<FacturaDetalle> Get()
        {
            List<FacturaDetalle> list = context.FacturaDetalle.ToList();
            return list;
        }
        #region metodogetporId
        //// GET api/<FacturasDetallesController>/5
        //[HttpGet("{id}")]
        //public List<FacturaDetalle> Get(string id)
        //{
        //    List<FacturaDetalle> factura = data.BuscarFacturaDetalle(id);
        //    return factura;
        //} 
        #endregion
        // GET api/<FacturasDetallesController>/5
        [HttpGet("{id}")]
        public List<FacturaDetalle> Get(string id)
        {
            List<FacturaDetalle> lista = new List<FacturaDetalle>();
            foreach(FacturaDetalle factura in context.FacturaDetalle.ToList())
            {
                if (factura.Id_FacturaGeneral == id)
                {
                    lista.Add(factura);
                }
            }
           // FacturaDetalle detalle = context.FacturaDetalle.Find(id);
            return lista;
        }
        #region metodopost
        //// POST api/<FacturasDetallesController>
        //[HttpPost]
        //public IActionResult Post([FromBody] FacturaDetalle factura)
        //{
        //    var resultado = data.AgregarFacturaDetalle(factura);
        //    if (resultado)
        //        return Ok(factura);
        //    else
        //        return BadRequest();
        //}
        #endregion

        //// POST api/<FacturasDetallesController>
        [HttpPost]
        public IActionResult Post([FromBody] FacturaDetalle factura)
        {
            bool agregado;
            bool encontrado = false;
            var ejemplo = context.FacturaGeneral.ToList() ;
            try
            {
                foreach (var i in ejemplo)
                {
                    if (i.Id == factura.Id_FacturaGeneral && i.activo == "Activa")
                    {
                        encontrado = true;
                    }
                }
                if (encontrado)
                {
                    context.FacturaDetalle.Add(factura);
                    context.SaveChanges();
                    agregado = true;
                }
                else
                {
                   
                    agregado = false;
                }


            }
            catch (Exception)
            {
                agregado = false;

            }
            if (agregado)
                return Ok(factura);
            else
                return BadRequest();

        }
        #region metodoput
        //// PUT api/<FacturasDetallesController>/5
        //[HttpPut]
        //public IActionResult Put([FromBody] FacturaDetalle factura)
        //{
        //    if (data.EditarFacturaDetalle(factura))
        //        return Ok(factura);
        //    else
        //        return BadRequest();

        //}
        #endregion
        [HttpPut]
        public IActionResult Put([FromBody] FacturaDetalle factura)
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
        #region Metododelete
        //// DELETE api/<FacturasDetallesController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id)
        //{
        //    if (data.EliminarFacturaDetalle(id))
        //        return Ok();
        //    else
        //        return BadRequest();
        //}
        #endregion
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                if (context.FacturaDetalle == null)
                {
                    return BadRequest();
                }
                var listadetalles = context.FacturaDetalle.ToList();
                foreach (var i in listadetalles)
                {
                    if (i.Id_Servicio == id)
                    {
                        context.FacturaDetalle.Remove(i);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }

    }
}
