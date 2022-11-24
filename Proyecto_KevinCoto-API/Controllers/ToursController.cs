using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_KevinCoto_API.Data;
using Proyecto_KevinCoto_API.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_KevinCoto_API.Controllers
{
    [Route("Datos/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly ApiDBContext context;
        public ToursController(ApiDBContext context)
        {
            this.context = context;
        }
        private static ToursData data = new ToursData();
        // GET: api/<ToursController>
        #region metodoget
        //[HttpGet]
        //public List<Tour> Get()
        //{
        //    List<Tour> list = new List<Tour>();
        //    list = data.ListarTour();
        //    return list;
        //}
        #endregion
        [HttpGet]
        public List<Tour> Get()
        {
            List<Tour> list = context.Tour.ToList();
            return list;
        }

        // GET api/<ToursController>/5
        #region MetodoGetporID
        //[HttpGet("{id}")]
        //public Tour Get(string id)
        //{
        //    Tour tour = data.BuscarTour(id);
        //    return tour;
        //}
        #endregion
        [HttpGet("{id}")]
        public Tour Get(string id)
        {
            Tour tour = context.Tour.Find(id);
            return tour;
        }

        // POST api/<ToursController>
        #region metodoPost
        //[HttpPost]
        //public IActionResult Post([FromBody] Tour tour)
        //{
        //    data.AgregarTour(tour);
        //    return Ok(tour);
        //}
        #endregion
        [HttpPost]
        public IActionResult Post([FromBody] Tour tour)
        {
            context.Tour.Add(tour);
            context.SaveChanges();
            return Ok(tour);
        }

        // PUT api/<ToursController>/5
        #region metodoput
        //[HttpPut]
        //public IActionResult Put([FromBody] Tour tour)
        //{
        //    if (data.EditarTour(tour))
        //        return Ok(tour);
        //    else
        //        return BadRequest();
        //}
        #endregion
        [HttpPut]
        public IActionResult Put([FromBody] Tour tour)
        {
            context.Entry(tour).State = EntityState.Modified;
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
        // DELETE api/<ToursController>/5
        #region metododelete
        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id)
        //{
        //    data.EliminarTour(id);
        //    return Ok();
        //}
        #endregion
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (context.Tour == null)
            {
                return NotFound();
            }
            Tour tour = context.Tour.Find(id);
            if (tour == null)
            {
                return NotFound();
            }
            context.Tour.Remove(tour);
            context.SaveChanges();
            return Ok();
        }
    }
}
