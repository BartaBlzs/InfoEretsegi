// 40 p
using System.Text;

List<gep> gepek = new();
foreach (var line in File.ReadAllLines("utasszallitok.txt").Skip(1))
{
	gepek.Add(new gep(line));
}

//feladat 4
Console.WriteLine($"4. feladat: Adatsorok szama: {gepek.Count}");

//feladat 5
Console.WriteLine($"5. feladat: Boeing tipusok szama: {gepek.Count(x => x.tipus.StartsWith("Boeing"))}");

//feladat 6
Console.WriteLine($"6. feladat: A legtobb utast szallito repulogeptipus:\n{
	gepek.First(x => x.utasMax == gepek.Max(y => y.utasMax))
}");

//feladat 7
List<string> kategoriak = new() { "Alacsony sebességű", "Szuperszonikus", "Transzszonikus", "Szubszonikus" };
foreach(gep gep in gepek)
{
	if (kategoriak.Contains(gep.sebesKategoria)) kategoriak.Remove(gep.sebesKategoria);
}

if(kategoriak.Count == 0) Console.WriteLine("Minden sebességkategóriából van repülőgéptípus.");
else foreach (var k in kategoriak) Console.Write($"{k} ");

// feladat 8
StringBuilder sb = new();
sb.AppendLine(File.ReadAllLines("utasszallitok.txt")[0]);
foreach (var gep in gepek)
{
	sb.AppendLine($"{gep.tipus};{gep.ev};{gep.utasMax};{gep.szemelyzetMax};{gep.utazosebesseg};{Math.Round((double)gep.felszallotomeg/1000)};{Math.Round(gep.fesztáv*3.2808)}");
}
File.WriteAllText("utasszallitok_new.txt", sb.ToString());
class gep
{
    public string tipus { get; set; }
	public int ev { get; set; }
	public string utas { get; set; }
	public int utasMax { get; set; }
	public string szemelyzet { get; set; }
	public int szemelyzetMax { get; set; }
	public int utazosebesseg { get; set; }
	public int felszallotomeg { get; set; }
	public double fesztáv { get; set; }
    public string sebesKategoria { get; set; }
    public gep(string line)
	{
		var spl = line.Split(";");
		tipus = spl[0];
		ev = int.Parse(spl[1]);
		utas = spl[2];
		utasMax = int.Parse(utas.Split('-')[^1]);
		szemelyzet = spl[3];
		szemelyzetMax = int.Parse(szemelyzet.Split('-')[^1]);
		utazosebesseg = int.Parse(spl[4]);
		felszallotomeg = int.Parse(spl[5]);
		fesztáv = double.Parse(spl[6].Replace(",", "."));
		sebesKategoria = new Sebessegkategoria(utazosebesseg).Kategorianev;
	}
	public override string ToString()
	{
		return $"\tTipus: {tipus}\n\tElso felszallas: {ev}\n\tUtasok szama: {utas}\n\tSzemelyzet: {szemelyzet}\n\tUtazosebesseg: {utazosebesseg}\n";
	}
}

class Sebessegkategoria
{
	private int Utazosebesseg;
	public string Kategorianev
	{
		get
		{
			if (Utazosebesseg < 500) return "Alacsony sebességű";
			else if (Utazosebesseg < 1000) return "Szubszonikus";
			else if (Utazosebesseg < 1200) return "Transzszonikus";
			else return "Szuperszonikus";
		}
	}
	public Sebessegkategoria(int utazosebesseg)
	{
		Utazosebesseg = utazosebesseg;
	}
}
