using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_KevinCoto_API.Data;
using Proyecto_KevinCoto_API.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_KevinCoto_API.Controllers
{
    [Route("Datos/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly ApiDBContext context;
        public ProveedoresController(ApiDBContext context)
        {
            this.context = context;
        }
      //  private static ProveedoresData data = new ProveedoresData();
        // GET: api/<ProveedoresController>
        #region MetodoGet
        //[HttpGet]
        //public List<Proveedor> Get()
        //{
        //    List<Proveedor> list = new List<Proveedor>();
        //    list = data.ListarProveedores();
        //    return list;
        //}
        #endregion
        [HttpGet]
        public List<Proveedor> Get()
        {
            List<Proveedor> list = context.Proveedor.ToList();
            return list;
        }

        // GET api/<ProveedorsController>/5
        #region MetodoGetporID
        //[HttpGet("{id}")]
        //public Proveedor Get(string id)
        //{
        //    Proveedor provider = data.BuscarProveedor(id);
        //    return provider;
        //}
        #endregion
        [HttpGet("{id}")]
        public Proveedor Get(string id)
        {
            Proveedor provider = context.Proveedor.Find(id);
            return provider;
        }



        // POST api/<ProveedorsController>
        #region metodoPost
        //[HttpPost]
        //public IActionResult Post([FromBody] Proveedor provider)
        //{
        //    var resultado = data.AgregarProveedor(provider);
        //    if (resultado)
        //        return Ok(provider);
        //    else
        //        return BadRequest();
        //}
        #endregion
        [HttpPost]
        public IActionResult Post([FromBody] Proveedor provider)
        {
            context.Proveedor.Add(provider);
            context.SaveChanges();
            return Ok(provider);
        }

        // PUT api/<ProveedorsController>/5
        #region MetodoPut
        //[HttpPut]
        //public IActionResult Put([FromBody] Proveedor provider)
        //{
        //    if (data.EditarProveedor(provider))
        //        return Ok(provider);
        //    else
        //        return BadRequest();

        //}
        #endregion
        [HttpPut]
        public IActionResult Put([FromBody] Proveedor provider)
        {
            context.Entry(provider).State = EntityState.Modified;
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
        // DELETE api/<ProveedorsController>/5
        #region MetodoDelete
        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id)
        //{
        //    if (data.EliminarProveedor(id))
        //        return Ok();
        //    else
        //        return BadRequest();
        //}
        #endregion
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (context.Proveedor == null)
            {
                return BadRequest();
            }
            Proveedor provider = context.Proveedor.Find(id);
            if (provider == null)
            {
                return BadRequest();
            }
            context.Proveedor.Remove(provider);
            context.SaveChanges();
            return Ok();
        }
    }
}
