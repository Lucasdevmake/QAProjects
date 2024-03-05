// Definição da interface genérica
public interface IBaseValidaPage {
    void MetodoGenerico();
}


// Implementação genérica da interface
public class BaseValidaPage : IBaseValidaPage {
    public void MetodoGenerico() {
        Console.WriteLine("Método genérico executado.");
    }
}


// Interface específica
public interface ICepValidaPage : IBaseValidaPage {
    void MetodoEspecifico();
}


// Implementação específica
public class CepValidaPage : BaseValidaPage, ICepValidaPage {

    public void MetodoEspecifico() {
        Console.WriteLine("Método específico executado.");
    }
}


// Classe de teste genérica
public class BaseTester {

    protected IBaseValidaPage pagina;

    public BaseTester(IBaseValidaPage pagina) {
        this.pagina = pagina;
    }

    public void Testar() {
        pagina.MetodoGenerico();
    }
}


// Classe de teste específica
public class CepTester : BaseTester {

    public CepTester(ICepValidaPage pagina) : base(pagina) {}

    public void TestarEspecifico() {
        ((ICepValidaPage)pagina).MetodoEspecifico();
    }
}


// Exemplo de uso
class Program {
    static void Main(string[] args) {
        var pagina = new CepValidaPage();
        var tester = new CepTester(pagina);

        tester.Testar(); // Saída: Método genérico executado.
        tester.TestarEspecifico(); // Saída: Método específico executado.
    }
}
