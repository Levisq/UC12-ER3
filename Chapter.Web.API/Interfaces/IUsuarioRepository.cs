using Chapter.Web.API.Models;

namespace Chapter.Web.API.Interfaces
{
    public interface IUsuarioRepository
    {

        Usuarios Login(string email, string senha);

    }
}
