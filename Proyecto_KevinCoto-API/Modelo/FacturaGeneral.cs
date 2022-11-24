using System.ComponentModel.DataAnnotations;

namespace Proyecto_KevinCoto_API.Modelo
{
    public class FacturaGeneral
    {
        [Key]
        public string Id { get; set; }
        public string Id_Cliente { get; set; }
        

        public string fecha { get; set; }

        public string activo { get; set; }
    }
}
