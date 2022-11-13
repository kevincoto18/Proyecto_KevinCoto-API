using Proyecto_KevinCoto_API.Controllers;
using Proyecto_KevinCoto_API.Modelo;

namespace Proyecto_KevinCoto_API.Data
{
    public class FacturaGeneralData
    {
        public static List<FacturaGeneral> ListaFacturaGenerals;
        public FacturaGeneralData()
        {
            ListaFacturaGenerals = new List<FacturaGeneral>();

        }
        public List<FacturaGeneral> ListarFacturaGenerals()
        {

            return ListaFacturaGenerals;
        }
        public FacturaGeneral BuscarFacturaGeneral(string Id)
        {
            foreach (FacturaGeneral factura in ListaFacturaGenerals)
            {
                if (factura.Id == Id)
                {
                    return factura;
                }
            }
            return null;
        }
        //METODO PARA AGREGAR UN FacturaGeneral A LA LISTA
        public bool AgregarFacturaGeneral(FacturaGeneral factura)
        {
            bool agregado;
            bool comprobarexistencia = false;
            try
            {
                foreach(var i in ListaFacturaGenerals)
                {
                    if(i.Id_Cliente == factura.Id_Cliente && i.activo == "Activa")
                    {
                        comprobarexistencia = true;
                    }
                }
                if (!comprobarexistencia)
                {
                   

                  
                    string Date = DateTime.Now.ToString("dd-MM-yyyy");

                    FacturaGeneral FacturaNueva = new FacturaGeneral();
                    FacturaNueva.Id = factura.Id;
                    FacturaNueva.Id_Cliente = factura.Id_Cliente;
                    
                    FacturaNueva.fecha = Date;
                    FacturaNueva.activo = "Activa";
                    ListaFacturaGenerals.Add(FacturaNueva);
                    CacheFactura.factura.Add(FacturaNueva);
                    agregado = true;
                }
                else

                    agregado = true;


            }
            catch (Exception)
            {
                agregado = false;

            }
            return agregado;
        }

        // METODO PARA ELIMINAR UN FacturaGeneral DE LA LISTA
        public bool EliminarFacturaGeneral(string Id)
        {
            bool eliminado;
            try
            {
                ListaFacturaGenerals.RemoveAll(x => x.Id == Id);
                eliminado = true;
            }
            catch (Exception)
            {
                eliminado = false;

            }

            return eliminado;
        }
        // Editar un FacturaGeneral de la lista 
        public bool EditarFacturaGeneral(FacturaGeneral factura)
        {
            bool editado;
            try
            {
                bool encontrado = false;
                var id = factura.Id;
                foreach (var i in ListaFacturaGenerals)
                {
                    if (i.Id == id)
                        encontrado = true;
                }
                if (encontrado)
                {
                    try
                    {
                        ListaFacturaGenerals.RemoveAll(x => x.Id == id);
                        ListaFacturaGenerals.Add(factura);
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
