using BibliotecaAPI.DTO.Livro;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int id);
        Task<ResponseModel<List<LivroModel>>> BuscarLivrosPorAutorId(int idAutor);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDTO livroDTO);
        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int id);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDTO livroDTO);
    }
}
