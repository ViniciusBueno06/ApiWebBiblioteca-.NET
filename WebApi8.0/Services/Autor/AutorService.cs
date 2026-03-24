using Microsoft.EntityFrameworkCore;
using WebApi8._0.Data;
using WebApi8._0.Dto.Autor;
using WebApi8._0.Models;

namespace WebApi8._0.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorIdLivro(int idLivro)
        {
            //criando o objeto de resposta
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var livro = await _context.Livros
                                            .Include(a => a.Autor)
                                            .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                //Tabela Livros -> JOIN em Autor no Objeto Livro -> verifica se bate o id livro
                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado.";
                    return resposta;
                }

                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Autor encontrado!";
                return resposta;
            }
            catch (Exception ex) {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;    
            }

        }

       

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            //criando o objeto de resposta
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);
            
                if(autor == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado.";
                     
                    return resposta;
                }
                resposta.Dados = autor;
                resposta.Mensagem = "Autor localizado!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {

                var autor = new AutorModel()
                {
                    Nome = autorCriacaoDto.Nome,
                    SobreNome = autorCriacaoDto.SobreNome
                };
                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = autor;
                resposta.Mensagem = "Autor criado com sucesso!";
                return resposta;

            }
            catch (Exception ex) { 
                resposta.Mensagem= ex.Message;
                resposta.Status = false;
                return resposta;    
            }
        }

        public async Task<ResponseModel<AutorModel>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorEdicaoDto.Id);


                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado";
                    return resposta;
                }
                autor.Nome = autorEdicaoDto.Nome;
                autor.SobreNome = autorEdicaoDto.SobreNome;

                _context.Update(autor);
                await _context.SaveChangesAsync();
                resposta.Dados = autor;
                resposta.Mensagem = "Autor alterado com sucesso!";
                return resposta;

            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado";
                    return resposta;
                }

                _context.Remove(autor);
                await _context.SaveChangesAsync();

                resposta.Mensagem = "Autor excluido com sucesso";

                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            //criando o objeto de resposta
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autores = await _context.Autores.ToListAsync();

                resposta.Dados= autores;

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
