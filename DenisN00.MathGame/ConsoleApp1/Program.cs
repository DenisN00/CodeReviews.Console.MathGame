using System.Globalization;
using System.Net;
using System.Security.Cryptography.X509Certificates;

Random random = new Random();

bool exitApplication = false;
int menu = 0;

string[] gameHistory = new string[100];
int gamesCounter = 0;
int wins = 0;
int losses = 0;

while (!exitApplication)
{
    Console.Clear();
    Console.WriteLine("---Welcome to the Math-Game---");
    Console.WriteLine("\n1. Start the game");
    Console.WriteLine("2. Look at your games history");
    Console.WriteLine("3. Close the application");

    string readResult = Console.ReadLine();
    if (readResult != null)
        int.TryParse(readResult, out menu);

    switch (menu)
    {
        case 1:
            StartGame();
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("------------------------");
            foreach (string game in gameHistory)
            {
                if (game != null)
                Console.WriteLine(game); 
            }
            Console.WriteLine($"\nTotal games: \t{wins + losses}");
            Console.WriteLine($"Total wins: \t{wins}");
            Console.WriteLine($"Total losses: \t{losses}");
            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.Clear();
            break;
        case 3:
            exitApplication = true;
            break;
        case 4:
            Console.WriteLine(wins);
            Console.WriteLine(losses);
            Console.ReadKey();
            break;
    }
}

void StartGame()
{
    bool exitGame = false;
    int operation = 0;

    while (!exitGame)
    {
        Console.Clear();
        Console.WriteLine("Choose what operation you want to be presented . . .");
        Console.WriteLine("\n1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("\n5. Back to menu");

        string readResult = Console.ReadLine();
        if (readResult != null)
            int.TryParse(readResult, out operation);

        switch (operation)
        {
            case 1:
                WinsCounter(Addition());
                break;
            case 2:
                WinsCounter(Subtraction());
                break;
            case 3:
                WinsCounter(Multiplication());
                break;
            case 4:
                WinsCounter(Division());
                break;
            case 5:
                exitGame = true;
                break;
        }
    }
}

bool Addition()
{
    string operationType = "+";
    int x = random.Next(0, 101);
    int y = random.Next(0, 101);
    int correctResult = x + y;

    return CheckResult(correctResult, x, y, operationType);
}

bool Subtraction()
{
    string operationType = "-";
    int x = random.Next(0, 101);
    int y = random.Next(0, 101);
    int z = 0;

    if (x < y)
    {
        z = x;
        x = y;
        y = z;
    }
    int correctResult = x - y;

    return CheckResult(correctResult, x, y, operationType);
}

bool Multiplication()
{
    string operationType = "*";
    int x = random.Next(0, 101);
    int y = random.Next(0, 101);
    int correctResult = x * y;

    return CheckResult(correctResult, x, y, operationType);
}

bool Division()
{
    string operationType = "/";
    int x = 0;
    int y = 0;

    do
    {
        x = random.Next(0, 101);
        y = random.Next(1, 101);
    }
    while (x % y != 0);

    int correctResult = x / y;

    return CheckResult(correctResult, x, y, operationType);
}

void WinsCounter(bool wonOrLost)
{
    if (wonOrLost == true)
    {
        wins++;
    }
    else
    {
        losses++;
    }
}

bool CheckResult(int correctResult, int x, int y, string operationType)
{
    int userResult = 0;

    Console.Clear();
    Console.WriteLine($"What is the result of {x} {operationType} {y} ?");
    string readResult = Console.ReadLine();
    if (readResult != null)
        int.TryParse(readResult, out userResult);
    Console.Clear();

    if (correctResult == userResult)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{userResult} is the correct result!");
        gameHistory[gamesCounter] = $"What is the result of {x} {operationType} {y} ? \nYour result was correct.";
        gamesCounter++;
        Console.WriteLine("press any key to continue . . .");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Clear();

        return true;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{userResult} is a incorrect result.");
        Console.WriteLine($"The correct result is: {correctResult}");
        gameHistory[gamesCounter] = $"What is the result of {x} {operationType} {y} ? \nYour result was false.";
        gamesCounter++;
        Console.WriteLine("\nPress any key to continue . . .");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Clear();

        return false;
    }
}
