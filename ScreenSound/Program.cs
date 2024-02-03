//Screen Sound

//Variáveis Globais
string logo = @"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░";
string saudacoes = "\nBem-Vindo(a) ao Screen Sound";

//List<string> listaDeBandas = new List<string>();
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();

void Menu()
{
    ExibirLogo();
    Console.WriteLine("\nMenu de opções:");
    Console.WriteLine("1 - Registrar banda.");
    Console.WriteLine("2 - Listar todas as bandas.");
    Console.WriteLine("3 - Avaliar uma banda.");
    Console.WriteLine("4 - Exibir média de uma banda.");
    Console.WriteLine("0 - Sair.");

    Console.Write("\nDigite o item que deseja executar:");
    int opcaoEscolhida = int.Parse(Console.ReadLine()!);

    switch (opcaoEscolhida)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            ListarBandas();
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4:
            MediaBanda();
            break;
        case 0:
            Console.WriteLine($"Até logo! =)");
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTitulo("Registro de Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeBanda, new List<int>());
    Console.WriteLine($"\nA banda {nomeBanda} fo registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    Menu();
}
void ListarBandas()
{
    Console.Clear();
    ExibirTitulo("Lista de Bandas Registradas");
    foreach (var banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nDigite qualquer tecla para voltar");
    Console.ReadKey();
    Console.Clear();
    Menu();
}
void AvaliarBanda()
{
    Console.Clear();
    ExibirTitulo("Avaliar uma banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        Console.Write($"Insira uma nota para {nomeBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeBanda].Add(nota);
        Console.WriteLine($"\nA nota foi atribuída com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
        Menu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não foi encontrada!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }
}

void MediaBanda()
{
    Console.Clear();
    ExibirTitulo("Média de Avaliações de Banda");
    Console.Write("Digite a banda que deseja ver a média: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        List<int> notasBanda = bandasRegistradas[nomeBanda];
        Console.WriteLine($"\nA média da banda {nomeBanda} é {notasBanda.Average()}");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não foi encontrada!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }
}

//Funções de titulo
void ExibirLogo()
{
    Console.WriteLine(logo);
}
void ExibirTitulo(string titulo)
{
    int qtdLinhas = titulo.Length;
    string asterisco = string.Empty.PadLeft(qtdLinhas, '*');
    Console.WriteLine(asterisco);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisco + "\n");
}

//Mostra na tela
Menu();