using BibliotecaAPI.Data;
using BibliotecaAPI.DTO.Autor;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private AppDbContext _context;

        public AutorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autores = await _context.Autores.ToListAsync();

                resposta.Dados = autores;                
                resposta.Mensagem = "Todos os autores foram coletados";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int id)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == id);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado.";
                    return resposta;
                }

                resposta.Dados = autor;
                resposta.Mensagem = "Autor localizado";
                resposta.Status = true;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            var livro = await _context.Livros.Include(a => a.Autor)
                                             .FirstOrDefaultAsync(l => l.Id == idLivro);
            try
            {
                if (livro == null)
                {
                    resposta.Mensagem = "O Autor não foi encontrado.";
                    return resposta;
                }

                resposta.Dados = livro.Autor;
                resposta.Mensagem = "O Autor foi encontrado.";
                resposta.Status = true;

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }

        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDTO autorDTO)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = new AutorModel()
                {
                    Nome = autorDTO.Nome,
                    SobreNome = autorDTO.SobreNome
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "O Autor foi criado com sucesso.";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDTO autorDTO)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == autorDTO.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "O Autor não foi encontrado.";
                    return resposta;
                }

                autor.Nome = autorDTO.Nome;
                autor.SobreNome = autorDTO.SobreNome;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                var autores = _context.Autores.ToList();

                resposta.Dados = autores;
                resposta.Mensagem = "O Autor foi atualizado com sucesso.";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int id)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == id);

                if (autor == null)
                {
                    resposta.Mensagem = "O Autor não foi encontrado.";
                    return resposta;
                }

                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();

                var autores = await _context.Autores.ToListAsync();

                resposta.Dados = autores;
                resposta.Mensagem = "O Autor foi excluído com sucesso.";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }
    }
}
