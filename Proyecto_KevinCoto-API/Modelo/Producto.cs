namespace Proyecto_KevinCoto_API.Modelo
{
    public class Producto
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public int anoingreso { get; set; }
        public int precio { get; set; }

        public string Proveedor_id { get; set; }
    }
}
