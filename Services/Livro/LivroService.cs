using BibliotecaAPI.Data;
using BibliotecaAPI.DTO.Livro;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;
        
        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros.Include(a => a.Autor)
                                                  .ToListAsync();

                resposta.Dados = livros;
                resposta.Mensagem = "Os Livros foram encontrados com sucesso.";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }
        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int id)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == id);

                if (livro == null)
                {
                    resposta.Mensagem = "O Livro não foi encontrado.";                   
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "O Livro foi encontrado.";
               
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivrosPorAutorId(int idAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros.Include(a => a.Autor)
                                                  .Where(livro => livro.Autor.Id == idAutor)
                                                  .ToListAsync();

                if (livros == null)
                {
                    resposta.Mensagem = "Nenhum Livro foi encontrado.";

                    return resposta;
                }

                resposta.Mensagem = "A Consulta foi realizada com sucesso.";
                resposta.Dados = livros.ToList();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDTO livroDTO)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == livroDTO.Autor.Id);

                if (autor == null) 
                {
                    resposta.Mensagem = "O Autor informado não foi encontrado na base de dados.";
                    return resposta;
                }

                var livro = new LivroModel()
                {
                    Autor = livroDTO.Autor,
                    Titulo = livroDTO.Titulo

                };

                _context.Add(livro);

                await _context.SaveChangesAsync();

                var livros = await _context.Livros.ToListAsync();

                resposta.Mensagem = "O Livro foi inserido com sucesso";
                resposta.Dados = livros;

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDTO livroDTO)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == livroDTO.Autor.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "O Autor informado não foi encontrado na base de dados.";
                    return resposta;
                }

                var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == livroDTO.Id);

                if (livro == null)
                {
                    resposta.Mensagem = "O Livro não foi encontrado.";
                    return resposta;
                }

                livro.Autor = livroDTO.Autor;
                livro.Titulo = livroDTO.Titulo;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                var livros = await _context.Livros.ToListAsync();

                resposta.Mensagem = "O Livro foi atualizado com sucesso.";
                resposta.Dados = livros;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int id)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == id);

                if (livro == null)
                {
                    resposta.Mensagem = "O Livro não foi encontrado.";
                    return resposta;
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();

                var livros = await _context.Livros.ToListAsync();

                resposta.Mensagem = "O Livro foi removido com sucesso.";
                resposta.Dados = livros;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;

                return resposta;
            }
        }

    }
}
