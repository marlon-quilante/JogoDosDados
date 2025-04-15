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
                Jogador usuario = new Jogador();
                usuario.nome = "Usuário";
                Jogador computador = new Jogador();
                computador.nome = "Computador";

                while (jogoEstaEmAndamento)
                {
                    usuario.ExecutarRodada();

                    if (usuario.Venceu())
                    {
                        usuario.MensagemVitoria();
                        break;
                    }

                    computador.ExecutarRodada();

                    if (computador.Venceu())
                    {
                        computador.MensagemVitoria();
                        break;
                    }
                }

                string opcaoContinuar = ExibirMenuContinuar();

                if (opcaoContinuar != "S")
                    break;
            }
        }

        static string ExibirMenuContinuar()
        {
            Console.Write("\nDeseja jogar novamente? (S/N) ");
            return Console.ReadLine()!.ToUpper();
        }
    }
}
