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

        //Metodo para iniciar sesion en el aplicativo

        public Usuario IniciarSesion(string cedula,string password)
        {
            Usuario user2 = new Usuario();
            foreach (Usuario user in ListaUsuarios)
            {
                if (user.Cedula == cedula && user.password == password)
                {
                    return user;
                }
            }
            
            return user2 ;
        }


        //METODO PARA AGREGAR UN USUARIO A LA LISTA
        public bool AgregarUsuario(Usuario user)
        {
            bool agregado;
            try
            {
                var verificacion = from i in ListaUsuarios
                                   where i.Cedula == user.Cedula
                                   select i;
                if (verificacion.Count() < 1)
                {
                    ListaUsuarios.Add(user);
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

        public bool EditarUsuario(Usuario user)
        {
            bool editado;
            try
            {
                bool encontrado = false;
                var cedula = user.Cedula;
                foreach (var i in ListaUsuarios)
                {
                    if (i.Cedula == cedula)
                        encontrado = true;
                }
                if (encontrado)
                {
                    try
                    {
                        ListaUsuarios.RemoveAll(x => x.Cedula == cedula);
                        ListaUsuarios.Add(user);
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
