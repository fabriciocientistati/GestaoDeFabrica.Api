using FabricaGestao.Api.Dados.Contexto;
using FabricaGestao.Api.Extencoes;
using FabricaGestao.Api.Modelos;
using FabricaGestao.Api.ViewModelos.Respostas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaGestao.Api.Controllers;

[ApiController]
public class OrcamentoProdutoController(ContextoDados contexto) : ControllerBase
{
    [HttpGet]
    [Route("v1/orcamentosProdutos")]
    public async Task<IActionResult> BuscarTodosOrcamentosProdutos()
    {
        try
        {
            var orcamentosProdutos = await contexto.TbOrcamentoProdutos
                .AsNoTracking()
                .ToListAsync();

            return orcamentosProdutos.Any()
                ? Ok(new RespostaViewModelo<List<OrcamentoProdutoModelo>>(orcamentosProdutos))
                : NotFound(new RespostaViewModelo<OrcamentoProdutoModelo>("Não foi possível encontrar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<OrcamentoProdutoModelo>("Falha interna no servidor"));
        }
    }

    [HttpGet]
    [Route("v1/orcamentosProdutos/{id:int}")]
    public async Task<IActionResult> BuscarUmOrcamento(int id)
    {
        try
        {
            var orcamentoProduto = await contexto.TbOrcamentoProdutos
                .AsNoTracking()
                .ToListAsync();

            return orcamentoProduto.Any()
                ? Ok(new RespostaViewModelo<List<OrcamentoProdutoModelo>>(orcamentoProduto))
                : NotFound(new RespostaViewModelo<OrcamentoProdutoModelo>("Não foi possível encontrar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<OrcamentoProdutoModelo>("Falha interna no servidor"));
        }
    }
    
    [HttpPost]
    [Route("v1/orcamentosProdutos")]
    public async Task<IActionResult> AdicionarOrcamentosProdutos(OrcamentoProdutoModelo modelo)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(new RespostaViewModelo<OrcamentoProdutoModelo>(ModelState.ObterEstadoDeErros()));

            await contexto.TbOrcamentoProdutos.AddAsync(modelo);
            await contexto.SaveChangesAsync();

            return Created($"/v1/orcamentosProdutos/{modelo.OrcId}",
                new RespostaViewModelo<OrcamentoProdutoModelo>(modelo));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<OrcamentoProdutoModelo>("Não foi possível adicionar"));
        }
        catch 
        {
            return StatusCode(500, new RespostaViewModelo<OrcamentoProdutoModelo>("Falha interna no servidor"));
        }
    }
}