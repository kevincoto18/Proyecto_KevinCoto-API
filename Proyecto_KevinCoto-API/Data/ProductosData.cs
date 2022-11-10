using Proyecto_KevinCoto_API.Modelo;

namespace Proyecto_KevinCoto_API.Data
{
    public class ProductosData
    {
        public static List<Producto> ListaProductos;
        public ProductosData()
        {
            ListaProductos = new List<Producto>();

        }
        public List<Producto> ListarProductos()
        {

            return ListaProductos;
        }
        public Producto BuscarProducto(string Id)
        {
            foreach (Producto product in ListaProductos)
            {
                if (product.Id == Id)
                {
                    return product;
                }
            }
            return null;
        }
        //METODO PARA AGREGAR UN Producto A LA LISTA
        public bool AgregarProducto(Producto product)
        {
            bool agregado;
            try
            {
                ListaProductos.Add(product);
                agregado = true;
            }
            catch (Exception)
            {
                agregado = false;

            }
            return agregado;
        }

        // METODO PARA ELIMINAR UN Producto DE LA LISTA
        public bool EliminarProducto(string Id)
        {
            bool eliminado;
            try
            {
                ListaProductos.RemoveAll(x => x.Id == Id);
                eliminado = true;
            }
            catch (Exception)
            {
                eliminado = false;

            }

            return eliminado;
        }
        // Editar un Producto de la lista 
        public bool EditarProducto(string Id, Producto product)
        {
            bool editado;
            try
            {
                ListaProductos.RemoveAll(x => x.Id == Id);
                ListaProductos.Add(product);
                editado = true;
            }
            catch (Exception)
            {
                editado = false;

            }
            return editado;
        }
    }
}
