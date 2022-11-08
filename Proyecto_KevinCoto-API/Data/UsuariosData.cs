using Proyecto_KevinCoto_API.Modelo;

namespace Proyecto_KevinCoto_API.Data
{
    public class UsuariosData
    {
        public static List<Usuario> ListaUsuarios;
        public UsuariosData()
        {
            ListaUsuarios = new List<Usuario>();

        }
        //METODO PARA LISTAR TODOS LOS USUARIOS DE LA LISTA
        public List<Usuario> ListarUsuarios()
        {

            return ListaUsuarios;
        }
        //METODO PARA BUSCAR UN USUARIO EN CONCRETO EN LA LISTA
        public Usuario BuscarUsuario(string cedula)
        {
            foreach (Usuario user in ListaUsuarios)
            {
                if (user.Cedula == cedula)
                {
                    return user;
                }
            }
            return null;
        }
        //METODO PARA AGREGAR UN USUARIO A LA LISTA
        public bool AgregarUsuario(Usuario user)
        {
            bool agregado;
            try
            {
                ListaUsuarios.Add(user);
                agregado = true;
            }
            catch (Exception)
            {
                agregado = false;
              
            }
            return agregado;
        }

        // METODO PARA ELIMINAR UN USUARIO DE LA LISTA
        public bool EliminarUsuario(string cedula)
        {
            bool eliminado;
            try
            {
                ListaUsuarios.RemoveAll(x => x.Cedula == cedula);
                eliminado = true;
            }
            catch (Exception)
            {
                eliminado = false;

            }

            return eliminado;
        }

        public bool EditarUsuario(string cedula, Usuario user)
        {
            bool editado;
            try
            {
                ListaUsuarios.RemoveAll(x => x.Cedula == cedula);
                ListaUsuarios.Add(user);
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
