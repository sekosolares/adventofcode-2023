// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Text.Json;

internal class Program
{
    static Dictionary<string, int> configuration = new()
    {
        { "red", 12 }, { "green", 13 }, { "blue", 14 }
    };

    private static Dictionary<string, string> getGameDictionary(string game) {
        string gameId = game.Split(":")[0].Split(" ")[1].Trim();
        string gameRounds = game.Split(":")[1].Trim();
        Dictionary<string, string> gameDict= new()
        {
            { gameId, gameRounds }
        };

        return gameDict;
    }

    private static void printStringy(ArrayList toPrint)
    {
        var opts = new JsonSerializerOptions { WriteIndented = true };
        var strDict = JsonSerializer.Serialize(toPrint, opts);
        Console.WriteLine(strDict);
    }
    private static void printStringy(Dictionary<string, string> toPrint)
    {
        var opts = new JsonSerializerOptions { WriteIndented = true };
        var strDict = JsonSerializer.Serialize(toPrint, opts);
        Console.WriteLine(strDict);
    }
    private static void printStringy(Array toPrint)
    {
        var opts = new JsonSerializerOptions { WriteIndented = true };
        var strDict = JsonSerializer.Serialize(toPrint, opts);
        Console.WriteLine(strDict);
    }

    private static void Main(string[] args)
    {
        string[] fileContent = File.ReadAllLines("./files/input-d2.txt");
        ArrayList gamesData = new();
        ArrayList possibleGames = new();

        foreach (string file in fileContent)
        {
            gamesData.Add(getGameDictionary(file));
        }

        foreach (Dictionary<string, string> data in gamesData)
        {
            foreach (KeyValuePair<string, string> game in data)
            {
                bool isPossible = true;
                Array rounds = game.Value.Split("; ");
                foreach (string round in rounds)
                {
                    Array colorsInfo = round.Split(", ");
                    foreach (string color in colorsInfo)
                    {
                        Array colorData = color.Split(" ");
                        if (colorData.GetValue(0) == null || colorData.GetValue(1) == null)
                        {
                            continue;
                        }
                        string quantity = (string)colorData.GetValue(0);
                        string colorName = (string)colorData.GetValue(1);
                        int colorQty = Int32.Parse(quantity);

                        isPossible = isPossible && configuration.GetValueOrDefault<string, int>(colorName) >= colorQty;
                    }
                }
                if (isPossible)
                {
                    possibleGames.Add(data);
                }
            }
        }

        int sum = 0;
        foreach (Dictionary<string, string> possible in possibleGames)
        {
            foreach(KeyValuePair<string, string> vals in possible)
            {
                sum += Int32.Parse(vals.Key);
            }
        }
        Console.WriteLine($"The sum is: {sum}");
    }
}
