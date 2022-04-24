namespace OrgansInSuperiorLanguage;

public static class Program
{

    private static BodyChoice ChoosePart()
    {
        var isValidChoice = false;
        BodyChoice choice = 0;

        while (!isValidChoice)
        {
            Console.Clear();
            Console.Write(@"Hi! Before you continue, please pick your area to attack. Choices below.

#1 - Torso
#2 - Head
#3 - Legs

Please input answer as seen above (i.e. head)
");

            isValidChoice = Enum.TryParse<BodyChoice>(Console.ReadLine(), true, out choice);
        }

        return choice;
    }

    private static WeaponChoice ChooseWeapon(BodyChoice bodyChoice, int health)
    {
        var isValidWeapon = false;
        WeaponChoice weaponChoice = 0;

        while (!isValidWeapon) //choose weapon
        {
            Console.Clear();
            Console.Write($@"You have chosen...
{bodyChoice}.
{bodyChoice} has {health} HP!

You can attack with, Grenade (10 HP), Pistol (5 HP) and Punch (1 HP).

Grenade, Pistol or Punch? ");

            isValidWeapon = Enum.TryParse<WeaponChoice>(Console.ReadLine(), true, out weaponChoice);

        }

        return weaponChoice;

    }

    private static int GetDamage(WeaponChoice weaponIn) => weaponIn switch
    {
        WeaponChoice.Punch => 1,
        WeaponChoice.Grenade => 10,
        WeaponChoice.Pistol => 5,
        _ => 0,
    };

    public static void Main()
    {
        var health = 100;

        Console.BackgroundColor = ConsoleColor.Black; //console
        Console.ForegroundColor = ConsoleColor.Green; //"

        var bodyChoice = ChoosePart();

        Console.Clear();

        while (health != 0)
        {
            var weaponChoice = ChooseWeapon(bodyChoice, health);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White; //console

            Console.WriteLine(@$"BODY PART: {bodyChoice}    HEALTH: {health}    WEAPON: {weaponChoice}

Press any key to attack the {bodyChoice}. . .");
            Console.ReadKey(); //wait for any key



            health -= GetDamage(weaponChoice);

            Console.ForegroundColor = health switch
            {
                > 90 => ConsoleColor.White,
                > 80 => ConsoleColor.Gray,
                > 70 => ConsoleColor.Yellow,
                > 60 => ConsoleColor.DarkYellow,
                > 50 => ConsoleColor.Cyan,
                > 40 => ConsoleColor.DarkCyan,
                > 30 => ConsoleColor.Blue,
                > 20 => ConsoleColor.DarkBlue,
                > 10 => ConsoleColor.Red,
                _ => ConsoleColor.DarkRed,
            };
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Well done, you have defeated the {bodyChoice}");
        Thread.Sleep(5000);
        Console.WriteLine("\nPress any key to EXIT. . . ");
        Console.ReadKey();

    }
}

enum WeaponChoice
{
    Grenade, Pistol, Punch
}

enum BodyChoice
{
    Torso, Head, Legs
}