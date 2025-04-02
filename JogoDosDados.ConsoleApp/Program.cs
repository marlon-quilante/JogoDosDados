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
                int posicaoComputador = 0;
                bool jogoEstaEmAndamento = true;

                while (jogoEstaEmAndamento)
                {
                    //Turno do usuário
                    ExibirCabecalho("Usuário");
                    int resultadoUsuario = LancarDado();
                    ExibirResultadoSorteio(resultadoUsuario);
                    posicaoUsuario = AvancarCasaUsuario(posicaoUsuario, resultadoUsuario);

                    if (UsuarioVenceu(posicaoUsuario, limiteLinhaChegada))
                    {
                        Console.WriteLine("Parabéns, você alcançou a linha de chegada!");
                        Console.Write("\nPressione ENTER para continuar...");
                        Console.ReadLine();
                        jogoEstaEmAndamento = false;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Você está na posição: {posicaoUsuario} de {limiteLinhaChegada}");
                        Console.Write("\nPressione ENTER para continuar...");
                        Console.ReadLine();
                    }

                    //Turno do computador
                    ExibirCabecalho("Computador");
                    int resultadoComputador = LancarDado();
                    ExibirResultadoSorteio(resultadoComputador);
                    posicaoComputador = AvancarCasaComputador(posicaoComputador, resultadoComputador);

                    if (ComputadorVenceu(posicaoComputador, limiteLinhaChegada))
                    {
                        Console.WriteLine("Que pena, o computador alcançou a linha de chegada!");
                        Console.Write("\nPressione ENTER para continuar...");
                        Console.ReadLine();
                        jogoEstaEmAndamento = false;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"O computador está na posição: {posicaoComputador} de {limiteLinhaChegada}");
                        Console.Write("\nPressione ENTER para continuar...");
                        Console.ReadLine();
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

        static int AvancarCasaUsuario(int posicaoUsuario, int resultadoUsuario)
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

        static bool UsuarioVenceu(int posicaoUsuario, int limiteLinhaChegada)
        {
            if (posicaoUsuario >= limiteLinhaChegada)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int AvancarCasaComputador(int posicaoComputador, int resultadoComputador)
        {
            while (true)
            {
                posicaoComputador += resultadoComputador;

                if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15)
                {
                    Console.WriteLine("O computador parou em uma posição sorteada e irá avançar mais 3 casas!\n");
                    posicaoComputador += 3;
                }

                if (posicaoComputador == 7 || posicaoComputador == 14 || posicaoComputador == 20)
                {
                    Console.WriteLine("O computador parou em uma posição com armadilha e irá retornar 2 casas!\n");
                    posicaoComputador -= 2;
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
            return posicaoComputador;
        }

        static bool ComputadorVenceu(int posicaoComputador, int limiteLinhaChegada)
        {
            if (posicaoComputador >= limiteLinhaChegada)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
