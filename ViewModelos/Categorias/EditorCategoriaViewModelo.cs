using System.ComponentModel.DataAnnotations;

namespace FabricaGestao.Api.ViewModelos.Categorias;

public class EditorCategoriaViewModelo
{
    [Required(ErrorMessage = "Campo nome obrigatório")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "Este campo deve conter no maximo 40 caracteres e no minimo 3 caracteres")]
    public string CatNome { get; set; } = String.Empty;
    public int CatIncPor { get; set; } 
    public DateTime CatIncEm { get; set; }  = DateTime.Now;
}