using System.Collections.Generic;
using System.Linq;
using Chapter.Web.API.Entities.Livros.Dto;

namespace Chapter.Web.API.Entities.Livros.Mapper;

public static class LivroMapper
{
    public static LivroDto LivroToLivroDto(Livro src)
    {
        return new LivroDto
        {
            Id = src.Id,
            Titulo = src.Titulo,
            QuantidadePaginas = src.QuantidadePaginas,
            Estoque = src.Estoque
        };
    }

    public static List<LivroDto> LivroToLivroDto(this List<Livro> src) 
    {
        return src.Select(LivroToLivroDto).ToList();
    }

    public static Livro LivroInsertDtoToLivro(this LivroInsertDto src) {
        return new Livro 
        {
            Titulo = src.Titulo,
            QuantidadePaginas = src.QuantidadePaginas,
            Estoque = src.Estoque
        };
    }

}