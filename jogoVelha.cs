
using System;

namespace jogoDaVelha
{
    public class Program
    { 
        static void ShowMenu() {
            Console.WriteLine("1 - Novo jogador");
            Console.WriteLine("2 - Deletar um jogador");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("Digite a opção desejada: ");
        }
        static void RegistrarNovoUsuario(List<string> nome, List<string> idade) {
            Console.Write("Digite o nome: ");
            nome.Add(Console.ReadLine());
            Console.Write("Digite a idade: ");
            idade.Add(Console.ReadLine());
        }
        static void DeletarUsuario(List<string> nome) {
            Console.Write("Digite o nome: ");
            string nomeParaDeletar = Console.ReadLine();
            int indexParaDeletar = nome.FindIndex(nome => nome == nomeParaDeletar);
          
            if(indexParaDeletar == -1) {
                Console.WriteLine("Não foi possível deletar este usuário");
                Console.WriteLine("MOTIVO: usuário não encontrado.");
            }

            nome.Remove(nomeParaDeletar);

            Console.WriteLine("Usuário deletado com sucesso");
        }
        public static void Main(string[] args) {

            Console.WriteLine("Antes de começar o jogo, precisamos do seus dados: ");

            List<string> nome = new List<string>();
            List<string> idade = new List<string>();
           
            int option;

            do {
                ShowMenu();
                option = int.Parse(Console.ReadLine());

                Console.WriteLine("-----------------");

                switch (option) {
                    case 0:
                        Console.WriteLine("Estou encerrando o jogo...");
                        break;
                    case 1:
                        RegistrarNovoUsuario(nome, idade);
                        break;
                    case 2:
                        DeletarUsuario(nome);
                        break;
                
                }

                Console.WriteLine("-----------------");

            } while (option != 0);

        }

        }
    }