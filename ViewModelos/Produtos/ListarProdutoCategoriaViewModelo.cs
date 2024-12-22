using System.ComponentModel.DataAnnotations;

namespace FabricaGestao.Api.ViewModelos.Produtos;

public class ListarProdutoCategoriaViewModelo
{
    public int ProId { get; set; } = 0;
    public string ProNome { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string ProDesc { get; set; } = string.Empty;
    public decimal ProPreco { get; set; } = decimal.Zero;
    public string GetFormattedBasePrice() => ProPreco.ToString("0.00");
    public int ProQuantidadeEmEstoque { get; set; }
    public string ProImagemUrl { get; set; } = string.Empty;
}