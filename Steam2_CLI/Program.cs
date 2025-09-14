using System.Diagnostics;
using System.Runtime.CompilerServices;

string welcomeMessage = "\nBoas vindas ao Screen Sound";
string logo = @"

░██████╗████████╗███████╗░█████╗░███╗░░░███╗  ██████╗░
██╔════╝╚══██╔══╝██╔════╝██╔══██╗████╗░████║  ╚════██╗
╚█████╗░░░░██║░░░█████╗░░███████║██╔████╔██║  ░░███╔═╝
░╚═══██╗░░░██║░░░██╔══╝░░██╔══██║██║╚██╔╝██║  ██╔══╝░░
██████╔╝░░░██║░░░███████╗██║░░██║██║░╚═╝░██║  ███████╗
╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚═╝░░░░░╚═╝  ╚══════╝";

Dictionary<string, List<int>> gameDictionary = new Dictionary<string, List<int>>(StringComparer.OrdinalIgnoreCase);
gameDictionary.Add("Baldur's Gate 3", new List<int> { 10, 8, 9 });
gameDictionary.Add("Fifa 2025", new List<int> { 3, 4, 6 });

void showLogo() 
{
    Console.WriteLine(logo);
}
void showWelcomeMessage()
{
    
    Console.WriteLine(welcomeMessage);
}
void gotoMenuOptions()
{
    Console.Clear();
    showLogo();
    Console.WriteLine("\n\nEscolha uma das opções abaixo digitando o número correspondente: ");
    Console.WriteLine("\n1 - Registrar um jogo");
    Console.WriteLine("2 - Exibir todos os jogos");
    Console.WriteLine("3 - Avaliar um jogo");
    Console.WriteLine("4 - Exibir a nota média de um jogo");
    Console.WriteLine("5 - Sair do Steam 2");
    Console.Write("\nEscolha sua opção: ");
    int optionChosen = int.Parse(Console.ReadLine()!);

    switch (optionChosen)
{
    case 1:
        registerGame();
        break;
    case 2:
        showAllGame();
        break;
    case 3:
        rateGame();
        break;
    case 4:
        showGamerate();
        break;
    case 5:
        Console.Clear();
        Console.WriteLine("Encerrando o programa...");
        Console.WriteLine("\n -Desenvolvido por Anderson Luciano");
        Thread.Sleep(2000);
        Console.Clear();
        break;
    default:
        Console.WriteLine($"A Opção '{optionChosen}' não é válida");
        Thread.Sleep(2000);
        gotoMenuOptions();
        break;
}

}
void registerGame()
{
    Console.Clear();
    showTitleOption("Registro de jogo");
    Console.Write("\nNome do jogo para registro: ");
    string gameName = Console.ReadLine()!;
    gameDictionary.Add(gameName, new List<int>());
    Console.WriteLine($"O jogo {gameName} foi registrado com sucesso.");
    Thread.Sleep(2000); 
    gotoMenuOptions();
}
void showAllGame()
{
    Console.Clear();
    showTitleOption("Exibindo todos os jogos");

   foreach (var par in gameDictionary)
{
    Console.WriteLine(par.Key);
}

    Console.WriteLine("\nDigite qualquer tecla pra voltar ao menu principal");
    Console.ReadLine();
    gotoMenuOptions();
}
void showTitleOption(string title)
{
    int lengthNumber = title.Length;
    string asteriscos = string.Empty.PadLeft(lengthNumber, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(title);
    Console.WriteLine(asteriscos + "\n");
}
void rateGame()

{
    while (true)
    {
        Console.Clear();
        showTitleOption("Avaliar jogo");
        Console.Write("Digite o nome do jogo que deseja avaliar: ");
        string chosenGame = Console.ReadLine()!;

        
        if (gameDictionary.ContainsKey(chosenGame))
        {
            Console.Write($"Escreva sua nota para {chosenGame}: ");
            int userRate = int.Parse(Console.ReadLine()!);
            gameDictionary[chosenGame].Add(userRate);
            Console.WriteLine($"\nA nota '{userRate}' foi atribuída com sucesso à {chosenGame} ");
            Thread.Sleep(2000);
            gotoMenuOptions();
            break;
        }
        else
        {
            Console.WriteLine($"O jogo '{chosenGame}' não está registrado.");
            Console.Write("\nDigite qualquer tecla para tentar novamente. Digite -1 para voltar ao Menu\n");
            var anyKey = Console.ReadLine();
            if (anyKey == "-1")
            {
                gotoMenuOptions();
                return;
            }
        }
    }

}
void showGamerate()
{
    double avarageGameRate = 0.0;

    Console.Clear();
    showTitleOption("Exibir média");
    while (true)
    {
        Console.Write("Digite o nome do jogo que você deseja saber a média: ");
        string chosenGame = Console.ReadLine()!;
        if (gameDictionary.ContainsKey(chosenGame) && gameDictionary[chosenGame].Count > 0)
        {
            List<int> gameRatings = gameDictionary[chosenGame];
            avarageGameRate = gameRatings.Average();
            Console.WriteLine($"A avaliação  do jogo {chosenGame} é {avarageGameRate} ");
            Console.WriteLine("\nDigite qualquer tecla para voltar ao menu");
            Console.ReadLine();
            gotoMenuOptions();
            break;
        }
        else
        {
            Console.WriteLine($"O jogo '{chosenGame}' não está registrada ou não possui notas.");
            Console.Write("\nDigite qualquer tecla para tentar novamente. Digite -1 para voltar ao Menu\n");
            var anyKey = Console.ReadLine();
            if (anyKey == "-1")
            {
                gotoMenuOptions();
                return;
            }
        }
    }
}

showWelcomeMessage();
gotoMenuOptions();

