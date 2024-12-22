using FabricaGestao.Api.Dados.Contexto;
using FabricaGestao.Api.Extencoes;
using FabricaGestao.Api.Modelos;
using FabricaGestao.Api.ViewModelos.Respostas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaGestao.Api.Controllers;

[ApiController]
public class PerfilController(ContextoDados contexto) : ControllerBase
{
    [HttpGet]
    [Route("v1/perfis")]
    public async Task<IActionResult> BuscarTodosPerfis()
    {
        try
        {
            var perfis = await contexto.TbPerfis
                .AsNoTracking()
                .ToListAsync();

            return perfis.Any()
                ? Ok(new RespostaViewModelo<List<PerfilModelo>>(perfis))
                : NotFound(new RespostaViewModelo<PerfilModelo>("Não foi possível encontrar"));
        }
        catch 
        {
            return StatusCode(500, new RespostaViewModelo<PerfilModelo>("Falha interna no servidor"));
        }
    }

    [HttpGet]
    [Route("v1/perfis/{id:int}")]
    public async Task<IActionResult> BuscarUmPerfil(int id)
    {
        try
        {
            var perfil = await contexto.TbPerfis
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PerId == id);

            if (perfil == null)
                return NotFound(new RespostaViewModelo<PerfilModelo>("Não foi possível encontrar"));

            return Ok(new RespostaViewModelo<PerfilModelo>(perfil));
        }
        catch 
        {
            return StatusCode(500, new RespostaViewModelo<PerfilModelo>("Falha interna no servidor"));
        }
    }

    [HttpPost]
    [Route("v1/perfis")]
    public async Task<IActionResult> AdicionarPerfil(PerfilModelo model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new RespostaViewModelo<PerfilModelo>(ModelState.ObterEstadoDeErros()));

        try
        {
            await contexto.TbPerfis.AddAsync(model);
            await contexto.SaveChangesAsync();

            return Created($"v1/perfis/{model.PerId}", new RespostaViewModelo<PerfilModelo>(model));
        }
        catch(DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<PerfilModelo>("Não foi possível adicionar"));
        }
        catch 
        {
            return StatusCode(500, new RespostaViewModelo<PerfilModelo>("Falha interna no servidor"));
        }
    }

    [HttpDelete]
    [Route("v1/perfis/{id:int}")]
    public async Task<IActionResult> ApagarPerfil(int id)
    {
        try
        {
            var perfil = await contexto.TbPerfis.FirstOrDefaultAsync(x => x.PerId == id);
            if(perfil == null)
                return NotFound(new RespostaViewModelo<PerfilModelo>("Não foi possível encontrar"));

            contexto.TbPerfis.Remove(perfil);
            await contexto.SaveChangesAsync();

            return Ok(new RespostaViewModelo<PerfilModelo>(perfil));
        }
        catch 
        {
            return StatusCode(500, new RespostaViewModelo<OrcamentoModelo>("Falha interna no servidor"));
        }
    }
}