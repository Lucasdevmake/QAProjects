// using OpenQA.Selenium;
// using OpenQA.Selenium.Support.UI;
// using System;
// using System.Threading;

// namespace QABuscaCepCorreio.Core
// {
//     public static class DSL
//     {
//         public static LogWriter logWriter;
//         public static GlobalVariables globalVariables;
//         public static IWebDriver _driver;
//         // public Begin begin;

//         static DSL()
//         {
//             logWriter = new LogWriter();
//             // _driver = new ChromeDriver();
//             // begin = new Begin();
//             // begin.InicioTeste();
//         }

//         #region Funções de Manipulação
//         public static void Espere(int tempoEspera)
//         {
//             Thread.Sleep(tempoEspera);
//         }

//         public static void LimparCampo(string elemento)
//         {
//             _driver.FindElement(By.XPath(elemento)).Clear();
//             _driver.FindElement(By.XPath(elemento)).Clear();
//         }

//         public static void CliqueFora()
//         {
//             _driver.FindElement(By.XPath("//html")).Click();
//         }

//         public static void EsperaElemento(string elemento, int tempo = 60) //aguarda elemento aparecer na tela
//         {
//             var espera = new WebDriverWait(_driver, TimeSpan.FromSeconds(tempo));

//             espera.Until((t) =>
//             {
//                 return t.FindElement(By.XPath(elemento));
//             });
//         }

//         public static void EsperaElementoSumir(string elemento) //aguarda elemento aparecer na tela
//         {
//             var espera = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));

//             espera.Until(t => t.FindElements(By.XPath(elemento)).Count == 0); //quando o count do elemento for igual a zero(não tem elemento na tela) continua a execução
//         }

//         public static bool ValidaElementoExistente(string elemento)
//         {
//             try
//             {
//                 _driver.FindElement(By.XPath(elemento));
//                 return true;
//             }
//             catch (NoSuchElementException)
//             {
//                 return false;
//             }
//         }

//         #endregion

//         #region Funções de Interação
//         public static void EscreveTexto(string elemento, string valor, [Optional] string descricao)
//         {
//             try
//             {
//                 _driver.FindElement(By.XPath(elemento)).SendKeys(valor);

//                 if (descricao != null)
//                 {
//                     Console.WriteLine("Preencheu " + descricao);
//                     logWriter.LogWrite("Preencheu " + descricao);
//                 }
//             }
//             catch (Exception ex)
//             {
//                 if (descricao != null)
//                     Console.WriteLine("Erro ao preencher " + descricao + globalVariables.exceptionMsg + ex.Message);

//                 Assert.Fail(); //se chegou aqui o teste falhou e vai pegar o erro com NUnit, o AssertFail mata a execução do teste, nada depois é executado.
//             }
//         }

//         public static void ClicaElemento(string elemento, [Optional] string descricao)
//         {
//             try
//             {
//                 _driver.FindElement(By.XPath(elemento)).Click();
//                 Espere(1000);

//                 if (descricao != null)
//                 {
//                     Console.WriteLine("Clicou " + descricao);
//                     logWriter.LogWrite("Clicou " + descricao);
//                 }
//             }
//             catch (Exception ex)
//             {
//                 if (descricao != null)
//                     Console.WriteLine("Erro ao clicar no elemento " + descricao + globalVariables.exceptionMsg + ex.Message);

//                 Assert.Fail();
//             }
//         }

//         public static void ValidaDados(string elemento, string valor, [Optional] string descricao)
//         {
//             try
//             {
//                 Assert.That(_driver.FindElement(By.XPath(elemento)).Text, Does.Contain(valor));

//                 if (descricao != null)
//                 {
//                     Console.WriteLine("Validou " + descricao);
//                     logWriter.LogWrite("Validou " + descricao);
//                 }
//             }
//             catch (Exception ex)
//             {
//                 if (descricao != null)
//                     Console.WriteLine("Erro ao validar elemento" + descricao + globalVariables.exceptionMsg + ex.Message);

//                 Assert.Fail();
//             }
//         }
//         #endregion
//     }
// }
