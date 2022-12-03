using System.ComponentModel.DataAnnotations;

namespace Proyecto_KevinCoto_API.Modelo
{
    public class FacturaDetalle
    {
      
        //  public string IdCliente { get; set; }
        public string Id_FacturaGeneral { get; set; }
        [Key]
        public string Id_Servicio { get; set; }
        public string NombreServicio { get; set; }
        public string Categoria { get; set; }
        public string Precio { get; set; }
    }
}
