using System.ComponentModel.DataAnnotations;

namespace FabricaGestao.Api.ViewModelos.Pessoas;

public class EditorPessoaViewModelo
{
    public int PesId { get; set; } = 0;
    [Required(ErrorMessage = "Campo Nome obrigatório")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "Este campo deve conter no maximo 40 caracteres e no minimo 3 caracteres")]
    public string PesNome { get; set; } = string.Empty;
    public string? PesCpf { get; set; } 
    public string? PesCnpj { get; set; }
    [Required(ErrorMessage = "Campo Telefone obrigatório")]
    [Phone(ErrorMessage = "Número de Telefone inválido")]
    public string PesNumCelular { get; set; } = string.Empty;
    public string? PesNumTelefone { get; set; }
    public string? PesEmail { get; set; }
    [Required(ErrorMessage = "Campo CEP obrigatório")]
    public string PesCep { get; set; } = string.Empty;
    [Required(ErrorMessage = "Campo Rua obrigatório")]
    public string PesRua { get; set; } = string.Empty;
    public string PesNumero { get; set; } = string.Empty;
    public string PesBairro { get; set; } = string.Empty;
    public string PesCidade { get; set; } = string.Empty;
    public string PesEstado { get; set; } = string.Empty;
    public int PesIncPor { get; set; }
    
    public DateTime PesIncEm { get; set; } = DateTime.Now;
    
    public int PesAltPor { get; set; }
    public DateTime PesAltEm { get; set; } = DateTime.Now;
}