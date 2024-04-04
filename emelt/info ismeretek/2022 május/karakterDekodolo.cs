
class Program
{
    static List<Karakter> chars = new();
	static void Main()
	{
        Read();
        //feladat 1
        Console.WriteLine($"5. feladat: Karkterek szama: {chars.Count}");
        feladat6();
        feladat7();
        feladat8();
    }

    private static void feladat8()
    {
        var f = File.ReadAllLines("dekodol.txt");
        for (int i = 0; i < f.Length; i += 8)
        {
            bool t = true;
            foreach(var ch in chars)
            {
                if (ch.Felismer(new Karakter(f[i][0], f[(i + 1)..(i + 8)])))
                {
                    Console.Write(ch.chr);
                    t = false;
                }
            }
            if (t)
                Console.Write("?");
        }
        
    }

    static string input;
    private static void feladat7()
    {
        Console.WriteLine("7. feladat:");
        bool t = true;
        foreach (var c in chars)
        {
            if (c.chr == input[0])
            {
                c.Write();
                t = false;
            }
        }
        if (t) Console.WriteLine("Nincs ilyen karakter a bankban!");
    }

    private static void feladat6()
    {
        Console.Write("6. feladat: Kerek egy angol nagybetut:");
        input = Console.ReadLine();
        while (!"ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(input) || input.Length != 1)
        {
            Console.Write("6. feladat: Kerek egy angol nagybetut:");
            input = Console.ReadLine();
        }
    }

    static void Read()
	{
        var f = File.ReadAllLines("bank.txt");
        for (int i = 0; i < f.Length; i += 8)
        {
            chars.Add(new Karakter(f[i][0], f[(i + 1)..(i + 8)]));
        }
    }
}

class Karakter
{
	public char chr;
	public char[][] charMatrix;
	public Karakter(char chr, string[] lines)
	{
        this.chr = chr;
        charMatrix = new char[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            charMatrix[i] = new char[lines[i].Length];
            for (int j = 0; j < lines[i].Length; j++)
            {
                charMatrix[i][j] = lines[i][j];
            }
        }
    }
    public bool Felismer(Karakter felismerendo)
    {
        for (int i = 0; i < charMatrix.Length; i++)
        {
            for (int j = 0; j < charMatrix[i].Length; j++)
            {
                if (felismerendo.charMatrix[i][j].ToString() != charMatrix[i][j].ToString()) return false;
            }
        }
        return true;
    }

    public void Write()
    {
        foreach (char[] c in charMatrix)
        {
            foreach(char x in c)
            {
                if(x == '1') Console.Write("x");
                else Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}