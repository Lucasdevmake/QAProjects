using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QABuscaCepCorreio.Helper;
using QABuscaCepCorreioDesacopla.Core.Interface;

namespace QABuscaCepCorreio.Core;

// public class Begin : DSL
public class BaseTester
{
    public DSL dsl;
    public GlobalVariables globalVariables;
    public IWebDriver driver;
    public LogWriter logWriter;
    // public IValidaPage _validaCepPage; // injeção de dependência do Page

    public BaseTester()
    {
        globalVariables = new GlobalVariables();
        // driver = AbreNavegador();
        logWriter = new LogWriter();
    }

    #region código AbreNavegador()
    [SetUp]
    public void AbreNavegador()
    {
        var headLessMode = new ChromeOptions();
        headLessMode.AddArgument("window-size=1920x1080");
        headLessMode.AddArgument("disk-cache-size=0");
        headLessMode.AddArgument("headless");

        var devMode = new ChromeOptions();
        devMode.AddArgument("disk-cache-size=0");
        // devMode.AddArgument("start-maximized");

        if (globalVariables.headLessTest)
            driver = new ChromeDriver(headLessMode);
        else
            driver = new ChromeDriver(devMode);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
        dsl = new DSL(driver);
        // DSL.SetDriver(driver);
    }
    #endregion

    // [SetUp]
    // public void IniciarTeste()
    // {
    //     AbreNavegador();
    //     driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
    // }

    [TearDown]
    public void FimTeste()
    {
        if (globalVariables.driverQuit)
        {
            driver.Quit();
            logWriter.LogWrite("Teste finalizado");
        }
    }
}
