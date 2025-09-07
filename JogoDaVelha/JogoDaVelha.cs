

namespace JogoDaVelha
{
    internal class JogoDaVelha
    {
        private bool FimDeJogo;
        private char[] posicoes;
        private char vez;
        private int quantidadePreenchida;

        public JogoDaVelha()
        {
            FimDeJogo = false;
            posicoes = new [] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'X';
            quantidadePreenchida = 0;
        }

        public void Iniciar()
        {
            while (!FimDeJogo)
            {
                RenderizarTabela();
                LerEscolhaDoUsuario();
                RenderizarTabela();
                VerificarFimDeJogo();
                MudarVez();
            }
        }

        private void MudarVez()

        {
            vez = vez == 'X' ? 'O' : 'X';
        }

        private void VerificarFimDeJogo()
        {
            if (quantidadePreenchida < 5)
                return;

            if (ExisteVitoriaHorizontal() || ExisteVitoriaVertical() || ExisteVitoriaDiagonal())
            {
                FimDeJogo = true;
                Console.WriteLine($"O jogador {vez} venceu!");
                return;
            }

            if (quantidadePreenchida is 9)
            {
                FimDeJogo = true;
                Console.WriteLine("O jogo empatou!");
                return;
            }

        }

        private bool ExisteVitoriaHorizontal()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool vitoriaLinha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool vitoriaLinha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool ExisteVitoriaVertical()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool vitoriaLinha2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool vitoriaLinha3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool ExisteVitoriaDiagonal()
        {
            bool vitoriaLinha1 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];
            bool vitoriaLinha2 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2;
        }



        private void LerEscolhaDoUsuario()
        {
            Console.WriteLine($"É a vez do jogador {vez}, escolha uma posiçao disponivel na tabela (1-9):");

            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);

            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida))
            {
                Console.WriteLine("O campo escolhido é invalido, por favor digite um numeor entre 1 e 9 que esteja disponivel na tabela.");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }

             PreencherEscolha(posicaoEscolhida);
        }
        private void PreencherEscolha(int posicaoEscolhida)
           {
             int indice = posicaoEscolhida - 1;
             posicoes[indice] = vez;
            quantidadePreenchida++;
        }

        private bool ValidarEscolhaUsuario(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            return posicoes[indice] != 'O' && posicoes[indice] != 'X';
        }
        private void RenderizarTabela()
        {
           Console.Clear();
           Console.WriteLine(ObterTabela());
        }

        private string ObterTabela()
        {
            return $"_{posicoes[0]}_|_{posicoes[1]}_|_{posicoes[2]}_\n" +
                   $"_{posicoes[3]}_|_{posicoes[4]}_|_{posicoes[5]}_\n" +
                   $" {posicoes[6]} | {posicoes[7]} | {posicoes[8]} \n\n";
        }
    }
}
