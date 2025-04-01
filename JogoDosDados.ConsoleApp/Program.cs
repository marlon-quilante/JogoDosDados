namespace JogoDosDados.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int limiteLinhaChegada = 30;

            while (true)
            {
                int posicaoUsuario = 0;
                bool jogoEstaEmAndamento = true;

                while (jogoEstaEmAndamento)
                {
                    ExibirCabecalho();

                    int resultado = LancarDado();

                    ExibirResultadoSorteio(resultado);

                    posicaoUsuario += resultado;

                    if (posicaoUsuario >= limiteLinhaChegada)
                    {
                        Console.WriteLine("Parabéns, você alcançou a linha de chegada!");
                        jogoEstaEmAndamento = false;
                    }
                    else
                    {
                        Console.WriteLine($"O jogador está na posição: {posicaoUsuario} de {limiteLinhaChegada}");
                    }

                    Console.Write("\nPressione ENTER para continuar...");
                    Console.ReadLine();
                }

                string opcaoContinuar = ExibirMenuContinuar();

                if (opcaoContinuar != "S")
                    break;
            }
        }

        static void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Jogo dos Dados");
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("Pressione ENTER para lançar o dado...");
            Console.ReadLine();
        }

        static int LancarDado()
        {
            Random geradorDeNumeros = new Random();

            return geradorDeNumeros.Next(1, 7);
        }

        static void ExibirResultadoSorteio(int resultado)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"O valor sorteado foi: {resultado}");
            Console.WriteLine("------------------------------------------");            
        }

        static string ExibirMenuContinuar()
        {
            Console.Write("\nDeseja continuar? (S/N) ");
            return Console.ReadLine()!.ToUpper();
        }
    }
}
