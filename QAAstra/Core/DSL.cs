using System.Runtime.InteropServices;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QABuscaCepCorreio.Helper;

namespace QAAstra.Core
{
    public class DSL
    {
        public LogWriter logWriter;
        public GlobalVariables globalVariables;
        // public ChromeDriver driver;
        public Begin begin;

        public DSL()
        {
            logWriter = new LogWriter();
            // driver = new ChromeDriver();
            begin = new Begin();
            begin.InicioTeste();
        }

        #region Funções de Manipulação
        public static void Espere(int tempoEspera)
        {
            Thread.Sleep(tempoEspera);
        }

        public void LimparCampo(string elemento)
        {
            begin.driver.FindElement(By.XPath(elemento)).Clear();
            begin.driver.FindElement(By.XPath(elemento)).Clear();
        }

        public void CliqueFora()
        {
            begin.driver.FindElement(By.XPath("//html")).Click();
        }

        public void EsperaElemento(string elemento, int tempo = 60) //aguarda elemento aparecer na tela
        {
            var espera = new WebDriverWait(begin.driver, TimeSpan.FromSeconds(tempo));

            espera.Until((t) =>
            {
                return t.FindElement(By.XPath(elemento));
            });
        }

        public void EsperaElementoSumir(string elemento) //aguarda elemento aparecer na tela
        {
            var espera = new WebDriverWait(begin.driver, TimeSpan.FromSeconds(60));

            espera.Until(t => t.FindElements(By.XPath(elemento)).Count == 0); //quando o count do elemento for igual a zero(não tem elemento na tela) continua a execução
        }

        public bool ValidaElementoExistente(string elemento)
        {
            try
            {
                begin.driver.FindElement(By.XPath(elemento));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        #endregion

        #region Funções de Interação
        public void EscreveTexto(string elemento, string valor, [Optional] string descricao)
        {
            try
            {
                begin.driver.FindElement(By.XPath(elemento)).SendKeys(valor);

                if (descricao != null)
                {
                    Console.WriteLine("Preencheu " + descricao);
                    logWriter.LogWrite("Preencheu " + descricao);
                }
            }
            catch (Exception ex)
            {
                if (descricao != null)
                    Console.WriteLine("Erro ao preencher " + descricao + globalVariables.exceptionMsg + ex.Message);

                Assert.Fail(); //se chegou aqui o teste falhou e vai pegar o erro com NUnit, o AssertFail mata a execução do teste, nada depois é executado.
            }
        }

        public void ClicaElemento(string elemento, [Optional] string descricao)
        {
            try
            {
                begin.driver.FindElement(By.XPath(elemento)).Click();
                Espere(1000);

                if (descricao != null)
                {
                    Console.WriteLine("Clicou " + descricao);
                    logWriter.LogWrite("Clicou " + descricao);
                }
            }
            catch (Exception ex)
            {
                if (descricao != null)
                    Console.WriteLine("Erro ao clicar no elemento " + descricao + globalVariables.exceptionMsg + ex.Message);

                Assert.Fail();
            }
        }

        public void ValidaDados(string elemento, string valor, [Optional] string descricao)
        {
            try
            {
                Assert.That(begin.driver.FindElement(By.XPath(elemento)).Text, Does.Contain(valor));

                if (descricao != null)
                {
                    Console.WriteLine("Validou " + descricao);
                    logWriter.LogWrite("Validou " + descricao);
                }
            }
            catch (Exception ex)
            {
                if (descricao != null)
                    Console.WriteLine("Erro ao validar elemento" + descricao + globalVariables.exceptionMsg + ex.Message);

                Assert.Fail();
            }
        }

        public void MenuDropDown(string elemento, string valor, [Optional] string descricao)
        {
            try
            {
                string elementoValor = "//*[text()= '" + valor + "']"; //cria o texto que vai no dropdown
                begin.driver.FindElement(By.XPath(elemento)).Click(); //encontra e clica no elemento de dropdown
                EsperaElemento(elementoValor); //espera as opções carregarem
                begin.driver.FindElement(By.XPath(elementoValor)).Click(); //clica na opção especifica criada
                CliqueFora();

                if (descricao != null)
                    Console.WriteLine("Selecionou opção no Dropdown: " + descricao);
            }
            catch (Exception ex)
            {
                if (descricao != null)
                    Console.WriteLine("Erro ao selecionar opção no Dropdown: " + descricao + globalVariables.exceptionMsg + ex.Message);

                Assert.Fail();
            }
        }

        #endregion

        #region Funções de Atribuição
        public static string GeraNomeAleatorio()
        {
            var random = new Random();

            // var nome = new[]
            // {
            //     "Lucas",
            //     "Ianko",
            //     "Beto",
            //     "Rafael",
            //     "Madeira"
            // };

            // var sobrenome = new[]
            // {
            //     "Alves",
            //     "Cavalcanti",
            //     "Guloso",
            //     "Tanga",
            //     "Dura"
            // };

            string[] nome = File.ReadAllLines(@"C:\Users\LucasAlves\Desktop\ArquivosSMN\QABuscaCepCorreioArquivos\nome.txt");

            string[] sobrenome = File.ReadAllLines(@"C:\Users\LucasAlves\Desktop\ArquivosSMN\QABuscaCepCorreioArquivos\sobrenome.txt");

            var nomeCompleto = nome[random.Next(nome.Length)] + " " + sobrenome[random.Next(sobrenome.Length)];

            return nomeCompleto;
        }

        public static string GeraEmailAleatorio()
        {
            var random = new Random();

            // var email = new[]
            // {
            //     john.doe@example.com,
            //     jane.smith@example.com,
            //     david.wilson@example.com,
            //     emily.jones@example.com,
            //     michael.brown@example.com,
            //     sarah.taylor@example.com,
            //     alexander.clark@example.com,
            //     olivia.martin@example.com
            // };

            string[] nome = File.ReadAllLines(@"C:\Users\LucasAlves\Desktop\ArquivosSMN\QABuscaCepCorreioArquivos\nome.txt");

            string[] sobrenome = File.ReadAllLines(@"C:\Users\LucasAlves\Desktop\ArquivosSMN\QABuscaCepCorreioArquivos\sobrenome.txt");

            string[] dominio = File.ReadAllLines(@"C:\Users\LucasAlves\Desktop\ArquivosSMN\QABuscaCepCorreioArquivos\dominio.txt");

            string email = nome[random.Next(nome.Length)] + "." + sobrenome[random.Next(sobrenome.Length)] + dominio[random.Next(dominio.Length)];

            return email.ToLower();
        }

        public static string GeraDataNascimentoAleatorio()
        {
            var random = new Random();

            int dia = random.Next(1, 28);
            int mes = random.Next(1, 12);
            int ano = random.Next(1950, 2000);
            //esse padLeft vai colocar o zero das datas para o caso do valor ter apenas uma unidade, como datas de 1 a 9
            string dataNasc = dia.ToString().PadLeft(2, '0') + mes.ToString().PadLeft(2, '0') + ano;

            return dataNasc;
        }

        public static string GeraCelularAleatorio()
        {
            var random = new Random();
            string celNumero = string.Empty;

            for (int i = 0; i < 11; i++)
                celNumero = string.Concat(celNumero, random.Next(10));

            return celNumero;
        }

        #endregion
    }
}
