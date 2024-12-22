namespace FabricaGestao.Api.Modelos;

public class OrcamentoProdutoModelo
{
    public int OrcId { get; set; }
    public OrcamentoModelo Orcamento { get; set; } = new OrcamentoModelo();
    public int ProId { get; set; }
    public ProdutoModelo Produto { get; set; } = new ProdutoModelo();
    public int Quantidade { get; set; } = 1;
}