using FabricaGestao.Api.Dados.Contexto;
using FabricaGestao.Api.Extencoes;
using FabricaGestao.Api.Modelos;
using FabricaGestao.Api.ViewModelos.Respostas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaGestao.Api.Controllers;

[Authorize]
[ApiController]
public class OrcamentoController(ContextoDados contexto) : ControllerBase
{
    [HttpGet]
    [Route("v1/orcamentos")]
    public async Task<IActionResult> BuscarTodosOrcamento()
    {
        try
        {
            var orcamentos = await contexto.TbOrcamentos
                .AsNoTracking()
                .ToListAsync();

            return orcamentos.Any()
                ? Ok(new RespostaViewModelo<List<OrcamentoModelo>>(orcamentos))
                : NotFound(new RespostaViewModelo<OrcamentoModelo>("Não foi possível encontrar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<OrcamentoModelo>("Falha interna no servidor"));
        }
    }

    [HttpGet]
    [Route("v1/orcamentos/{id:int}")]
    public async Task<IActionResult> BuscarUmOrcamento(int id)
    {
        try
        {
            var orcamento = await contexto.TbOrcamentos
                .AsNoTracking()
                .ToListAsync();

            return orcamento.Any()
                ? Ok(orcamento)
                : NotFound(new RespostaViewModelo<OrcamentoModelo>("Não foi possível encontrar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<OrcamentoModelo>("Falha interna no servidor"));
        }
    }

    [HttpPost]
    [Route("v1/orcamentos")]
    public async Task<IActionResult> AdicionarOrcamento(OrcamentoModelo modelo)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(new RespostaViewModelo<OrcamentoModelo>(ModelState.ObterEstadoDeErros()));

            var orcamento = new OrcamentoModelo
            {
                OrcDesc = modelo.OrcDesc,
                OrcObservacao = modelo.OrcObservacao,
                OrcPreco = modelo.OrcPreco,
                OrcTipoEntrega = modelo.OrcTipoEntrega,
                OrcTipoPagamento = modelo.OrcTipoPagamento,
                OrcIncPor = 1,
                OrcIncEm = DateTime.Now
            };
            
            await contexto.AddAsync(orcamento);
            await contexto.SaveChangesAsync();

            return Created($"v1/orcamentos/{modelo.OrcId}", new RespostaViewModelo<OrcamentoModelo>(orcamento));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<OrcamentoModelo>("Não foi possível adicionar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<OrcamentoModelo>("Falha interna no servidor"));
        }
    }

    [HttpPut]
    [Route("v1/orcamentos/{id:int}")]
    public async Task<IActionResult> AtualizarOrcamento(int id, OrcamentoModelo modelo)
    {
        try
        {
            var orcamento = await contexto.TbOrcamentos.FirstOrDefaultAsync(x => x.OrcId == id);
            if (orcamento == null)
                return NotFound(new RespostaViewModelo<OrcamentoModelo>("Não foi possível encontrar"));

            orcamento.OrcDesc = modelo.OrcDesc;
            orcamento.OrcObservacao = modelo.OrcObservacao;
            orcamento.OrcPreco = modelo.OrcPreco;
            orcamento.OrcTipoEntrega = modelo.OrcTipoEntrega;
            orcamento.OrcTipoPagamento = modelo.OrcTipoPagamento;
            orcamento.OrcAltPor = 1;
            orcamento.OrcAltEm = DateTime.Now;

            return Ok(new RespostaViewModelo<OrcamentoModelo>(orcamento));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<OrcamentoModelo>("Não foi possível atualizar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<OrcamentoModelo>("Falha interna no servidor"));
        }
    }

    [HttpDelete]
    [Route("v1/orcamentos/{id:int}")]
    public async Task<IActionResult> ApagarOrcamento(int id)
    {
        try
        {
            var orcamento = await contexto.TbOrcamentos.FirstOrDefaultAsync(x => x.OrcId == id);
            if (orcamento == null)
                return NotFound(new RespostaViewModelo<OrcamentoModelo>("Não foi possível encontrar"));
            
            contexto.TbOrcamentos.Remove(orcamento);
            await contexto.SaveChangesAsync();
            
            return Ok(new RespostaViewModelo<OrcamentoModelo>(orcamento));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<OrcamentoModelo>("Falha interna no servidor"));
        }
    }
}