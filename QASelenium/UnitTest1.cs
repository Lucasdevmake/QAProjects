using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QA___Selenium;

[TestFixture]
public class Tests
{
    public IWebDriver driver;

    [OneTimeSetUp]
    public void Setup()
    {
        ChromeOptions options = new()
        {
            BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe"
        };

        driver = new ChromeDriver(@"C:\Users\LucasAlves\Downloads\chromedriver-win64\chromedriver.exe", options);

        driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
        // driver.FindElement(By.Name("q")).SendKeys("Fleek It Solutions" + Keys.Enter);
        // Thread.Sleep(2000);
        // driver.Quit();
    }

    [TestCase(58052-290)]
    // [TestCase(5)]
    // [TestCase(45)]
    // [TestCase(46)]
    // [TestCase(999)]
    public void Test1(long cep)
    {
        // Assert.Pass();
        driver.Url = "https://buscacepinter.correios.com.br/app/endereco/index.php";

        IWebElement inputEndereco = driver.FindElement(By.Name("endereco"));
        inputEndereco.SendKeys("58052-290");

        IWebElement validacao = driver.FindElement(By.Name("endereco"));
        string textoValue = validacao.GetAttribute("innerHTML");

        if (textoValue == "")
            Assert.Pass("O teste deu sucesso");
        else
            Assert.Fail("O teste falhou");

    }

    [OneTimeTearDown]
    public void Close()
    {
        driver.Close();
    }


}
