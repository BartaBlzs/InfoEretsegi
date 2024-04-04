// 27p
class Program
{
    static List<Keres> keresek = new();
	static void Main()
	{
		Read();
		feladat5();
		feladat6();
		feladat8();
		feladat9();
	}

	private static void feladat9()
	{
        Console.WriteLine($"9. feladat: Statisztika:");
        var s = new HashSet<string>();
		foreach (var x in keresek)
		{
			s.Add(x.statusCode);
		}
		foreach (var set in s)
		{

            Console.WriteLine($"\t{set}: {keresek.Select(x => x.statusCode).Count(x => x == set)} db");
        }
	}

	private static void feladat8()
	{
        Console.WriteLine($"8. feladat: Domain-es keresek: {Math.Round(((double)keresek.Select(x => x.Domain).Count(x => x == true) / keresek.Count) * 100, 2)}%");
    }

	private static void feladat6()
	{
        Console.WriteLine($"6. feladat: Valaszok osszes merete: {keresek.Sum(x => x.sizeInt)} byte");
    }

	private static void feladat5()
	{
        Console.WriteLine($"5. feladat: Keresek szama: {keresek.Count}");
    }

	private static void Read()
	{
		var f = File.ReadAllLines("NASAlog.txt");
		foreach (var line in f)
		{
			keresek.Add(new Keres(line));
		}
	}
}

class Keres
{
    public string ipAddress { get; set; }
	public string time { get; set; }
	public string file { get; set; }
	public string statusCode { get; set; }
	public string size { get; set; }
	public int sizeInt { get; set; }
	public bool Domain { get; set; }

	public Keres(string line)
	{
		var spl = line.Split("*");
		ipAddress = spl[0];
		time = spl[1];
		file = spl[2];
		statusCode = spl[3].Split(" ")[0];
		size = spl[3].Split(" ")[1];
		sizeInt = size != "-" ? int.Parse(this.size) : 0;
		Domain = !int.TryParse(ipAddress[^1].ToString(), out _);
    }
}