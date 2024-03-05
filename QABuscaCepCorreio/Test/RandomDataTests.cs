using NUnit.Framework;
using QABuscaCepCorreio.Core;

namespace QABuscaCepCorreio.Test
{
    public class RamdomDataTests : Begin
    {
        [Test]
        public void RandomData()
        {
            string nome = GeraNomeAleatorio();
            Console.WriteLine(nome);

            string email = GeraEmailAleatorio();
            Console.WriteLine(email);

            string data = GeraDataNascimentoAleatorio();
            Console.WriteLine(data);

            string celular = GeraCelularAleatorio();
            Console.WriteLine(celular);
        }

        // [Test] //teste exemplo de cadastro de usuário
        // public void PreencheCadastro()
        // {
        //     ClicaElemento("//button[text()='Cadastrar Contato']"); //para acessar a página de cadastro

        //     string nome = GeraNomeAleatorio();
        //     EscreveTexto("//input[@id='nome']", nome);

        //     string email = GeraEmailAleatorio();
        //     EscreveTexto("//input[@id='email']", email);

        //     string celular = GeraCelularAleatorio();
        //     EscreveTexto("//input[@id='celular']", celular);

        //     EscreveTexto("//input[@id='cidade']", "João Pessoa / PB");

        //     ClicaElemento("//button[text()='Salvar Contato']");
        // }
    }
}
