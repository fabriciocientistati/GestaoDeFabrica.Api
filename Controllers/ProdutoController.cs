using FabricaGestao.Api.Dados.Contexto;
using FabricaGestao.Api.Extencoes;
using FabricaGestao.Api.Modelos;
using FabricaGestao.Api.ViewModelos.Produtos;
using FabricaGestao.Api.ViewModelos.Respostas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaGestao.Api.Controllers;

[Authorize]
[ApiController]
public class ProdutoController(ContextoDados contexto) : ControllerBase
{
    [HttpGet]
    [Route("v1/produtos")]
    public async Task<IActionResult> BuscarTodosProdutos()
    {
        try
        {
            var produtos = await contexto.TbProdutos
                .AsNoTracking()
                .ToListAsync();
            
            return produtos.Any() 
                ? Ok(new RespostaViewModelo<List<ProdutoModelo>>(produtos)) 
                : NotFound(new RespostaViewModelo<ProdutoModelo>("Não foi possível encontrar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<ProdutoModelo>("Falha interna no servidor"));
        }
    }
    
    [HttpGet]
    [Route("v1/produtos/{produto}")]
    public async Task<IActionResult> BuscarProduto(string produto)
    {
        try
        {
            var produtos = await contexto.TbProdutos
                .AsNoTracking()
                .Include(x => x.Categoria)
                .Where(x => x.Categoria.CatNome.ToLower().Contains(produto.ToLower()))
                .ToListAsync();

            return produtos.Any()
                ? Ok(new RespostaViewModelo<List<ProdutoModelo>>(produtos))
                : NotFound(new RespostaViewModelo<ProdutoModelo>("Não foi possível encontrar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<ProdutoModelo>("Falha interna no servidor"));
        }
    }
    
    [HttpGet]
    [Route("v1/produtos/categorias/{categoria}")]
    public async Task<IActionResult> BuscarProdutoPorCategoria(string categoria)
    {
        try
        {
            var produtos = await contexto.TbProdutos
                .AsNoTracking()
                .Include(x => x.Categoria)
                .Where(x => x.Categoria.CatNome.ToLower().Contains(categoria.ToLower()))
                .Select(x => new ListarProdutoCategoriaViewModelo
                {
                    ProNome = x.ProNome,
                    ProDesc = x.ProDesc,
                    ProQuantidadeEmEstoque = x.ProQuantidadeEmEstoque,
                    ProPreco = x.ProPreco,
                    ProImagemUrl = x.ProImagemUrl,
                    Categoria = $"Código: {x.CatId}, {x.Categoria.CatNome}"
                }).ToListAsync();

            return produtos.Any() 
                ? Ok(produtos) 
                : NotFound(new RespostaViewModelo<ProdutoModelo>("Não foi possivel encontrar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<ProdutoModelo>("Falha interna no servidor"));
        }
    }
    
    [HttpGet]
    [Route("v1/produtos/{id:int}")]
    public async Task<IActionResult> BuscarUmProduto(int id)
    {
        try
        {
            var produto = await contexto.TbProdutos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProId == id);
            
            if (produto == null)
                return NotFound(new RespostaViewModelo<ProdutoModelo>("Não foi possível encontrar"));

            return Ok(new RespostaViewModelo<ProdutoModelo>(produto));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<ProdutoModelo>("Falha interna no servidor"));
        }
    }

    [HttpPost]
    [Route("v1/produtos")]
    public async Task<IActionResult> AdicionarProduto(ProdutoModelo modelo)
    {
        if (ModelState.IsValid)
            return  BadRequest(new RespostaViewModelo<ProdutoModelo>(ModelState.ObterEstadoDeErros()));
        
        try
        {
            var produto = new ProdutoModelo
            {
                ProNome = modelo.ProNome,
                ProDesc = modelo.ProDesc,
                ProQuantidadeEmEstoque = modelo.ProQuantidadeEmEstoque,
                ProPreco = modelo.ProPreco,
                ProImagemUrl =  modelo.ProImagemUrl,
                CatId = modelo.CatId,
                ProIncPor = modelo.ProIncPor,
                ProIncEm = modelo.ProIncEm = DateTime.Now
            };
            
            await contexto.TbProdutos.AddAsync(produto);
            await contexto.SaveChangesAsync();

            return Created($"v1/produtos/{produto.ProId}", new RespostaViewModelo<ProdutoModelo>(produto));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<ProdutoModelo>("Não foi possível adicionar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<ProdutoModelo>("Falha interna no servidor"));
        }
    }

    [HttpPut]
    [Route("v1/produtos/{id:int}")]
    public async Task<IActionResult> AtualizarProduto(int id, ProdutoModelo modelo)
    {
        try
        {
            var produto = await contexto.TbProdutos.FirstOrDefaultAsync(x => x.ProId == id);
            if (produto == null)
                return NotFound(new RespostaViewModelo<ProdutoModelo>("Não foi possível encontrar"));

            produto.ProNome = modelo.ProNome;
            produto.ProDesc = modelo.ProDesc;
            produto.ProPreco = modelo.ProPreco;
            produto.ProImagemUrl = modelo.ProImagemUrl;
            produto.ProQuantidadeEmEstoque = modelo.ProQuantidadeEmEstoque;
            produto.ProAltPor = modelo.ProAltPor;
            produto.ProAltEm = modelo.ProAltEm;

            contexto.TbProdutos.Update(produto);
            await contexto.SaveChangesAsync();

            return Ok(new RespostaViewModelo<ProdutoModelo>(produto));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<ProdutoModelo>("Não foi possível atualizar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<ProdutoModelo>("Falha interna no servidor"));
        }
    }

    [HttpDelete]
    [Route("v1/produtos/{id:int}")]
    public async Task<IActionResult> ApagarProduto(int id)
    {
        try
        {
            var produto = await contexto.TbProdutos.FirstOrDefaultAsync(x => x.ProId == id);
            if (produto == null)
                NotFound(new RespostaViewModelo<ProdutoModelo>("Não foi possivel encontrar"));
            
            contexto.TbProdutos.Remove(produto);
            await contexto.SaveChangesAsync();

            return Ok(new RespostaViewModelo<ProdutoModelo>(produto));
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