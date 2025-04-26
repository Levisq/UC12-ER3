using System.Collections.Generic;
using Chapter.Web.API.Entities.Livros;

namespace Chapter.Web.API.Repositories.Interfaces;

public interface ILivroRepository
{
    IEnumerable<Livro> Listar();
    Livro BuscarPorId(int id);
    void Cadastrar(Livro livro);
    void Atualizar(int id, Livro livro);
    void Deletar(int id);
}