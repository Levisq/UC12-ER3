
using Chapter.Web.API.Contexts;
using Chapter.Web.API.Models;
using System.Collections.Generic;
using System.Linq;
namespace Chapter.WebApi.Repositories
{
    public class LivroRepository
    {
        // possui acesso aos dados
        private readonly ChapterContext _context;
        // somente um data context na memória da aplicação na requisição, evitar o usar o new
        // para o repositório existir, precisa do contexto, a aplicacao cria
        // configurar no startup
        public LivroRepository(ChapterContext context)
        {
            _context = context;
        }
        // retorna a lista de livros
        public List<Livro> Listar()
        {
            // SELECT Id, Titulo, QuantidadePaginas, Disponivel FROM Livros;

            return _context.Livros.ToList();
        }


        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        public void Cadastrar(Livro livro) 
        {
            _context.Livros.Add(livro);

            _context.SaveChanges();
        }

        public void Atualizar(int id, Livro Livro)
        {
            Livro LivroBuscado = _context.Livros.Find(id);
            if (LivroBuscado != null)
            {
                LivroBuscado.Titulo = Livro.Titulo;
                LivroBuscado.QuantidadePaginas = Livro.QuantidadePaginas;
                LivroBuscado.Disponivel = Livro.Disponivel;
            }

            _context.Livros.Update(LivroBuscado);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Livro LivroBuscado = _context.Livros.Find(id);

            _context.Livros.Remove(LivroBuscado);

            _context.SaveChanges();
        }
    }
}
