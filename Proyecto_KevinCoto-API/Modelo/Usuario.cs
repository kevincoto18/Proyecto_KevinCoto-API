using System.ComponentModel.DataAnnotations;

namespace Proyecto_KevinCoto_API.Modelo
{
    public class Usuario
    {
        [Key]
        public string Cedula { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Logitud máxima 50")]
        public string Nombre_Completo { get; set; }
        [Required]
        public string FechaNacimiento { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Logitud máxima 50")]
        public string profesion { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Logitud máxima 50")]
        public string email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Logitud máxima 50")]

        public string publicacion { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Logitud máxima 50")]
        public string password { get; set; }
    }
}
