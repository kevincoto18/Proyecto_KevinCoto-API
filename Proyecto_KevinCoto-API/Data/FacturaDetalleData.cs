using Proyecto_KevinCoto_API.Modelo;

namespace Proyecto_KevinCoto_API.Data
{
    public class FacturaDetalleData
    {

        public static List<FacturaDetalle> ListaFacturaDetalles;
        public FacturaDetalleData()
        {
            ListaFacturaDetalles = new List<FacturaDetalle>();

        }
        public List<FacturaDetalle> ListarFacturaDetalles()
        {

            return ListaFacturaDetalles;
        }
        public List<FacturaDetalle> BuscarFacturaDetalle(string Id)
        {
            List<FacturaDetalle> detalles = new List<FacturaDetalle>();
            foreach (FacturaDetalle factura in ListaFacturaDetalles)
            {
                if (factura.Id_FacturaGeneral == Id)
                {
                    detalles.Add(factura);  
                }
            }
            return detalles;
        }

        public List<FacturaDetalle> BuscarFacturaDetallePorID(string Id)
        {
            List<FacturaDetalle> listaporid = new List<FacturaDetalle>();
            foreach (FacturaDetalle factura in ListaFacturaDetalles)
            {
                if (factura.Id_FacturaGeneral == Id)
                {
                    listaporid.Add(factura);
                }
            }

            return listaporid;
        }
        //METODO PARA AGREGAR UN FacturaDetalle A LA LISTA
        public bool AgregarFacturaDetalle(FacturaDetalle factura)
        {
            
            bool agregado;
            bool encontrado = false;
            var ejemplo = Modelo.CacheFactura.factura;
            try
            {
                foreach (var i in ejemplo)
                {
                    if(i.Id == factura.Id_FacturaGeneral && i.activo == "Activa")
                    {
                        encontrado = true;
                    }
                }
                if (encontrado)
                {
                    ListaFacturaDetalles.Add(factura);
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

        // METODO PARA ELIMINAR UN FacturaDetalle DE LA LISTA
        public bool EliminarFacturaDetalle(string Id)
        {
            bool eliminado;
            try
            {
                ListaFacturaDetalles.RemoveAll(x => x.Id_Servicio == Id);
                eliminado = true;
            }
            catch (Exception)
            {
                eliminado = false;

            }

            return eliminado;
        }
        // Editar un FacturaDetalle de la lista 
        public bool EditarFacturaDetalle(FacturaDetalle factura)
        {
            bool editado;
            try
            {
                bool encontrado = false;
                var id = factura.Id_FacturaGeneral;
                foreach (var i in ListaFacturaDetalles)
                {
                    if (i.Id_FacturaGeneral == id)
                        encontrado = true;
                }
                if (encontrado)
                {
                    try
                    {
                        ListaFacturaDetalles.RemoveAll(x => x.Id_FacturaGeneral == id);
                        ListaFacturaDetalles.Add(factura);
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
