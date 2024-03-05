using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace QABuscaCepCorreio.Core;

public class Begin : DSL
{
    [SetUp]
    public void InicioTeste()
    {
        AbreNavegador();
        driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
    }

    [TearDown]
    public void FimTeste()
    {
        if (driverQuit)
        {
            driver.Quit();
            logWriter.LogWrite("Teste finalizado");
        }
    }

    #region código AbreNavegador()
    private void AbreNavegador()
    {
        var headLessMode = new ChromeOptions();
        headLessMode.AddArgument("window-size=1920x1080");
        headLessMode.AddArgument("disk-cache-size=0");
        headLessMode.AddArgument("headless");

        var devMode = new ChromeOptions();
        devMode.AddArgument("disk-cache-size=0");
        devMode.AddArgument("start-maximized");

        if (headLessTest)
            driver = new ChromeDriver(headLessMode);
        else
            driver = new ChromeDriver(devMode);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }
    #endregion
}
