using System.Collections.Generic;
using Chapter.Web.API.Entities.Usuarios;

namespace Chapter.Web.API.Interfaces;

public interface IUsuarioRepository
{
    IEnumerable<Usuario> Listar();
    Usuario BuscarPorId(int id);
    void Cadastrar(Usuario usuario);
    void Atualizar(Usuario usuario, int id);
    void Deletar(int id);
}