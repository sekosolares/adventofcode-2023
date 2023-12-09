using System.Text.RegularExpressions;

internal class Program {
    static readonly Dictionary<string, string> NUMS = new()
    {
        {"one", "1"}, {"two", "2"}, {"three", "3"},
        {"four", "4"}, {"five", "5"}, {"six", "6"},
        {"seven", "7"}, {"eight", "8"}, {"nine", "9"}
    };

    public static string PreprocessLine(string line)
    {
        string newLine = line;

        foreach (KeyValuePair<string, string> kv in NUMS)
        {
            // Put kv.Value between kv.Key, so it still completes spelled numbers
            // before and after it. Since the goal is just having it on the
            // right position, then we get the real first and last number.
            newLine = newLine.Replace(kv.Key, $"{kv.Key}{kv.Value}{kv.Key}");
        }

        return newLine;
    }

    public static int GetNumberFromLine(string line) {
        string pattern = @"\d";
        MatchCollection numsMatch = Regex.Matches(line.Trim(), pattern);
        string compoundNum = String.Concat(numsMatch.First(), numsMatch.Last());

        return Int32.Parse(compoundNum);
    }

    private static void Main(string[] args) {
        string[] fileContent = File.ReadAllLines("./files/input-d1.txt"); // example file: example-d1.txt
        int result = 0;

        foreach (string line in fileContent) {
            string preprocessed = PreprocessLine(line.ToLower());
            result += GetNumberFromLine(preprocessed);
        }

        Console.WriteLine($"Sum of Callibration Values: {result}");
        
    }
}