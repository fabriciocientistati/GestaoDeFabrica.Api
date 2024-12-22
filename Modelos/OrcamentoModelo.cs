using System.ComponentModel.DataAnnotations;

namespace FabricaGestao.Api.Modelos
{
    public class OrcamentoModelo
    {
        [Key] 
        public int OrcId { get; set; } 
        public int PesId { get; set; }
        public PessoaModelo Pessoa { get; set; } = new PessoaModelo();
        public string OrcDesc { get; set; } = string.Empty;
        public string? OrcObservacao { get; set; }
        public decimal OrcPreco { get; set; } = decimal.Zero;
        public string OrcTipoPagamento { get; set; } = string.Empty;
        public string OrcTipoEntrega { get; set; } = string.Empty;
        public int OrcIncPor { get; set; }
        public DateTime OrcIncEm { get; set; } = DateTime.Now;
        public int? OrcAltPor { get; set; }
        public DateTime? OrcAltEm { get; set; }
        public ICollection<OrcamentoProdutoModelo>? OrcamentoProdutos { get; set; } = new List<OrcamentoProdutoModelo>();
    }
}
