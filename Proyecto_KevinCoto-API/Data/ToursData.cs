using Proyecto_KevinCoto_API.Modelo;

namespace Proyecto_KevinCoto_API.Data
{
    public class ToursData
    {
        public static List<Tour> ListaTours;
        public ToursData()
        {
            ListaTours = new List<Tour>();
        }
        public List<Tour> ListarTour()
        {

            return ListaTours;
        }

        public Tour BuscarTour(string Id)
        {
            foreach (Tour tour in ListaTours)
            {
                if (tour.Id == Id)
                {
                    return tour;
                }
            }
            return null;
        }
        //METODO PARA AGREGAR UN Tour A LA LISTA
        public bool AgregarTour(Tour tour)
        {
            bool agregado;
            try
            {
                ListaTours.Add(tour);
                agregado = true;
            }
            catch (Exception)
            {
                agregado = false;

            }
            return agregado;
        }

        // METODO PARA ELIMINAR UN Tour DE LA LISTA
        public bool EliminarTour(string Id)
        {
            bool eliminado;
            try
            {
                ListaTours.RemoveAll(x => x.Id == Id);
                eliminado = true;
            }
            catch (Exception)
            {
                eliminado = false;

            }

            return eliminado;
        }
        // Editar un Tour de la lista 
        public bool EditarTour(Tour tour)
        {
            bool editado;
            try
            {
                bool encontrado = false;
                var id = tour.Id;
                foreach (var i in ListaTours)
                {
                    if (i.Id == id)
                        encontrado = true;
                }
                if (encontrado)
                {
                    try
                    {
                        ListaTours.RemoveAll(x => x.Id == id);
                        ListaTours.Add(tour);
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
