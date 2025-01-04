using BibliotecaAPI.DTO.Autor;
using BibliotecaAPI.Models;
using BibliotecaAPI.Services.Autor;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private IAutorInterface _autorInterface;

        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();

            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId")]
        public async Task<ActionResult<AutorModel>> BuscarAutorPorId(int id)
        {
            var autor = await _autorInterface.BuscarAutorPorId(id);

            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorIdLivro")]
        public async Task<ActionResult<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            var autor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);

            return Ok(autor);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<List<AutorModel>>> CriarAutor(AutorCriacaoDTO autorDTO)
        {
            var autores = await _autorInterface.CriarAutor(autorDTO);

            return Ok(autores);
        }

        [HttpDelete("DeletarAutor")]
        public async Task<ActionResult<List<AutorModel>>> DeletarAutor(int id)
        {
            var autores = await _autorInterface.ExcluirAutor(id);

            return Ok(autores);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<List<AutorModel>>> EditarAutor(AutorEdicaoDTO autorDTO)
        {
            var autores = await _autorInterface.EditarAutor(autorDTO);

            return Ok(autores);

        }

    }
}
