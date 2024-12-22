using FabricaGestao.Api.Dados.Contexto;
using FabricaGestao.Api.Extencoes;
using FabricaGestao.Api.Modelos;
using FabricaGestao.Api.ViewModelos.Categorias;
using FabricaGestao.Api.ViewModelos.Respostas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaGestao.Api.Controllers;

[Authorize]
[ApiController]
public class CategoriaController(ContextoDados contexto) : ControllerBase
{
    [HttpGet]
    [Route("v1/categorias")]
    public async Task<IActionResult> BuscarTodasCategorias()
    {
        try
        {
            var categorias = await contexto.TbCategorias
                .AsNoTracking()
                .ToListAsync();
            
            return categorias.Any() 
                ? Ok(new RespostaViewModelo<List<CategoriaModelo>>(categorias)) 
                : NotFound(new RespostaViewModelo<CategoriaModelo>("Não foi possível encontrar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<List<CategoriaModelo>>("Falha interna no servidor"));
        }
    }
    
    [HttpGet]
    [Route("v1/categorias/{categoria}")]
    public async Task<IActionResult> BuscarCategoria(string categoria)
    {
        try
        {
            var categorias = await contexto.TbCategorias
                .AsNoTracking()
                .Where(x => x.CatNome.ToLower().Contains(categoria.ToLower()))
                .ToListAsync();
            
            return categorias.Any()
                ? Ok(new RespostaViewModelo<List<CategoriaModelo>>(categorias))
                : NotFound(new RespostaViewModelo<CategoriaModelo>("Não foi possivel encontrar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<CategoriaModelo>("Falha interna no servidor"));
        }
    }

    [HttpGet]
    [Route("v1/categorias/{id:int}")]
    public async Task<IActionResult> BuscarUmaCategoria(int id)
    {
        try
        {
            var categoria = await contexto.TbCategorias
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CatId == id);
            
            if (categoria == null)
                return NotFound(new RespostaViewModelo<CategoriaModelo>("Não foi possível encontrar"));

            return Ok(new RespostaViewModelo<CategoriaModelo>(categoria));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<CategoriaModelo>("Falha interna no servidor"));
        }
    }
    
    [HttpPost]
    [Route("v1/categorias")]
    public async Task<IActionResult> AdicionarCategoria(EditorCategoriaViewModelo modelo)
    {
        if (!ModelState.IsValid)
            return BadRequest(new RespostaViewModelo<CategoriaModelo>(ModelState.ObterEstadoDeErros()));
        
        try
        {
            var categoria = new CategoriaModelo
            {
                CatNome = modelo.CatNome,
                CatIncPor = modelo.CatIncPor = 1,
                CatIncEm = modelo.CatIncEm = DateTime.Now
            };

            await contexto.TbCategorias.AddAsync(categoria);
            await contexto.SaveChangesAsync();

            return Created($"v1/categorias/{categoria.CatId}", new RespostaViewModelo<CategoriaModelo>(categoria));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<CategoriaModelo>("Não foi possível adicionar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<CategoriaModelo>("Falha interna no servidor"));
        }
    }

    [HttpPut]
    [Route("v1/categorias/{id:int}")]
    public async Task<IActionResult> AtualizarCategoria(int id, EditorCategoriaViewModelo modelo)
    {
        if (!ModelState.IsValid)
            return BadRequest(new RespostaViewModelo<CategoriaModelo>(ModelState.ObterEstadoDeErros()));
        
        try
        {
            var categoria = await contexto.TbCategorias.FirstOrDefaultAsync(x => x.CatId == id);

            if (categoria == null)
                return NotFound(new RespostaViewModelo<CategoriaModelo>("Não foi possível encontrar"));

            categoria.CatNome = modelo.CatNome;
            categoria.CatAltPor = 33;
            categoria.CatAltEm = DateTime.Now;

            contexto.TbCategorias.Update(categoria);
            await contexto.SaveChangesAsync();

            return Ok(new RespostaViewModelo<CategoriaModelo>(categoria));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<CategoriaModelo>("Não foi possível atualizar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<CategoriaModelo>("Falha interna no servidor"));
        }
    }

    [HttpDelete]
    [Route("v1/categorias/{id:int}")]
    public async Task<IActionResult> ApagarCategoria(int id)
    {
        try
        {
            var categoria = await contexto.TbCategorias.FirstOrDefaultAsync(x => x.CatId == id);

            if (categoria == null)
                return NotFound(new RespostaViewModelo<CategoriaModelo>("Não foi possível encontrar"));

            contexto.TbCategorias.Remove(categoria);
            await contexto.SaveChangesAsync();

            return Ok(new RespostaViewModelo<CategoriaModelo>(categoria));
        }
        catch(DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<CategoriaModelo>("Não foi possível apagar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<CategoriaModelo>("Falha interna no servidor"));
        }
    }
}