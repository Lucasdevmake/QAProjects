using NUnit.Framework;
using QABuscaCepCorreio.Core;
using QABuscaCepCorreio.Page;

namespace QABuscaCepCorreio.Test
{
    // public class BuscaCep : ValidaCepPage
    public class BuscaCep : BaseTester
    {
        public ValidaCepPage validaCepPage;

        public BuscaCep()
        {
            validaCepPage = new ValidaCepPage();
        }

        [Test]
        public void ValidaCepTeste()
        {
            validaCepPage.PreencheCep();
            validaCepPage.ClicaBotaoBusca();
            validaCepPage.ValidaResultado();
        }

        [Test]
        public void ValidaEnderecoCompletoTeste()
        {
            validaCepPage.PreencheCep();
            validaCepPage.ClicaBotaoBusca();
            validaCepPage.ValidaResultadoTotal();
        }

        [Test]
        public void ValidaResultadoMultiplosCeps()
        {
            // PreencheCep();
            // ClicaBotaoBusca();
            validaCepPage.ValidaMultiplosCeps();
        }

        [Test]
        public void ValidaBuscaDropdownCep()
        {
            validaCepPage.SelecionaTipoCep();
        }

        [Test]
        public void ValidaListaOpcoesDropdownCep()
        {
            validaCepPage.ValidaItensMenuDropdown();
        }
    }
}
