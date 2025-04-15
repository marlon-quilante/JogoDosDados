using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDosDados.ConsoleApp
{
    internal class Jogador
    {
        int posicao = 0;

        public void ExecutarRodada()
        {
            ExibirCabecalho("Usuário");
            int resultadoUsuario = LancarDado();
            ExibirResultadoSorteio(resultadoUsuario);
            posicao = AvancarCasa(posicao, resultadoUsuario);

            if (Venceu())
            {
                Console.WriteLine("Parabéns, você alcançou a linha de chegada!");
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();
                Program.jogoEstaEmAndamento = false;
            }
            else
            {
                Console.WriteLine($"Você está na posição: {posicao} de {Program.limiteLinhaChegada}");
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }
        }

        public int AvancarCasa(int posicaoUsuario, int resultadoUsuario)
        {
            while (true)
            {
                posicaoUsuario += resultadoUsuario;

                if (posicaoUsuario == 5 || posicaoUsuario == 10 || posicaoUsuario == 15)
                {
                    Console.WriteLine("Você parou em uma posição sorteada e irá avançar mais 3 casas!\n");
                    posicaoUsuario += 3;
                }

                if (posicaoUsuario == 7 || posicaoUsuario == 14 || posicaoUsuario == 20)
                {
                    Console.WriteLine("Você parou em uma posição com armadilha e irá retornar 2 casas!\n");
                    posicaoUsuario -= 2;
                }

                if (resultadoUsuario == 6)
                {
                    Console.WriteLine("\nVocê tirou 6 no dado e pode jogar mais uma vez!");
                    Console.WriteLine("\nPressione ENTER para lançar o dado novamente...");
                    Console.ReadLine();
                    resultadoUsuario = LancarDado();
                    ExibirResultadoSorteio(resultadoUsuario);
                }

                else
                {
                    break;
                }
            }
            return posicaoUsuario;
        }

        public bool Venceu()
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

        void ExibirCabecalho(string nomeJogador)
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

        int LancarDado()
        {
            Random geradorDeNumeros = new Random();

            return geradorDeNumeros.Next(1, 7);
        }

        void ExibirResultadoSorteio(int resultado)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"O valor sorteado foi: {resultado}");
            Console.WriteLine("------------------------------------------");
        }
    }
}
