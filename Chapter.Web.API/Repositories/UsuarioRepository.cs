using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter.Web.API.Contexts;
using Chapter.Web.API.Entities.Usuarios;
using Chapter.Web.API.Interfaces;

namespace Chapter.Web.API.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    
    private readonly ChapterContext _context;

    public UsuarioRepository(ChapterContext context)
    {
        _context = context;
    }

    public IEnumerable<Usuario> Listar() => _context.Usuarios.ToList();

    public Usuario BuscarPorId(int id) => _context.Usuarios.Find(id);

    public void Atualizar(Usuario usuario, int id)
    {
        Usuario UsuarioExistente = _context.Usuarios.Find(id);
        UsuarioExistente.Nome = usuario.Nome;
        UsuarioExistente.Email = usuario.Email;
        UsuarioExistente.Endereco = usuario.Endereco;

        _context.SaveChanges();
    }

    public void Cadastrar(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public void Deletar(int id)
    {
        _context.Remove(_context.Usuarios.Find(id));
        _context.SaveChanges();
    }

}