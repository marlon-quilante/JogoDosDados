namespace JogoDosDados.ConsoleApp
{
    internal class Program
    {
        public static int limiteLinhaChegada = 30;
        public static bool jogoEstaEmAndamento = true;

        static void Main(string[] args)
        {
            while (true)
            {
                while (jogoEstaEmAndamento)
                {
                    Usuario.ExecutarRodada();

                    if (Usuario.Venceu())
                    {
                        break;
                    }

                    Computador.ExecutarRodada();

                    if (Computador.Venceu())
                    {
                        break;
                    }
                }

                string opcaoContinuar = ExibirMenuContinuar();

                if (opcaoContinuar != "S")
                    break;
            }
        }

        static void ExibirCabecalho(string nomeJogador)
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Jogo dos Dados");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Turno do: {nomeJogador}");

            if (nomeJogador != "Computador")
            {
                Console.WriteLine("------------------------------------------");
                Console.Write("\nPressione ENTER para lançar o dado...");
                Console.ReadLine();
            }
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
