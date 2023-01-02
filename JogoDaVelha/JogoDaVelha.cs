using System;
using System.Threading;
namespace JogoDaVelha
{
    class Program
    {
        static char[] arr = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int jogador = 1; //jogador é definido, começa em X
        static int posicao; // posicao tabuleiro

        static int vencedor = 0;// começa sem vencedor, se 1 tem ganhador, se -1 empate
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();//quando a há troca de turno a console será limpo para nova escolha 
                Console.WriteLine("Player1:X e Player2:O");
                Console.WriteLine("\n");
                if (jogador % 2 == 0)//se player for par ele imprimi player2, se nao imprimi player1, pois incrementamos o player ele ja começa com 1
                {
                    Console.WriteLine("Player 2");
                }
                else
                {
                    Console.WriteLine("Player 1");
                }
                Console.WriteLine("\n");
                Tabela();//chamando a tabela
                posicao = int.Parse(Console.ReadLine()) -1;//escolha das posicoes no tabuleiro, indece começa no 0.
             
                if (arr[posicao] != 'X' && arr[posicao] != 'O')// aqui fazemos as trocas dos turnos
                {
                    if (jogador % 2 == 0) 
                    {
                        arr[posicao] = 'O';
                        jogador++;
                    }
                    else
                    {
                        arr[posicao] = 'X';
                        jogador++;
                    }
                }
                else
                //verificamos se esta disponivel a posicao 
                {
                    Console.WriteLine("A posicao {0} já esta marcada pelo {1}", posicao, arr[posicao]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Marque outra opção.....");
                    Thread.Sleep(2000);// mostra em 2 seg
                }
                vencedor = Vencedor();// chamando a funcao vencedor
            }
            while (vencedor != 1 && vencedor != -1);// enquanto nao houver ganhador, nem empate...
            Console.Clear();// limpa o console
            Tabela();// mostra o tabuleiro até ser preenchido

            if (vencedor == 1)
            {
                Console.WriteLine("Player {0} ganhou", (jogador % 2) + 1);//aqui pegamos o vencedor(ultimo a jogar) +1 e mostra quem ganhou
            }
            else
            {
                Console.WriteLine("Empate, não houve vencedor");
            }
            Console.ReadLine();
        }
        
        private static void Tabela()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[0], arr[1], arr[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[3], arr[4], arr[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[6], arr[7], arr[8]);
            Console.WriteLine("     |     |      ");
        }
        
        private static int Vencedor()// aqui teremos um vencedor
        {
            #region Condicao de vencedor Horizontal
      
            if (arr[0] == arr[1] && arr[1] == arr[2])
            {
                return 1;
            }
        
            else if (arr[3] == arr[4] && arr[4] == arr[5])
            {
                return 1;
            }
            
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion
            #region Condicao de vencedor Vertical
         
            else if (arr[0] == arr[3] && arr[3] == arr[6])
            {
                return 1;
            }
            
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
           
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            #endregion
            #region Condicao de vencedor Diagonal
            else if (arr[0] == arr[4] && arr[4] == arr[8])
            {
                return 1;
            }
            else if (arr[2] == arr[4] && arr[4] == arr[6])
            {
                return 1;
            }
            #endregion
            #region Checando o tabuleiro
            
            else if (arr[0] != '1' && arr[1] != '2' && arr[2] != '3' && arr[3] != '4' && arr[4] != '5' && arr[5] != '6' && arr[6] != '7' && arr[7] != '8' && arr[8] != '9')
            {// se as casas ainda estiverem em string numeral o jogo nao tem vencedor
                return -1;
            }
            #endregion
            else// se nao empate
            {
                return 0;
            }
        }
    }
}