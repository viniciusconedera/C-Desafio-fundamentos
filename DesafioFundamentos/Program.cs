using System.ComponentModel;
using System.Globalization;

namespace DesafioFundamentos;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine("Digite o numero correspondente a operação que deseja:");
        Console.WriteLine("Digite 1 para Bem vindo:");
        Console.WriteLine("Digite 2 para Nome completo");
        Console.WriteLine("Digite 3 para Calculadora");
        Console.WriteLine("Digite 4 para Contar letras");
        Console.WriteLine("Digite 5 para Verifica placa");
        Console.WriteLine("Digite 6 para Data de hoje");
        string? operacao = Console.ReadLine();
        int opSelecionada;
        bool opIsNumber = int.TryParse(operacao, out opSelecionada);
        if (opIsNumber)
        {
            double resultado;
            switch (opSelecionada)
            {
                case 1:
                    program.Bemvindo();
                    break;
                case 2:
                    program.NomeCompleto();
                    break;
                case 3:
                    program.Calculadora();
                    break;
                case 4:
                    program.ContarLetras();
                    break;
                case 5:
                    program.VerificaPlaca();
                    break;
                case 6:
                    program.DataHoje();
                    break;
                default:
                    Console.WriteLine("Digite uma opção valida!");
                    resultado = 0;
                    break;
            }
        };
    }

    private void Bemvindo()
    {
        Console.Write("Digite seu nome: ");
        string? nome = Console.ReadLine();
        Console.WriteLine("Olá, " + nome + " Seja muito bem-vindo!");
    }

    private void NomeCompleto()
    {
        Console.Write("Digite seu primeiro nome: ");
        string? nome = Console.ReadLine();
        Console.Write("Digite seu sobrenome: ");
        string? sobrenome = Console.ReadLine();
        Console.WriteLine(string.Format("Nome completo: {0} {1}", nome, sobrenome));
    }

    private void Calculadora()
    {
        double num1, num2;
        bool num1IsNumber, num2IsNumber;

        Console.WriteLine("Calculadora");
        do
        {
            Console.Write("Digite o primeiro numero: ");
            string? numero1 = Console.ReadLine();
            Console.Write("Digite o segunda numero: ");
            string numero2 = Console.ReadLine();
            num1IsNumber = double.TryParse(numero1, out num1);
            num2IsNumber = double.TryParse(numero2, out num2);
        } while (!num1IsNumber || !num2IsNumber);

        Console.WriteLine("Digite o numero correspondente a operação que deseja:");
        Console.WriteLine("Digite 1 para Somar:");
        Console.WriteLine("Digite 2 para subtrair");
        Console.WriteLine("Digite 3 para multiplicar");
        Console.WriteLine("Digite 4 para dividir");
        Console.WriteLine("Digite 5 para media");
        string? operacao = Console.ReadLine();
        int opSelecionada;
        bool opIsNumber = int.TryParse(operacao, out opSelecionada);
        if (opIsNumber)
        {
            double resultado;
            switch (opSelecionada)
            {
                case 1:
                    resultado = Somar(num1, num2);
                    break;
                case 2:
                    resultado = Subtrair(num1, num2);
                    break;
                case 3:
                    resultado = Multiplicar(num1, num2);
                    break;
                case 4:
                    resultado = Dividir(num1, num2);
                    break;
                case 5:
                    resultado = Media(num1, num2);
                    break;
                default:
                    Console.WriteLine("Digite uma opção valida!");
                    resultado = 0;
                    break;
            }
            Console.WriteLine("O resultado é: " + resultado);
        }
    }

    private double Somar(double numero1, double numero2)
    {
        return numero1 + numero2;
    }

    private double Subtrair(double numero1, double numero2)
    {
        return numero1 - numero2;
    }

    private double Multiplicar(double numero1, double numero2)
    {
        return numero1 * numero2;
    }

    private double Dividir(double numero1, double numero2)
    {
        if (numero2 == 0)
        {
            Console.WriteLine("O segunto numero deve ser diferente de 0.");
            return 0;
        }
        return numero1 / numero2;
    }

    private double Media(double numero1, double numero2)
    {
        return (numero1 + numero2) / 2;
    }

    private void ContarLetras()
    {
        Console.WriteLine("Digite uma palavra ou frase");
        string? frase = Console.ReadLine();
        if (frase is not null)
        {
            Console.WriteLine("O que foi digita possui " + frase.Length + " caracteres.");
        }
    }

    private bool VerificaPlaca()
    {
        Console.Write("Digite uma placa de automovel para verificar: ");
        string? placa = Console.ReadLine();
        if (placa is not null && placa.Length == 7)
        {
            for (int i = 0; i < 3; i++)
            {
                int placeholder;
                bool isNum = int.TryParse(placa[i].ToString(), out placeholder);
                if (isNum)
                {
                    Console.WriteLine("Falso");
                    return false;
                }
            }
            int placaNums;
            bool hasNum = int.TryParse(placa.Substring(3), out placaNums);
            if (!hasNum)
            {
                Console.WriteLine("Falso");
                return false;
            }
            Console.WriteLine("Verdadeiro");
            return true;
        }
        Console.WriteLine("Falso");
        return false;
    }

    private void DataHoje()
    {
        DateTime dateTime = DateTime.Now;
        Console.Write("Data atual: ");
        Console.WriteLine(dateTime.ToString("dd/MM/yyyy",new CultureInfo("pt-BR")));
        Console.Write("Hora atual: ");
        Console.WriteLine(dateTime.ToString("HH", new CultureInfo("pt-BR")));
        Console.Write("Data atual por extenso: ");
        Console.WriteLine(dateTime.ToString("dd \\de MMMM \\de yyyy", new CultureInfo("pt-BR")));
    }
}