using Proyecto_KevinCoto_API.Modelo;

namespace Proyecto_KevinCoto_API.Data
{
    public class ProveedoresData
    {
        public static List<Proveedor> ListaProveedor;
        Proveedor provedor = new Proveedor();
        public ProveedoresData()
        {
            ListaProveedor = new List<Proveedor>();
            provedor.id = "01-0123-0456";
            provedor.descripcion = "Proveedor Ministritos";
            ListaProveedor.Add(provedor);

        }

        public List<Proveedor> ListarProveedores()
        {

            return ListaProveedor;
        }
        //METODO PARA BUSCAR UN Proveedor EN CONCRETO EN LA LISTA
        public Proveedor BuscarProveedor(string id)
        {
            foreach (Proveedor user in ListaProveedor)
            {
                if (user.id == id)
                {
                    return user;
                }
            }
            return null;
        }


        //METODO PARA AGREGAR UN Proveedor A LA LISTA
        public bool AgregarProveedor(Proveedor user)
        {
            bool agregado;
            try
            {
                var verificacion = from i in ListaProveedor
                                   where i.id == user.id
                                   select i;
                if (verificacion.Count() < 1)
                {
                    ListaProveedor.Add(user);
                    agregado = true;
                }
                else
                    agregado = false;

            }
            catch (Exception)
            {
                agregado = false;

            }
            return agregado;
        }

        // METODO PARA ELIMINAR UN Proveedor DE LA LISTA
        public bool EliminarProveedor(string id)
        {
            bool eliminado;
            try
            {
                ListaProveedor.RemoveAll(x => x.id == id);
                eliminado = true;
            }
            catch (Exception)
            {
                eliminado = false;

            }

            return eliminado;
        }

        public bool EditarProveedor(Proveedor user)
        {
            bool editado;
            try
            {
                bool encontrado = false;
                var id = user.id;
                foreach (var i in ListaProveedor)
                {
                    if (i.id == id)
                        encontrado = true;
                }
                if (encontrado)
                {
                    try
                    {
                        ListaProveedor.RemoveAll(x => x.id == id);
                        ListaProveedor.Add(user);
                        editado = true;
                    }
                    catch (Exception)
                    {
                        editado = false;
                        throw;
                    }
                }
                else
                {
                    editado = false;
                    return editado;
                }


            }
            catch (Exception)
            {
                editado = false;

            }
            return editado;
        }

    }
}
