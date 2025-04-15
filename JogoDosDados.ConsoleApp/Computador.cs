using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDosDados.ConsoleApp
{
    internal class Computador
    {
        public static int posicao = 0;

        public static void ExecutarRodada()
        {
            //Turno do computador
            ExibirCabecalho("Computador");
            int resultadoComputador = LancarDado();
            ExibirResultadoSorteio(resultadoComputador);
            posicao = AvancarCasa(resultadoComputador);

            if (Computador.Venceu())
            {
                Console.WriteLine("Que pena, o computador alcançou a linha de chegada!");
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();
                Program.jogoEstaEmAndamento = false;
            }
            else
            {
                Console.WriteLine($"O computador está na posição: {posicao} de {Program.limiteLinhaChegada}");
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }
        }

        public static int AvancarCasa(int resultadoComputador)
        {
            while (true)
            {
                posicao += resultadoComputador;

                if (posicao == 5 || posicao == 10 || posicao == 15)
                {
                    Console.WriteLine("O computador parou em uma posição sorteada e irá avançar mais 3 casas!\n");
                    posicao += 3;
                }

                if (posicao == 7 || posicao == 14 || posicao == 20)
                {
                    Console.WriteLine("O computador parou em uma posição com armadilha e irá retornar 2 casas!\n");
                    posicao -= 2;
                }

                if (resultadoComputador == 6)
                {
                    Console.WriteLine("\nO computador tirou 6 no dado e pode jogar mais uma vez!");
                    Console.WriteLine("\nPressione ENTER para continuar...");
                    Console.ReadLine();
                    resultadoComputador = LancarDado();
                    ExibirResultadoSorteio(resultadoComputador);
                }
                else
                {
                    break;
                }
            }
            return posicao;
        }

        public static bool Venceu()
        {
            if (posicao >= Program.limiteLinhaChegada)
            {
                return true;
            }
            else
            {
                return false;
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
    }
}
