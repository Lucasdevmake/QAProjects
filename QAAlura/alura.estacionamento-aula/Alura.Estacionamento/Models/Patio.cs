using Alura.Estacionamento.Alura.Estacionamento.Models;

namespace Alura.Estacionamento.Models
{
    public class Patio
    {
        public Patio()
        {
            Faturado = 0;
            veiculos = new List<Veiculo>();
        }

        private List<Veiculo> veiculos;
        private double faturado;
        public double Faturado { get => faturado; set => faturado = value; }
        public List<Veiculo> Veiculos { get => veiculos; set => veiculos = value; }

        public double TotalFaturado()
        {
            return this.Faturado;
        }

        public string MostrarFaturamento()
        {
            string totalfaturado = String.Format("Total faturado até o momento :::::::::::::::::::::::::::: {0:c}", this.TotalFaturado());
            return totalfaturado;
        }

        public void RegistrarEntradaVeiculo(Veiculo veiculo)
        {
            veiculo.HoraEntrada = DateTime.Now;            
            this.Veiculos.Add(veiculo);            
        }

        public string RegistrarSaidaVeiculo(String placa)
        {
            Veiculo procurado = null;
            string informacao = string.Empty;

            foreach (Veiculo v in this.Veiculos)
            {
                if (v.Placa == placa)
                {
                    v.HoraSaida = DateTime.Now;
                    TimeSpan tempoPermanencia = v.HoraSaida - v.HoraEntrada;
                    double valorASerCobrado = 0;
                    if (v.Tipo == TipoVeiculo.Automovel)
                    {
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 2;
                    }
                    if (v.Tipo == TipoVeiculo.Motocicleta)
                    {
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 1;
                    }
                    informacao = string.Format(" Hora de entrada: {0: HH: mm: ss}\n " +
                                             "Hora de saída: {1: HH:mm:ss}\n "      +
                                             "Permanência: {2: HH:mm:ss} \n "       +
                                             "Valor a pagar: {3:c}", v.HoraEntrada, v.HoraSaida, new DateTime().Add(tempoPermanencia), valorASerCobrado);
                    procurado = v;
                    this.Faturado = this.Faturado + valorASerCobrado;
                    break;
                }

            }

            if (procurado != null)
            {
                this.Veiculos.Remove(procurado);
            }
            else
            {
                return "Não encontrado veículo com a placa informada.";
            }

            return informacao;
        }

        public Veiculo PesquisaVeiculo(string placa)
        {
            // var veiculo = this.veiculos.First(x => x.Placa == placa);
            // return veiculo;

            var veiculoEncontrado =
            (
                from veiculo in this.Veiculos
                where veiculo.Placa == placa
                select veiculo
            )
            .SingleOrDefault();

            return veiculoEncontrado;
        }

        public Veiculo EditarVeiculoEstacionamento(Veiculo veiculoNovo)
        {
            var veiculoAlterado =
            (
                from veiculo in this.Veiculos
                where veiculo.Placa == veiculoNovo.Placa
                select veiculo
            ) //aqui ja fez a busca do carro correspondente por placa
            .SingleOrDefault();

            veiculoAlterado.AlterarDados(veiculoNovo);

            return veiculoAlterado;
        }
    }
}
