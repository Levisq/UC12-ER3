using System;
using System.Collections.Generic;
using System.Linq;
using Chapter.Web.API.Entities.Usuarios;
using Chapter.Web.API.Entities.Usuarios.Dto;
using Chapter.Web.API.Entities.Usuarios.Mapper;
using Chapter.Web.API.Repositories;

namespace Chapter.Web.API.Services;

public class UsuarioService
{

    private readonly UsuarioRepository _usuarioRepository;

    public UsuarioService(UsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public Usuario Cadastrar(UsuarioInsertDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException("Usuário não pode ser nulo.");
        }
        var usuario = UsuarioMapper.UsuarioInsertDtoToUsuario(dto);
        _usuarioRepository.Cadastrar(usuario);
        return usuario;
    }

    public void Atualizar(UsuarioInsertDto dto, int id)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto), "Os dados do usuário não podem ser nulos.");
        }

        var usuario = _usuarioRepository.BuscarPorId(id);
        if (usuario == null)
        {
            throw new KeyNotFoundException($"Usuário com ID {id} não encontrado.");
        }

        _usuarioRepository.Atualizar(UsuarioMapper.UsuarioInsertDtoToUsuario(dto), id);
    }

    public IEnumerable<UsuarioDto> Listar()
    {
        var usuarios = _usuarioRepository.Listar();
        return usuarios.Select(UsuarioMapper.UsuarioToUsuarioDto);
    }

    public UsuarioDto BuscarPorId(int id)
    {
        var usuario = _usuarioRepository.BuscarPorId(id);
        if (usuario == null)
        {
            throw new KeyNotFoundException($"Usuário com ID {id} não encontrado.");
        }
        return UsuarioMapper.UsuarioToUsuarioDto(usuario);
    }

    public void Deletar(int id)
    {
        var usuario = _usuarioRepository.BuscarPorId(id);
        if (usuario == null)
        {
            throw new KeyNotFoundException($"Usuário com ID {id} não encontrado.");
        }

        _usuarioRepository.Deletar(id);
    }

}