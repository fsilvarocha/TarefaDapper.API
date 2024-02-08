using Microsoft.AspNetCore.Mvc;
using TarefaDapper.API.Interface;
using TarefaDapper.API.Models;

namespace TarefaDapper.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorie _categoria;

        public CategoriaController(ICategoriaRepositorie categoria)
        {
            _categoria = categoria;
        }

        [HttpGet]
        [Route("Categoria")]
        public async Task<IActionResult> GetCategoriaAsync()
        {
            try
            {
                var result = await _categoria.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("CategoriaPorId")]
        public async Task<IActionResult> GetCategoriaByIdAsync(int id)
        {
            try
            {
                var result = await _categoria.GetByIdAsync(id);
                if (result == null)
                    return Ok("Não há resultados para essa pesquisa");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("CategoriaContador")]
        public async Task<IActionResult> GetCategoriaWithCountAsync()
        {
            try
            {
                var result = await _categoria.GetAllWithCountAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CriarCategoria")]
        public async Task<IActionResult> SaveAsync(Categoria categoria)
        {
            try
            {
                var result = await _categoria.SaveAsync(categoria);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("AtualizarCategoria")]
        public async Task<IActionResult> UpdateAsync(Categoria categoria)
        {
            try
            {
                var result = await _categoria.UpdateAsync(categoria);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeletarCategoria")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await _categoria.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
