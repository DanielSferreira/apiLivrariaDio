using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api_livraria_dio.Models;
using api_livraria_dio.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_livraria_dio.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        LivroService ls;
        public LivrosController(LivroService livro)
        {
            ls = livro;
        }

        /// <summary>
        /// Buscar todos os livros de forma paginada
        /// </summary>
        /// <remarks>
        /// Não é possível retornar os livros sem paginação
        /// </remarks>
        /// <param name="pagina">Indica qual página está sendo consultada. Mínimo 1</param>
        /// <param name="quantidade">Indica a quantidade de reistros por página. Mínimo 1 e máximo 50</param>
        /// <response code="200">Retorna uma lista com livros </response>
        /// <response code="204">Retorna nada </response>   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroView>>> Get([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var obj = await ls.Obter(pagina, quantidade);

            if (obj.Count() == 0)
                return NoContent();

            return Ok(obj);
        }

        /// <summary>
        /// Buscar o livro pelo id
        /// </summary>
        /// <remarks>
        /// sem o id 
        /// </remarks>
        /// <param name="id">Id do livro a ser encontrado</param>
        /// <response code="200">Retorna um livro</response>
        /// <response code="204">Retorna nada</response>   
        [HttpGet("{id}")]
        public async Task<ActionResult<LivroView>> Get(int id)
        {
            var obj = await ls.Obter(id);

            if (obj == null)
                return NoContent();

            return Ok(obj);
        }

        /// <summary>
        /// Insere um novo livro no banco de dados
        /// </summary>
        /// <remarks>
        /// Insere um livro usando o LivroModel e retorna um LivroView
        /// </remarks>
        /// <param name="livro">Objeto com os dados</param>
        /// <response code="200">Retorna o likvro criado</response>
        /// <response code="422">Retorna erro de livro criado</response>   
        [HttpPost]
        public async Task<ActionResult<LivroView>> Post([FromBody] LivroModel livro)
        {
            try
            {
                var obj = await ls.Inserir(livro);

                return Ok(obj);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Atualiza um novo livro no banco de dados
        /// </summary>
        /// <remarks>
        /// Com o id do livro é possivel buscar e atualizalo separadamente do objeto
        /// </remarks>
        /// <param name="id">Id do livro a ser encontrado</param>
        /// <param name="livro">Objeto com os dados</param>
        /// <response code="200">Retorna o livro com as alterações </response>
        /// <response code="204">Retorna nada</response>   
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] LivroModel livro)
        {
            try
            {
                await ls.Atualizar(id, livro);

                return Ok(livro);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Atualiza o preço de um livro 
        /// </summary>
        /// <remarks>
        /// Atualiza o preço de um livro com id do mesmo
        /// </remarks>
        /// <param name="id">Id do livro a ser encontrado</param>
        /// <param name="preco">Novo preço para ser atualizado</param>
        /// <response code="200">Retorna o livro com as alterações</response>
        /// <response code="204">Retorna nada</response>   
        [HttpPatch("{id}/preco/{preco}")]
        public async Task<ActionResult> Patch(int id, double preco)
        {
            
            try
            {
                await ls.Atualizar(id, preco);

                return Ok("O valor foi atualizado com sucesso");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        
        /// <summary>
        /// Atualiza o quantidade de um livro 
        /// </summary>
        /// <remarks>
        /// Atualiza o quantidade de um livro com id do mesmo
        /// </remarks>
        /// <param name="id">Id do livro a ser encontrado</param>
        /// <param name="quant">Quantidade atualizada</param>
        /// <response code="200">Retorna o livro com as alterações</response>
        /// <response code="204">Retorna nada</response>    
        [HttpPatch("{id}/quantidade/{quant}")]
        public async Task<ActionResult> QuantPatch(int id, int quant)
        {
            
            try
            {
                await ls.Atualizar(id, quant);

                return Ok("O valor foi atualizado com sucesso");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Remove de um livro 
        /// </summary>
        /// <remarks>
        /// Remove de um livro com id do mesmo
        /// </remarks>
        /// <param name="id">Id do livro a ser encontrado</param>
        /// <response code="200">Retorna o livro que foi apagado</response>
        /// <response code="204">Retorna nada</response>
        [HttpDelete()]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await ls.Remover(id);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}