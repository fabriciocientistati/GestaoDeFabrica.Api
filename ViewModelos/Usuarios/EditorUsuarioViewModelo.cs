using System.ComponentModel.DataAnnotations;
using FabricaGestao.Api.Modelos;
using Microsoft.AspNetCore.Components;

namespace FabricaGestao.Api.ViewModelos.Usuarios;

public class EditorUsuarioViewModelo
{
    [Required(ErrorMessage = "Campo Nome obrigatório")]
    [StringLength(40, MinimumLength = 3,
        ErrorMessage = "Este campo deve conter no maximo 40 caracteres e no minimo 3 caracteres")]
    public string UsuNome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Login obrigatório")]
    [StringLength(40, MinimumLength = 3,
        ErrorMessage = "Este campo deve conter no maximo 40 caracteres e no minimo 3 caracteres")]
    public string UsuLogin { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Campo Senha obrigatório")]
    public string UsuSenha { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Campo E-mail obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail invalido")]
    public string UsuEmail { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Perfil obrigatório")]
    public PerfilModelo Perfil { get; set; }
    public DateTime UsuIncEm { get; set; }  = DateTime.Now;
    public int UsuIncPor { get; set; } = 0;
}