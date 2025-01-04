using BibliotecaAPI.Models;

namespace BibliotecaAPI.DTO.Livro
{
    public class LivroCriacaoDTO
    {
        public string Titulo { get; set; } = string.Empty;
        public AutorModel Autor { get; set; }
    }
}
