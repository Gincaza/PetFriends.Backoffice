// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// variables that support data entry
int maxPets = 8;

Dictionary<string, Dictionary<string, string>> ourAnimals = new Dictionary<string, Dictionary<string, string>>()
{
    ["d1"] = new Dictionary<string, string>
    {
        ["animalSpecies"] = "dog",
        ["animalAge"] = "2",
        ["animalPhysicalDescription"] = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.",
        ["animalPersonalityDescription"] = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.",
        ["animalNickname"] = "lola"
    },
    ["d2"] = new Dictionary<string, string>
    {
        ["animalSpecies"] = "dog",
        ["animalAge"] = "9",
        ["animalPhysicalDescription"] = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.",
        ["animalPersonalityDescription"] = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.",
        ["animalNickname"] = "loki"
    },
    ["c3"] = new Dictionary<string, string>
    {
        ["animalSpecies"] = "cat",
        ["animalAge"] = "1",
        ["animalPhysicalDescription"] = "small white female weighing about 8 pounds. litter box trained.",
        ["animalPersonalityDescription"] = "friendly",
        ["animalNickname"] = "Puss"
    },
    ["c4"] = new Dictionary<string, string>
    {
        ["animalSpecies"] = "cat",
        ["animalAge"] = "?",
        ["animalPhysicalDescription"] = "",
        ["animalPersonalityDescription"] = "",
        ["animalNickname"] = ""
    }
    // Adicione mais animais conforme necessário
};

// TODO: Convert the if-elseif-else construct to a switch statement

void Main()
{
    while (true)
    {
        Console.Clear();

        Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
        Console.WriteLine(" 1. List all of our current pet information");
        Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
        Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
        Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
        Console.WriteLine(" 5. Edit an animal’s age");
        Console.WriteLine(" 6. Edit an animal’s personality description");
        Console.WriteLine(" 7. Display all cats with a specified characteristic");
        Console.WriteLine(" 8. Display all dogs with a specified characteristic");
        Console.WriteLine();
        Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

        var readResult = Console.ReadLine();

        if (readResult != null && readResult.Equals("Exit", StringComparison.OrdinalIgnoreCase))
        {
            break; // Exit the loop and end the program
        }

        int option;
        if (readResult != null && int.TryParse(readResult, out option))
        {
            OptionPath(option);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid menu number.");
            Console.WriteLine("Press Enter to try again.");
            Console.ReadLine();
            continue;
        }
    }
}

void OptionPath(int option)
{
    switch (option)
    {
        case 1:
            AllPetsList();
            break;
        case 2:
            bool new_animal = AddAnimalPetList();

            if (!new_animal)
            {
                Console.WriteLine("ERROR");
            }
            break;
            
        case 3:
            return;
        case 4:
            return;
        case 5:
            return;
        case 6:
            return;
        case 7:
            return;
        case 8:
            return;
        default:
            return;
    }

    return;
}

void AllPetsList()
{
    foreach (KeyValuePair<string, Dictionary<string, string>> ourAnimal in ourAnimals)
    {
        string id = ourAnimal.Key;
        string species = ourAnimal.Value["animalSpecies"];
        string age = ourAnimal.Value["animalAge"];
        string physicalDescription = ourAnimal.Value["animalPhysicalDescription"];
        string personalityDescription = ourAnimal.Value["animalPersonalityDescription"];
        string nickname = ourAnimal.Value["animalNickname"];

        Console.WriteLine($"ID: {id}, Espécie: {species}, Idade: {age}, Apelido: {nickname}");
    }
    Console.WriteLine();
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
    Console.ReadKey(true);
}

bool AddAnimalPetList()
{
    try
    {
        Console.Clear();
        Console.WriteLine("Let's add a new animal to our shop.");

        string specie;
        do
        {
            Console.Write("What is the species of your animal? ");
            specie = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(specie))
                Console.WriteLine("Species cannot be empty. Please enter a value.");
        } while (string.IsNullOrWhiteSpace(specie));

        string age;
        do
        {
            Console.Write("What is the age of your animal? ");
            age = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(age))
                Console.WriteLine("Age cannot be empty. Please enter a value.");
        } while (string.IsNullOrWhiteSpace(age));

        string physicalDescription;
        do
        {
            Console.Write("Enter a physical description for your animal: ");
            physicalDescription = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(physicalDescription))
                Console.WriteLine("Physical description cannot be empty. Please enter a value.");
        } while (string.IsNullOrWhiteSpace(physicalDescription));

        Console.Write("Enter a personality description for your animal: ");
        string personalityDescription = Console.ReadLine();

        Console.Write("Enter a nickname for your animal: ");
        string nickname = Console.ReadLine();

        // Gera um novo ID único baseado na primeira letra da espécie e um número aleatório de 3 dígitos
        string prefix = !string.IsNullOrWhiteSpace(specie) ? specie.Substring(0, 1).ToUpper() : "X";
        string newId;
        Random rnd = new Random();
        do
        {
            int number = rnd.Next(100, 1000); // Gera número entre 100 e 999
            newId = $"{prefix}{number}";
        } while (ourAnimals.ContainsKey(newId));

        ourAnimals[newId] = new Dictionary<string, string>
        {
            ["animalSpecies"] = specie,
            ["animalAge"] = age,
            ["animalPhysicalDescription"] = physicalDescription,
            ["animalPersonalityDescription"] = personalityDescription,
            ["animalNickname"] = nickname
        };

        Console.WriteLine("Animal cadastrado (simulação). Pressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey(true);
        return true;
    }
    catch
    {
        return false;
    }
}

Main();