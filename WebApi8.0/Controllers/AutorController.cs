using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8._0.Dto.Autor;
using WebApi8._0.Models;
using WebApi8._0.Services.Autor;

namespace WebApi8._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;
        public AutorController(IAutorInterface autorInterface) {

            _autorInterface = autorInterface;

        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();

            return Ok(autores);
        }
        [HttpGet("BuscarAutorPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {

            var autor = await _autorInterface.BuscarAutorPorId(idAutor);
            if (!autor.Status)
                return BadRequest(autor);
            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorIdLivro(int idLivro)
        {
            var autor = await _autorInterface.BuscarAutorIdLivro(idLivro);

            if (!autor.Status)
                return BadRequest(autor);

            return Ok(autor);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacao)
        {
            var autor = await _autorInterface.CriarAutor(autorCriacao);
            if (!autor.Status)
                return BadRequest(autor);
            return CreatedAtAction(nameof(BuscarAutorPorId), new { idAutor = autor.Dados.Id }, autor);
        }

        [HttpDelete("DeletarAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> ExcluirAutor(int idAutor)
        {
            var autor = await _autorInterface.ExcluirAutor(idAutor);

            if (!autor.Status) return NotFound(autor);

            return Ok(autor);

        }

        [HttpPost("EditarAutor")]
       public async Task<ActionResult<ResponseModel<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicao)
        {
            var autor = await _autorInterface.EditarAutor(autorEdicao);

            if (!autor.Status) return NotFound(autor);

            return Ok(autor);
        }
    }
}
