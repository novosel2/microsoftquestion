namespace MicrosoftInterviewQuestion;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a sequence of characters: ");
        string sequence = Console.ReadLine()!;
        string compressedSequence = CompressSequence(sequence);
        string decompressedSequence = DecompressSequence(compressedSequence);

        Console.WriteLine(compressedSequence);
        Console.WriteLine(decompressedSequence);
        Console.ReadKey();
    }

    public static string CompressSequence(string sequence)
    {
        var compressed = sequence.Aggregate(" ", (seed, next) => seed + (seed.Last() == next ? "" : " ") + next).Trim().Split(" ");
        string compressedSequence = "";

        foreach (var str in compressed)
        {
            compressedSequence += str.Count().ToString() + str[0];
        }

        return compressedSequence;
    }

    public static string DecompressSequence(string compressedSequence)
    {
        List<string> decompressed = [];

        for(int i = 0; i < compressedSequence.Length; i += 2)
        {
            decompressed.Add(compressedSequence.Substring(i, 2));
        }

        string decompressedSequence = "";

        foreach(var str in decompressed)
        {
            for(int i = 0; i < int.Parse(str[0].ToString()); i++)
            {
                decompressedSequence += str[1].ToString();
            }
        }

        return decompressedSequence;
    }
}