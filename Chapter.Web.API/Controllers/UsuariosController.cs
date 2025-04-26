using Chapter.Web.API.Entities.Usuarios;
using Chapter.Web.API.Entities.Usuarios.Dto;
using Chapter.Web.API.Repositories;
using Chapter.Web.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Chapter.Web.API.Controllers;

[Produces("application/json")]

[Route("api/[controller]")]

[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuariosController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        var usuarios = _usuarioService.Listar();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        try
        {
            var usuarioProcurado = _usuarioService.BuscarPorId(id);
            return Ok(usuarioProcurado);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Cadastrar(UsuarioInsertDto dto)
    {
        try
        {
            var usuarioCriado = _usuarioService.Cadastrar(dto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = usuarioCriado.Id }, usuarioCriado);
        }
        catch (ArgumentNullException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(UsuarioInsertDto dto, int id)
    {
        try
        {
            _usuarioService.Atualizar(dto, id);
            return NoContent();
        }
        catch (ArgumentNullException e)
        {
            return BadRequest(e.Message);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        try
        {
            _usuarioService.Deletar(id);
            return NoContent();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest($"Erro ao excluir o usuário: {e.Message}");
        }
    }
}