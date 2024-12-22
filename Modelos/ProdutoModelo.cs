using System.ComponentModel.DataAnnotations;

namespace FabricaGestao.Api.Modelos
{
    public class ProdutoModelo
    {
        [Key] 
        public int ProId { get; set; }
        public int CatId { get; set; }
        public string ProNome { get; set; } = string.Empty;
        public string ProDesc { get; set; } = string.Empty;
        [Range(0.01, double.MaxValue, ErrorMessage = "O Preço deve ser maior que zero.")]
        public decimal ProPreco { get; set; } = decimal.Zero;
        public string GetFormattedBasePrice() => ProPreco.ToString("0.00");
        [Range(1, int.MaxValue, ErrorMessage = "A Quantidade deve ser maior que zero.")]
        public int ProQuantidadeEmEstoque { get; set; }
        public string ProImagemUrl { get; set; } = string.Empty;
        public int ProIncPor { get; set; }
        public DateTime ProIncEm { get; set; } = DateTime.Now;
        public int? ProAltPor { get; set; }
        public DateTime? ProAltEm { get; set; }
        public CategoriaModelo Categoria { get; set; } = new CategoriaModelo();
        public ICollection<OrcamentoProdutoModelo> ProdutoOrcamentos { get; set; } = new List<OrcamentoProdutoModelo>();
    }
}
