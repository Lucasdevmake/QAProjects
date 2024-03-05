using Alura.Estacionamento.Alura.Estacionamento.Models;
using Alura.Estacionamento.Models;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Tests;

public class VeiculoTests
{
    private Veiculo veiculo;
    public ITestOutputHelper saidaConsoleTeste;

    public VeiculoTests(ITestOutputHelper _saidaConsoleTeste)
    {
        saidaConsoleTeste = _saidaConsoleTeste;
        saidaConsoleTeste.WriteLine("Construtor invocado.");
        veiculo = new Veiculo();
    }

    [Fact] //atributo de método que indica que ele é um teste unitário e deve ser executado
    public void TestaVeiculoTestes()
    {
        //Arrange - preparação do ambiente, criação de variáveis, instâncias
        // var veiculo = new Veiculo();
        //Act - chamar algum método e passar o valor a ser testado no método
        veiculo.Acelerar(10);
        //Assert - comparar o resultado obtido com esperado daquele parâmetro a ser testado
        Assert.Equal(100, veiculo.VelocidadeAtual); //verifica se a velocidade atual do veículo (veiculo.VelocidadeAtual) é igual a 100 após ter sido acelerado em 10 unidades.
    }

    [Fact(DisplayName = "Teste de frenagem Nº 1")]
    [Trait("Funcionalidade", "Frear")]
    public void TestaVeiculoFrear()
    {
        // var veiculo = new Veiculo();
        veiculo.Frear(10);
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact(Skip = "Ignorar este teste")] //ignorar o teste
    public void ValidaNomeProprietario()
    {
        // var veiculo = new Veiculo();
        veiculo.Frear(10);
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact(DisplayName = "Teste de aceleração Nº 1")] //nomeando testes
    [Trait("Funcionalidade", "Acelerar")]
    public void TestaVeiculoAceleracao()
    {
        // var veiculo = new Veiculo();
        veiculo.Acelerar(10);
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact(DisplayName = "Teste de aceleração Nº 2", Skip = "Ignorar este teste")] //nomeando testes
    public void TestaVeiculo()
    {
        // var veiculo = new Veiculo();
        veiculo.Acelerar(10);
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Theory(Skip = "Passa esse teste")]
    [ClassData(typeof(Veiculo))]
    public void TestaVeiculoClass(Veiculo modelo)
    {
        //Arrange
        // var veiculo = new Veiculo();
        //Act
        veiculo.Acelerar(10);
        modelo.Acelerar(10);
        //Assert
        Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
    }

    [Fact(DisplayName = "Teste de Dados Veículo")] //nomeando testes
    public void TesteDadosVeiculo()
    {
        //Arrange
        var carro = new Veiculo
        {
            Proprietario = "Lucas Alves",
            Tipo = TipoVeiculo.Automovel,
            Placa = "ASF-9999",
            Cor = "Prata",
            Modelo = "Celta"
        };

        //Act
        var dadosCarro = carro.ToString();

        //Assert
        Assert.Contains("Tipo do Veiculo: Automovel", dadosCarro);
    }
}
