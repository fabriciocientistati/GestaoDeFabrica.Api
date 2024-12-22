using System.ComponentModel.DataAnnotations;
using FabricaGestao.Api.Modelos;

namespace FabricaGestao.Api.ViewModelos.Produtos;

public class EditorProdutoViewModelo
{
    public int ProId { get; set; } = 0;
    public int CatId { get; set; } = 0;
    [Required(ErrorMessage = "Campo Nome obrigatório")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "Este campo deve conter no maximo 40 caracteres e no minimo 3 caracteres")]
    public string ProNome { get; set; } = string.Empty;
    public string ProDesc { get; set; } = string.Empty;
    [Range(0.01, double.MaxValue, ErrorMessage = "O Preço deve ser maior que zero.")]
    public decimal ProPreco { get; set; } = decimal.Zero;
    public string GetFormattedBasePrice() => ProPreco.ToString("0.00");
    [Range(1, int.MaxValue, ErrorMessage = "A Quantidade deve ser maior que zero.")]
    public int ProQuantidadeEmEstoque { get; set; }
    public string ProImagemUrl { get; set; } = string.Empty;
    public int ProIncPor { get; set; } = 0;
    public DateTime ProIncEm { get; set; } = DateTime.Now;
    public int? ProAltPor { get; set; } = 0;
    public DateTime? ProAltEm { get; set; } 
    public CategoriaModelo Categoria { get; set; } 
    public ICollection<OrcamentoProdutoModelo> ProdutoOrcamentos { get; set; } = new List<OrcamentoProdutoModelo>();
}