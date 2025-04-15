namespace JogoDosDados.ConsoleApp
{
    internal class Jogador
    {
        public int posicao = 0;
        public string nome = "";

        public void ExecutarRodada()
        {
            ExibirCabecalho();
            int resultadoUsuario = LancarDado();
            ExibirResultadoSorteio(resultadoUsuario);
            posicao = AvancarCasa(posicao, resultadoUsuario);
            ExibirPosicao();
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

        public void MensagemVitoria()
        {
            Console.Clear();
            Console.WriteLine($"Vitória do {nome}!");
        }

        private void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Jogo dos Dados");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Turno do: {nome}");

            if (nome != "Computador")
            {
                Console.WriteLine("------------------------------------------");
                Console.Write("\nPressione ENTER para lançar o dado...");
                Console.ReadLine();
            }
        }

        private int LancarDado()
        {
            Random geradorDeNumeros = new Random();

            return geradorDeNumeros.Next(1, 7);
        }

        private void ExibirResultadoSorteio(int resultado)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"O valor sorteado foi: {resultado}");
            Console.WriteLine("------------------------------------------");
        }

        public void ExibirPosicao()
        {
            Console.WriteLine($"{nome} na posição: {posicao} de {Program.limiteLinhaChegada}");
            Console.Write("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
