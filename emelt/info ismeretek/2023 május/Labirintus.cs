
class Program
{
	static void Main()
	{
		LabSim l = new("Lab2.txt");
    }
}

class LabSim
{
	List<string> Adatsorok = new();
	char[,] Lab;
	char[,] originalLab;
	public bool KeresesKesz { get; set; }
	public int KijaratOszlopIndex { get; }
	public int KijaratSorIndex { get; }
	public bool NincsMegoldas { get; set; }
	public int OszlopokSzama { get; }
	public int SorokSzama { get; }
	public LabSim(string forras)
	{
		BeolvasAdatsorok(forras);
		OszlopokSzama = Adatsorok[0].Length;
		SorokSzama = Adatsorok.Count;
		for (int i = 0; i < Adatsorok.Count; i++)
		{
			if (Adatsorok[i][^1] == ' ')
			{
				KijaratOszlopIndex = Adatsorok[0].Length;
				KijaratSorIndex = i;
			}
		}
		Lab = new char[SorokSzama, OszlopokSzama];
		originalLab = new char[SorokSzama, OszlopokSzama];
		FeltoltLab();
		Utkereses();
	}

	private void BeolvasAdatsorok(string forras)
	{
		foreach (var line in File.ReadAllLines(forras))
		{
			Adatsorok.Add(line);
		}
	}

	private void FeltoltLab()
	{
		for (int i = 0; i < SorokSzama; i++)
		{
			for (int j = 0; j < OszlopokSzama; j++)
			{
				Lab[i, j] = Adatsorok[i][j];
				originalLab[i, j] = Adatsorok[i][j];
			}
		}
	}

	public void KiirLab(char[,] toWrite)
	{
		Console.Clear();
		for (int i = 0; i < SorokSzama; i++)
		{
			for (int j = 0; j < OszlopokSzama; j++)
			{
				Console.Write(toWrite[i, j]);
			}
            Console.WriteLine();
        }
	}
	public void Utkereses()
	{
		KeresesKesz = false;
		NincsMegoldas = false;
		int r = 1;
		int c = 0;
		while (!KeresesKesz && !NincsMegoldas)
		{
			Lab[r, c] = 'O';
			if (Lab[r, c + 1] == ' ') c++;
			else if (Lab[r + 1, c] == ' ') r++;
			else
			{
				Lab[r, c] = '-';
				if (Lab[r, c - 1] == 'O') c--;
				else r--;
			}
			KeresesKesz = r == KijaratSorIndex && c + 1 == KijaratOszlopIndex;
			if (KeresesKesz) Lab[r, c] = 'O';
			NincsMegoldas = r == 1 && c == 0;
			if(!KeresesKesz)
			{
				KiirLab(originalLab);
				KiirLab(Lab);
				Thread.Sleep(100);
				Console.Clear();
			}
			else
			{
				KiirLab(originalLab);
				KiirLab(Lab);
			}
		}
	}
}