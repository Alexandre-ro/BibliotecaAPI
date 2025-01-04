using BibliotecaAPI.DTO.Autor;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();

        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int id);

        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int id);

        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDTO autorDTO);

        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDTO autorDTO);

        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int id);
    }
}
