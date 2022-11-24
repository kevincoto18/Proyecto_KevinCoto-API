using System.ComponentModel.DataAnnotations;

namespace Proyecto_KevinCoto_API.Modelo
{
    public class Proveedor
    {
        [Key]
        public string id { get; set; }
        public string descripcion { get; set; }
    }
}
