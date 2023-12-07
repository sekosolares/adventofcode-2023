// See https://aka.ms/new-console-template for more information

using System.ComponentModel;

class Program
{

    static void Main(string[] args)
    {
        int result  = 0;
        string[] encryptedCoordinatesLines = File.ReadAllLines("./inputFiles/inputOscar-d1.txt");
        
        foreach (string encryptedLine in encryptedCoordinatesLines)
        {
            int numberRetrieved = getNumberFromLine(encryptedLine);
            result += numberRetrieved;
        }

        Console.Write(result);
    }

    public static int getNumberFromLine(string encryptedLine)
    {
        int lineLength = encryptedLine.Length;
        string textNumberFound = "";
        int intNumberFound = 0;

        //Get First Digit
        for (int i = 0; i < lineLength; i++)
        {
            if (Char.IsDigit(encryptedLine[i]))
            {
                textNumberFound = Char.ToString(encryptedLine[i]);
                break;
            }
        }

        //Get Last Digit
        for (int i = lineLength-1; i > -1; i--)
        {
            if (Char.IsDigit(encryptedLine[i]))
            {
                textNumberFound += Char.ToString(encryptedLine[i]);
                break;
            }
        }

        intNumberFound = int.Parse(textNumberFound);

        return intNumberFound;
    }
}