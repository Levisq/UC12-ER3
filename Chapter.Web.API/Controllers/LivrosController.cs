using Chapter.Web.API.Models;
using Chapter.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Chapter.Web.API.Controllers
{
    /// Controller responsável pelos endpoints (URLs) referentes aos livros
    // Define que o tipo de resposta da API será no formato JSON

    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/livros
    [Route("api/[controller]")]

    // atributo para habilitar comportamentos especificos de API, como status, retorno
    [ApiController]

    [Authorize]
    // [ControllerBase] - requisicoes HTTP
    public class LivrosController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;
        public LivrosController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        // GET /api/livros
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                // retorna no corpo da resposta, a lista de livros
                // retorna o status Ok - 200, sucesso
                return Ok(_livroRepository.Listar());
            }
            catch (System.Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        //HttpGetAtribute /api/livros/1
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            try
            {
                // retorna no corpo da resposta, a lista de livros
                // retorna o status Ok - 200, sucesso
                Livro LivroProcurado = _livroRepository.BuscarPorId(Id);

                if (LivroProcurado == null)
                {
                    return NotFound();
                }
                return Ok(LivroProcurado);

            }
            catch (System.Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        [HttpPost]
        public IActionResult Cadastrar(Livro Livro)
        {
            try
            {
                _livroRepository.Cadastrar(Livro);

                return StatusCode(201);
            }
            catch (System.Exception e)
            {

                throw new Exception(e.Message);
            }

        }


        [HttpPut("{Id}")]

        public IActionResult Atualizar(int id, Livro Livro)
        {
            try
            {
                _livroRepository.Atualizar(id, Livro);

                return StatusCode(204);
            }
            catch (System.Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (System.Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}