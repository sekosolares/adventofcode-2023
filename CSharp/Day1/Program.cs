using System.Text.RegularExpressions;

internal class Program
{
    public static int GetNumberFromLine(string line) {
        string pattern = @"\d";
        MatchCollection numsMatch = Regex.Matches(line.Trim(), pattern);
        string compoundNum = String.Concat(numsMatch.First(), numsMatch.Last());

        return Int32.Parse(compoundNum);
    }

    private static void Main(string[] args) {
        string[] fileContent = File.ReadAllLines("./files/input-d1.txt");
        int result = 0;

        foreach (string line in fileContent) {
            result += GetNumberFromLine(line);
        }

        Console.WriteLine($"Sum of Callibration Values: {result}");
        
    }
}