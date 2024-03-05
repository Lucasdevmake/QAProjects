using Alura.Estacionamento.Alura.Estacionamento.Models;
using Alura.Estacionamento.Models;
using Xunit;

namespace Alura.Estacionamento.Tests //Padrão AAA = arrange/act/assert
{
    public class PatioTests
    {
        private Veiculo veiculo;

        public PatioTests()
        {
            veiculo = new Veiculo();
        }

        [Fact]
        public void ValidaFaturamento()
        {
            //arrange
            var estacionamento = new Patio();
            veiculo = new Veiculo
            {
                Proprietario = "Lucas Alves",
                Tipo = TipoVeiculo.Automovel,
                Placa = "ASF-9999",
                Cor = "Prata",
                Modelo = "Celta"
            };

            //act
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);
            double faturamento = estacionamento.TotalFaturado();

            //assert
            Assert.Equal(2, faturamento);
        }

//[Theory] = teste com conjunto de dados, atributo de método que fornece metadados(servem para fornecer informações adicionais sobre o 
//elemento de código ao qual são aplicados. Eles são usados pelo compilador, ferramentas de desenvolvimento, e em tempo de execução pelo
//framework ou biblioteca relacionada) para modificar ou estender seu comportamento
        [Theory]
        [InlineData("Jose Silva", "ASD-1498", "preto", "Celta")]
        [InlineData("Indálica", "POL-9242", "Verde", "Palio")]
        [InlineData("Indiana", "GDR-6524", "Azul", "Uno")]
        [InlineData("Aruanda", "GDR-6666", "Azul", "Uno")]
        public void ValidaFaturamentoVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange = Padrão AAA
            var estacionamento = new Patio();
            veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Tipo = TipoVeiculo.Automovel,
                Placa = placa,
                Cor = cor,
                Modelo = modelo
            };

            //act
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);
            double faturamento = estacionamento.TotalFaturado();

            //assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Jose Silva", "ASD-1498", "preto", "Celta")]
        [InlineData("Silvino", "ASD-0200", "preto", "Palio")]
        public void TestaLocalizacaoVeiculoNoPatio(string proprietario, string placa, string cor, string modelo)
        {
            var estacionamento = new Patio(); //Arrange
            veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Tipo = TipoVeiculo.Automovel,
                Placa = placa,
                Cor = cor,
                Modelo = modelo
            };
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.Placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void TestaAlterarDadosVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            veiculo = new Veiculo
            {
                Proprietario = "Lucas Alves",
                Tipo = TipoVeiculo.Automovel,
                Placa = "ASF-9999",
                Cor = "Prata",
                Modelo = "Celta"
            };
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo
            {
                Proprietario = "Lucas Alves",
                Tipo = TipoVeiculo.Automovel,
                Placa = "ASF-9999",
                Cor = "Vermelho", //Alterado
                Modelo = "Gol" //Alterado
            };

            //Act
            var veiculoNovo = estacionamento.EditarVeiculoEstacionamento(veiculoAlterado);

            //Assert
            Assert.Equal(veiculoNovo.Cor, veiculoAlterado.Cor); //Equal = (esperado = espero que tenha alterado a cor, atual = é o que eu estou passando de parâmetro para a edição)
        }

        // [Theory]
        // [ClassData(typeof(Veiculo))]
        // public static void TestaAlterarDadosVeiculo(Veiculo veiculoAlterado)
        // {
        //     //Arrange
        //     var estacionamento = new Patio();
        //     var veiculo = new Veiculo
        //     {
        //         Proprietario = "Lucas Alves",
        //         Tipo = TipoVeiculo.Automovel,
        //         Placa = "ASF-9999",
        //         Cor = "Prata",
        //         Modelo = "Celta"
        //     };
        //     estacionamento.RegistrarEntradaVeiculo(veiculo);

        //     veiculoAlterado = new Veiculo
        //     {
        //         Proprietario = "Lucas Alves",
        //         Tipo = TipoVeiculo.Automovel,
        //         Placa = "ASF-9999",
        //         Cor = "Vermelho", //Alterado
        //         Modelo = "Gol" //Alterado
        //     };

        //     //Act
        //     var veiculoNovo = estacionamento.EditarVeiculoEstacionamento(veiculoAlterado);

        //     //Assert
        //     Assert.Equal(veiculoNovo.Cor, veiculoAlterado.Cor); //Equal = (esperado = espero que tenha alterado a cor, atual = é o que eu estou passando de parâmetro para a edição)
        // }
    }
}
