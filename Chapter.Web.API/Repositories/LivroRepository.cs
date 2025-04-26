
using Chapter.Web.API.Contexts;
using Chapter.Web.API.Entities.Livros;
using Chapter.Web.API.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
namespace Chapter.Web.Api.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly ChapterContext _context;

    public LivroRepository(ChapterContext context)
    {
        _context = context;
    }

    public IEnumerable<Livro> Listar() => _context.Livros.ToList();

    public Livro BuscarPorId(int id) => _context.Livros.Find(id);
 
    public void Cadastrar(Livro l)
    {
        _context.Livros.Add(l);
        _context.SaveChanges();
    }

    public void Atualizar(int id, Livro l)
    {
        Livro livroExistente = _context.Livros.Find(id);
        livroExistente.Titulo = l.Titulo;
        livroExistente.QuantidadePaginas = l.QuantidadePaginas;
        livroExistente.Estoque = l.Estoque;

        _context.SaveChanges();
    }

    public void Deletar(int id)
    {
        _context.Livros.Remove(_context.Livros.Find(id));
        _context.SaveChanges();
    }

}