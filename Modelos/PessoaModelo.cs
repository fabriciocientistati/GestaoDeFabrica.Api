using System.ComponentModel.DataAnnotations;

namespace FabricaGestao.Api.Modelos
{
    public class PessoaModelo
    {
        [Key] 
        public int PesId { get; set; }
        public string PesNome { get; set; } = string.Empty;
        public string? PesCpf { get; set; } 
        public string? PesCnpj { get; set; }
        public string PesNumCelular { get; set; } = string.Empty;
        public string? PesNumTelefone { get; set; }
        public string? PesEmail { get; set; }
        public string PesCep { get; set; } = string.Empty;
        public string PesRua { get; set; } = string.Empty;
        public string PesNumero { get; set; } = string.Empty;
        public string PesBairro { get; set; } = string.Empty;
        public string PesCidade { get; set; } = string.Empty;
        public string PesEstado { get; set; } = string.Empty;
        public int PesIncPor { get; set; }
        public DateTime PesIncEm { get; set; } = DateTime.Now;
        public int? PesAltPor { get; set; }
        public DateTime? PesAltEm { get; set; }
        public ICollection<OrcamentoModelo> Orcamentos { get; set; } = new List<OrcamentoModelo>();
    }
}
