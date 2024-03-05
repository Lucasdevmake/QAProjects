using NUnit.Framework;
using QABuscaCepCorreio.Page;

namespace QABuscaCepCorreio.Test
{
    public class BuscaCep : ValidaCepPage
    {
        [Test]
        public void ValidaCepTeste()
        {
            PreencheCep();
            ClicaBotaoBusca();
            ValidaResultado();
        }

        [Test]
        public void ValidaEnderecoCompletoTeste()
        {
            PreencheCep();
            ClicaBotaoBusca();
            ValidaResultadoTotal();
        }

        [Test]
        public void ValidaResultadoMultiplosCeps()
        {
            // PreencheCep();
            // ClicaBotaoBusca();
            ValidaMultiplosCeps();
        }

        [Test]
        public void ValidaBuscaDropdownCep()
        {
            SelecionaTipoCep();
        }

        [Test]
        public void ValidaListaOpcoesDropdownCep()
        {
            ValidaItensMenuDropdown();
        }
    }
}
