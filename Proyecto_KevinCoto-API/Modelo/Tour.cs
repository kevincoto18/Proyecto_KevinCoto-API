using System.ComponentModel.DataAnnotations;

namespace Proyecto_KevinCoto_API.Modelo
{
    public class Tour
    {
        [Required]
        [Key]
        [StringLength(50, ErrorMessage = "Logitud máxima 50")]
        public string Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Logitud máxima 50")]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Logitud máxima 50")]
        public string imagen { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Logitud máxima 50")]
        public string dias { get; set; }
        public string precio { get; set; }

        public string Id_Proveedor { get; set; }
    }
}
