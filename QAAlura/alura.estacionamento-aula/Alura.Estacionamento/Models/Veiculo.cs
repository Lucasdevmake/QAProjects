﻿using System.Collections;
using Alura.Estacionamento.Alura.Estacionamento.Models;

namespace Alura.Estacionamento.Models
{
    public class Veiculo : IEnumerable<object[]>
    {
        //Campos
        private string _placa;
        private string _proprietario;
        private TipoVeiculo _tipo;

        //Propriedades   

        public string Placa
        {
            get
            {
                return _placa;
            }
            set
            {
                // Checa se o valor possui pelo menos 8 caracteres
                if (value.Length != 8)
                {
                    throw new FormatException(" A placa deve possuir 8 caracteres");
                }
                for (int i = 0; i < 3; i++)
                {
                    //checa se os 3 primeiros caracteres são numeros
                    if (char.IsDigit(value[i]))
                    {
                        throw new FormatException("Os 3 primeiros caracteres devem ser letras!");
                    }
                }
                //checa o Hifem
                if (value[3] != '-')
                {
                    throw new FormatException("O 4° caractere deve ser um hífen");
                }
                //checa se os 3 primeiros caracteres são numeros
                for (int i = 4; i < 8; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new FormatException("Do 5º ao 8º caractere deve-se ter um número!");
                    }
                }
                _placa = value;

            }
        }
        /// <summary>
        /// { get; set; } cria uma propriedade automática, ou seja,
        /// durante a compilação, é gerado um atributo para armazenar
        /// o valor da propriedade e os metodos get e set, respectivamente,
        /// lêem e escrevem diretamente no atributo gerado, sem
        /// qualquer validação. É um recurso útil, pois as propriedades
        /// permitem fazer melhor uso do recurso de Reflection do .Net
        /// Framework, entre outros benefícios.
        /// </summary>
        public string Cor { get; set; }
        public double Largura { get; set; }
        public double VelocidadeAtual { get; set; }
        public string Modelo { get; set; }
        public string Proprietario { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public TipoVeiculo Tipo { get => _tipo; set => _tipo = value; }

        //Métodos
        public void Acelerar(int tempoSeg)
        {
            this.VelocidadeAtual += (tempoSeg * 10);
        }

        public void Frear(int tempoSeg)
        {
            this.VelocidadeAtual -= (tempoSeg * 15);
        }

        //Construtor
        public Veiculo()
        {

        }

        public Veiculo(string proprietario)
        {
            Proprietario = proprietario;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Veiculo
                {
                    Proprietario = "André Silva",
                    Placa = "ASD-9999",
                    Cor= "Verde",
                    Modelo= "Fusca"
                },

                new Veiculo
                {
                    Proprietario = "Lucas Costa",
                    Placa = "ASD-9999",
                    Cor= "Branco",
                    Modelo= "Onix"
                }
            };
        }

        public void AlterarDados(Veiculo veiculoNovo)
        {
            this.Cor = veiculoNovo.Cor;
            this.Proprietario = veiculoNovo.Proprietario;
            this.Tipo = veiculoNovo.Tipo;
            this.Modelo = veiculoNovo.Modelo;
            // this.Placa = veiculoNovo.Placa;
        }

        public override string ToString()
        {
            return $"Ficha do Veiculo:\n " +
                    $"Tipo do Veiculo: {this.Tipo})\n " +
                    $"Proprietário:\n {this.Proprietario}" +
                    $"Modelo do Veiculo: {this.Modelo}\n " +
                    $"Cor do Veiculo:\n {this.Cor}" +
                    $"Placa do Veiculo:\n {this.Placa}";
        }
    }
}
