namespace FabricaGestao.Api.ViewModelos.Respostas;

public class RespostaViewModelo<T>
{
    public RespostaViewModelo(T? dados, List<string>? erros)
    {
        Dados = dados;
        Erros = erros;
    }
    public RespostaViewModelo(T? dados) => 
        Dados = dados;
    public RespostaViewModelo(List<string>? erros) =>
        Erros = erros;
    public RespostaViewModelo(string erro) =>
        Erros?.Add(erro);

    public T? Dados { get; set; } 
    public List<string>? Erros { get; private set; } = new();
}