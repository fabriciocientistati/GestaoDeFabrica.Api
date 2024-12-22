using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FabricaGestao.Api.Extencoes;

public static class ModeloExtensao
{
    public static List<string> ObterEstadoDeErros(this ModelStateDictionary modelState)
    {
        var resultado = new List<string>();
        
        foreach (var item in modelState.Values)
            resultado.AddRange(item.Errors.Select(erro => erro.ErrorMessage));

        return resultado;
    }
}