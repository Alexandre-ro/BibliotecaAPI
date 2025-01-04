using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BibliotecaAPI.Models
{
    public class AutorModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("sobrenome")]
        public string SobreNome { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<LivroModel> Livros { get; set; }
    }
}
