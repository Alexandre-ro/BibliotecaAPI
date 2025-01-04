using BibliotecaAPI.Models;

namespace BibliotecaAPI.DTO.Livro
{
    public class LivroEdicaoDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public AutorModel Autor { get; set; }
    }
}
