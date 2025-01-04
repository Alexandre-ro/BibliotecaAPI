using BibliotecaAPI.DTO.Livro;
using BibliotecaAPI.Models;
using BibliotecaAPI.Services.Livro;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;

        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<List<LivroModel>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();

            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId")]
        public async Task<ActionResult<LivroModel>> BuscarLivroPorId(int id)
        {
            var livro = await _livroInterface.BuscarLivrosPorAutorId(id);

            return Ok(livro);
        }

        [HttpGet("BuscarLivrosPorAutorId")]
        public async Task<ActionResult<List<LivroModel>>> BuscarLivrosPorAutorId(int idAutor)
        {
            var livros = await _livroInterface.BuscarLivrosPorAutorId(idAutor);

            return Ok(livros);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<List<LivroModel>>> CriarLivro(LivroCriacaoDTO livroDTO)
        {
            var livros = _livroInterface.CriarLivro(livroDTO);

            return Ok(livros);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<LivroModel>> EditarLivro(LivroEdicaoDTO livroDTO)
        {
            var livros = await _livroInterface.EditarLivro(livroDTO);

            return Ok(livros);
        }

        [HttpDelete]
        public async Task<ActionResult<List<LivroModel>>> ExcluirLivro(int id)
        {
            var livros = await _livroInterface.ExcluirLivro(id);

            return Ok(livros);
        }


    }
}
