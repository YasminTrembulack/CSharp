public class Caixa<T>
{
    public T Valor { get; set; }

    public void Mostrar()
    {
        Console.WriteLine($"Valor armazenado: {Valor}");
    }
}

Caixa<int> caixaInteira = new Caixa<int>();
caixaInteira.Valor = 123;
caixaInteira.Mostrar();  // Saída: Valor armazenado: 123



public delegate void Operacao(int x, int y);

public class Calculadora
{
    public void Somar(int x, int y)
    {
        Console.WriteLine($"Soma: {x + y}");
    }
}

Calculadora calc = new Calculadora();
Operacao operacao = new Operacao(calc.Somar);
operacao(10, 20);  // Saída: Soma: 30

// Padrões de projeto criacionais:

//  Padrão Singleton
// O padrão Singleton garante que uma classe tenha apenas uma instância e fornece um ponto global de acesso a essa instância.

public class Singleton
{
    private static Singleton instancia;

    private Singleton() { }

    public static Singleton Instancia
    {
        get
        {
            if (instancia == null)
            {
                instancia = new Singleton();
            }
            return instancia;
        }
    }

    public void MostrarMensagem()
    {
        Console.WriteLine("Singleton ativo!");
    }
}

// Uso
Singleton instancia1 = Singleton.Instancia;
instancia1.MostrarMensagem();  // Saída: Singleton ativo!


// Padrão Factory Method
// O Factory Method define uma interface para criar objetos, mas permite que as subclasses decidam qual classe instanciar. Esse padrão delega a criação de objetos a subclasses.
// Produto
public interface IProduto
{
    void Operar();
}

// Produtos concretos
public class ProdutoConcretoA : IProduto
{
    public void Operar()
    {
        Console.WriteLine("Operando Produto A");
    }
}

public class ProdutoConcretoB : IProduto
{
    public void Operar()
    {
        Console.WriteLine("Operando Produto B");
    }
}

// Criador abstrato
public abstract class Criador
{
    public abstract IProduto CriarProduto();
}

// Criadores concretos
public class CriadorConcretoA : Criador
{
    public override IProduto CriarProduto()
    {
        return new ProdutoConcretoA();
    }
}

public class CriadorConcretoB : Criador
{
    public override IProduto CriarProduto()
    {
        return new ProdutoConcretoB();
    }
}

// Uso
Criador criadorA = new CriadorConcretoA();
IProduto produtoA = criadorA.CriarProduto();
produtoA.Operar();  // Saída: Operando Produto A

Criador criadorB = new CriadorConcretoB();
IProduto produtoB = criadorB.CriarProduto();
produtoB.Operar();  // Saída: Operando Produto B


// Padrão Abstract Factory

// Interfaces dos produtos
public interface IBotao
{
    void Renderizar();
}

public interface IJanela
{
    void Abrir();
}

// Implementações concretas dos produtos
public class BotaoWindows : IBotao
{
    public void Renderizar()
    {
        Console.WriteLine("Renderizando botão no Windows");
    }
}

public class JanelaWindows : IJanela
{
    public void Abrir()
    {
        Console.WriteLine("Abrindo janela no Windows");
    }
}

public class BotaoMac : IBotao
{
    public void Renderizar()
    {
        Console.WriteLine("Renderizando botão no Mac");
    }
}

public class JanelaMac : IJanela
{
    public void Abrir()
    {
        Console.WriteLine("Abrindo janela no Mac");
    }
}

// Abstract Factory
public interface IFactory
{
    IBotao CriarBotao();
    IJanela CriarJanela();
}

// Fábricas concretas
public class WindowsFactory : IFactory
{
    public IBotao CriarBotao()
    {
        return new BotaoWindows();
    }

    public IJanela CriarJanela()
    {
        return new JanelaWindows();
    }
}

public class MacFactory : IFactory
{
    public IBotao CriarBotao()
    {
        return new BotaoMac();
    }

    public IJanela CriarJanela()
    {
        return new JanelaMac();
    }
}

// Uso
IFactory fabrica = new WindowsFactory();
IBotao botao = fabrica.CriarBotao();
IJanela janela = fabrica.CriarJanela();

botao.Renderizar();  // Saída: Renderizando botão no Windows
janela.Abrir();      // Saída: Abrindo janela no Windows


// Padrão Adapter

// O padrão Adapter permite que objetos com interfaces incompatíveis trabalhem juntos. Ele converte a interface de uma classe em outra interface que o cliente espera.

// Interface esperada
public interface IQuadrado
{
    void DesenharQuadrado();
}

// Classe existente com interface incompatível
public class Circulo
{
    public void DesenharCirculo()
    {
        Console.WriteLine("Desenhando um círculo.");
    }
}

// Adapter que faz a ponte entre Circulo e IQuadrado
public class CirculoParaQuadradoAdapter : IQuadrado
{
    private Circulo _circulo;

    public CirculoParaQuadradoAdapter(Circulo circulo)
    {
        _circulo = circulo;
    }

    public void DesenharQuadrado()
    {
        // Adaptando o método
        _circulo.DesenharCirculo();
    }
}

// Uso
Circulo circulo = new Circulo();
IQuadrado quadradoAdaptado = new CirculoParaQuadradoAdapter(circulo);
quadradoAdaptado.DesenharQuadrado();  // Saída: Desenhando um círculo.


// Padrão Facade

// O Facade fornece uma interface simplificada para um subsistema complexo, escondendo seus detalhes internos e tornando-o mais fácil de usar.

// Subsistemas complexos
public class SistemaDeAudio
{
    public void ConfigurarAudio()
    {
        Console.WriteLine("Configurando áudio.");
    }
}

public class SistemaDeVideo
{
    public void ConfigurarVideo()
    {
        Console.WriteLine("Configurando vídeo.");
    }
}

public class SistemaDeRede
{
    public void ConectarInternet()
    {
        Console.WriteLine("Conectando à internet.");
    }
}

// Facade
public class SistemaEntretenimentoFacade
{
    private SistemaDeAudio _audio;
    private SistemaDeVideo _video;
    private SistemaDeRede _rede;

    public SistemaEntretenimentoFacade()
    {
        _audio = new SistemaDeAudio();
        _video = new SistemaDeVideo();
        _rede = new SistemaDeRede();
    }

    public void IniciarSistema()
    {
        _audio.ConfigurarAudio();
        _video.ConfigurarVideo();
        _rede.ConectarInternet();
        Console.WriteLine("Sistema de entretenimento iniciado.");
    }
}

// Uso
SistemaEntretenimentoFacade sistema = new SistemaEntretenimentoFacade();
sistema.IniciarSistema();
// Saída:
// Configurando áudio.
// Configurando vídeo.
// Conectando à internet.
// Sistema de entretenimento iniciado.



//  Padrão Composite
// O Composite permite que objetos sejam tratados de maneira uniforme, tanto se forem objetos simples quanto composições de outros objetos. Ele é usado para representar hierarquias de objetos.

// Componente base
public abstract class ComponenteGrafico
{
    public abstract void Renderizar();
}

// Objeto folha
public class Circulo : ComponenteGrafico
{
    public override void Renderizar()
    {
        Console.WriteLine("Renderizando círculo.");
    }
}

// Outro objeto folha
public class Retangulo : ComponenteGrafico
{
    public override void Renderizar()
    {
        Console.WriteLine("Renderizando retângulo.");
    }
}

// Composto
public class GrupoDeComponentes : ComponenteGrafico
{
    private List<ComponenteGrafico> _componentes = new List<ComponenteGrafico>();

    public void Adicionar(ComponenteGrafico componente)
    {
        _componentes.Add(componente);
    }

    public void Remover(ComponenteGrafico componente)
    {
        _componentes.Remove(componente);
    }

    public override void Renderizar()
    {
        foreach (var componente in _componentes)
        {
            componente.Renderizar();
        }
    }
}

// Uso
GrupoDeComponentes grupo = new GrupoDeComponentes();
grupo.Adicionar(new Circulo());
grupo.Adicionar(new Retangulo());

grupo.Renderizar();
// Saída:
// Renderizando círculo.
// Renderizando retângulo.


//  Padrão Observer
// O Observer define uma dependência de um-para-muitos entre objetos, onde um objeto (o subject) notifica outros objetos (observers) sobre mudanças em seu estado, permitindo um relacionamento assíncrono entre eles.

// Interface Observer
public interface IObservador
{
    void Atualizar(string estado);
}

// Sujeito (Subject)
public class Sujeito
{
    private List<IObservador> _observadores = new List<IObservador>();
    private string _estado;

    public void AdicionarObservador(IObservador observador)
    {
        _observadores.Add(observador);
    }

    public void RemoverObservador(IObservador observador)
    {
        _observadores.Remove(observador);
    }

    public void AlterarEstado(string novoEstado)
    {
        _estado = novoEstado;
        NotificarObservadores();
    }

    private void NotificarObservadores()
    {
        foreach (var observador in _observadores)
        {
            observador.Atualizar(_estado);
        }
    }
}

// Implementação de um observador
public class ObservadorConcreto : IObservador
{
    private string _nome;

    public ObservadorConcreto(string nome)
    {
        _nome = nome;
    }

    public void Atualizar(string estado)
    {
        Console.WriteLine($"{_nome} recebeu a notificação: Estado mudou para {estado}");
    }
}

// Uso
Sujeito sujeito = new Sujeito();
IObservador observador1 = new ObservadorConcreto("Observador 1");
IObservador observador2 = new ObservadorConcreto("Observador 2");

sujeito.AdicionarObservador(observador1);
sujeito.AdicionarObservador(observador2);

sujeito.AlterarEstado("Ativo");
// Saída:
// Observador 1 recebeu a notificação: Estado mudou para Ativo
// Observador 2 recebeu a notificação: Estado mudou para Ativo


// Padrão Strategy
// O Strategy define uma família de algoritmos, encapsula cada um deles e os torna intercambiáveis. O padrão permite que o algoritmo varie independentemente dos clientes que o utilizam.

// Interface Strategy
public interface IComportamentoDePagamento
{
    void Pagar(decimal valor);
}

// Implementações concretas das estratégias
public class PagamentoComCartao : IComportamentoDePagamento
{
    public void Pagar(decimal valor)
    {
        Console.WriteLine($"Pagando {valor:C} com cartão.");
    }
}

public class PagamentoComBoleto : IComportamentoDePagamento
{
    public void Pagar(decimal valor)
    {
        Console.WriteLine($"Pagando {valor:C} com boleto.");
    }
}

// Classe de contexto que usa a estratégia
public class Pedido
{
    private IComportamentoDePagamento _comportamentoDePagamento;

    public Pedido(IComportamentoDePagamento comportamentoDePagamento)
    {
        _comportamentoDePagamento = comportamentoDePagamento;
    }

    public void DefinirComportamentoDePagamento(IComportamentoDePagamento comportamentoDePagamento)
    {
        _comportamentoDePagamento = comportamentoDePagamento;
    }

    public void RealizarPagamento(decimal valor)
    {
        _comportamentoDePagamento.Pagar(valor);
    }
}

// Uso
Pedido pedido = new Pedido(new PagamentoComCartao());
pedido.RealizarPagamento(100.00m);  // Saída: Pagando R$100,00 com cartão.

pedido.DefinirComportamentoDePagamento(new PagamentoComBoleto());
pedido.RealizarPagamento(200.00m);  // Saída: Pagando R$200,00 com boleto.


// Padrão Command
// O Command encapsula uma solicitação como um objeto, permitindo parametrizar clientes com diferentes solicitações, fazer log de solicitações e oferecer suporte a operações como desfazer.

// Interface Command
public interface IComando
{
    void Executar();
    void Desfazer();
}

// Receptor da ação
public class Luz
{
    public void Ligar()
    {
        Console.WriteLine("Luz acesa.");
    }

    public void Desligar()
    {
        Console.WriteLine("Luz apagada.");
    }
}

// Comando concreto para ligar a luz
public class ComandoLigarLuz : IComando
{
    private Luz _luz;

    public ComandoLigarLuz(Luz luz)
    {
        _luz = luz;
    }

    public void Executar()
    {
        _luz.Ligar();
    }

    public void Desfazer()
    {
        _luz.Desligar();
    }
}

// Invocador que invoca comandos
public class ControleRemoto
{
    private IComando _comando;

    public void DefinirComando(IComando comando)
    {
        _comando = comando;
    }

    public void PressionarBotao()
    {
        _comando.Executar();
    }

    public void PressionarDesfazer()
    {
        _comando.Desfazer();
    }
}

// Uso
Luz luz = new Luz();
IComando ligarLuz = new ComandoLigarLuz(luz);

ControleRemoto controle = new ControleRemoto();
controle.DefinirComando(ligarLuz);

controle.PressionarBotao();  // Saída: Luz acesa.
controle.PressionarDesfazer();  // Saída: Luz apagada.
