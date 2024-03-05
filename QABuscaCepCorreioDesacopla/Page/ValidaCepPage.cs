using QABuscaCepCorreio.Core;
using QABuscaCepCorreioDesacopla.Core.Interface;

namespace QABuscaCepCorreio.Page
{
    // public class ValidaCepPage
    public class ValidaCepPage : IValidaCepPage
    {
        // public DSL dsl;

        // public ValidaCepPage()
        // {
        //     dsl = new DSL();
        // }

        public void PreencheCep()
        {
            DSL.EscreveTexto("//*[@id='endereco']", "58052-290", "campo CEP com o valor 58052-290");
        }

        public void ClicaBotaoBusca()
        {
            DSL.ClicaElemento("//*[@id='btn_pesquisar']", "botão Buscar");
        }

        public void ValidaResultado()
        {
            DSL.ValidaDados("//*[@id='resultado-DNEC']/tbody/tr/td[1]", "Rua Manoel Belarmino de Macedo", "Rua Manoel Belarmino de Macedo");
        }

        public void ValidaResultadoTotal()
        {
            var elementos = new[]
            {
                "Rua Manoel Belarmino de Macedo", //0
                "Jardim Cidade Universitária", //1
                "João Pessoa/PB", //2
                "58052-290" //3
            };

            for (int i = 0; i < elementos.Length; i ++)
            {
                DSL.ValidaDados("//*[@id='resultado-DNEC']/tbody/tr/td["+ (i + 1) +"]", elementos[i], elementos[i]);
                Console.WriteLine(elementos[i]);
            }
        }

        public void ValidaMultiplosCeps()
        {
            // var ceps = new[]
            // {
            //     "58052-290",
            //     "44028-610",
            //     "58027-612",
            //     "01409-030"
            // };

            // var logradouros = new[]
            // {
            //     "Rua Manoel Belarmino de Macedo",
            //     "Rua José Gonzaga Sobrinho",
            //     "Rua do Oestes",
            //     "Rua Professor Azevedo Amaral"
            // };

            string[] ceps = File.ReadAllLines(@"C:\Users\LucasAlves\Desktop\ArquivosSMN\QABuscaCepCorreioArquivos\cep.txt");

            string[] logradouros = File.ReadAllLines(@"C:\Users\LucasAlves\Desktop\ArquivosSMN\QABuscaCepCorreioArquivos\logradouro.txt");

            for (int i = 0; i < ceps.Length; i ++)
            {
                DSL.EscreveTexto("//*[@id='endereco'][1]", $"{ceps[i]}");
                DSL.ClicaElemento("//*[@id='btn_pesquisar']");
                DSL.ValidaDados("//*[@id='resultado-DNEC']/tbody/tr/td[1]", logradouros[i]);
                DSL.ClicaElemento("//*[@id='btn_nbusca']", "botão pesquisar e validou CEP " + ceps[i] + " para o logradouro " + logradouros[i]);
                // Console.WriteLine(logradouros[i]);
            }
        }

        public void SelecionaTipoCep()
        {
            DSL.MenuDropDown("//*[@id='tipoCEP']", "Localidade/Logradouro", "tipo do CEP: Localidade/Logradouro");
        }

        public void ValidaItensMenuDropdown()
        {
            var cepsDropdown = new[]
            {
                "Localidade/Logradouro",
                "CEP Promocional",
                "Caixa Postal Comunitária",
                "Grande Usuário",
                "Unidade Operacional",
                "Todos"
            };

            for (int i = 0; i < cepsDropdown.Length; i ++)
            {
                DSL.MenuDropDown("//*[@id='tipoCEP']", cepsDropdown[i], "tipo do CEP: " + $"{cepsDropdown[i]}");
            }
        }
    }
}
