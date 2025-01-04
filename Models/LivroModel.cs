using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAPI.Models
{    
    public class LivroModel
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [Column("autor")]
        public AutorModel Autor { get; set; }
    }
}
