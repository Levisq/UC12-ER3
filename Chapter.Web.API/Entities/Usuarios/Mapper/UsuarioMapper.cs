using System.Collections.Generic;
using System.Linq;
using Chapter.Web.API.Entities.Usuarios.Dto;
namespace Chapter.Web.API.Entities.Usuarios.Mapper;
public static class UsuarioMapper
{
    public static UsuarioDto UsuarioToUsuarioDto(Usuario src)
    {
        return new UsuarioDto
        {
            Nome = src.Nome,
            Email = src.Email,
            Endereco = src.Endereco
        };
    }

    public static List<UsuarioDto> UsuarioToUsuarioDto(this List<Usuario> src) 
    {
        return src.Select(UsuarioToUsuarioDto).ToList();
    }

    public static Usuario UsuarioInsertDtoToUsuario(UsuarioInsertDto src)
    {
        return new Usuario
        {
            Nome = src.Nome,
            Email = src.Email,
            Endereco = src.Endereco
        };
    }
}