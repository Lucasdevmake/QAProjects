using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QAAstra.Core;
using QABuscaCepCorreio.Helper;

public class Begin
{
    public DSL dsl;
    public GlobalVariables globalVariables;
    public IWebDriver driver;
    public LogWriter logWriter;

    public Begin()
    {
        globalVariables = new GlobalVariables();
    }

    private void AbreNavegador()
    {
        var headLessMode = new ChromeOptions();
        headLessMode.AddArgument("window-size=1920x1080");
        headLessMode.AddArgument("disk-cache-size=0");
        headLessMode.AddArgument("headless");

        var devMode = new ChromeOptions();
        devMode.AddArgument("disk-cache-size=0");
        devMode.AddArgument("start-maximized");

        if (globalVariables.headLessTest)
            driver = new ChromeDriver(headLessMode);
        else
            driver = new ChromeDriver(devMode);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [SetUp]
    public void InicioTeste()
    {
        AbreNavegador();
        driver.Navigate().GoToUrl("http://192.168.7.23:1000/login");
    }

    [Test]
    public void Test1()
    {
        // string mensagem = "Sucesso no teste";
        // Assert.Pass();
    }

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
