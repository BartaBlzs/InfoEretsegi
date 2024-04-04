//2. feladat
Console.Write("2. feladat:\n\t Kerem a kulcsot [HOLD]:");
var key = Console.ReadLine();
key = key == "" ? "hold" : key.ToLower();
Console.Write("Kerem az uzenetet [szeretem a csokit]:");
var message  = Console.ReadLine();
message = message == "" ? "szeretem a csokit" : message.ToLower();
//4. feladat
ADFGVXrejtjel rejtjel = new("kodtabla.txt", message, key);
//6. feladat
Console.WriteLine($"6. feladat: s->{rejtjel.Betupar('s')} x->{rejtjel.Betupar('x')}");
//8. feladat
Console.WriteLine($"8. feladat: a{rejtjel.KodoltUzenet()}"); 

class ADFGVXrejtjel
{
	private char[,] Kodtabla;
	private string Uzenet;
	private string Kulcs;

	public string AtalakitottUzenet()
	{
		// 5. feladat

		var atalakitottUzenet = Uzenet.Replace(" ", "");
		while(atalakitottUzenet.Length % Kulcs.Length != 0) atalakitottUzenet += "x";
        Console.WriteLine($"5. feladat: Az atalakitott uzenet: {atalakitottUzenet}");
        return atalakitottUzenet;
	}

	public string Betupar(char k)
	{
		// 6. feladat
		string[] adfgvx = {"A","D","F","G","V","X"};
		for(int sorIndex = 0;  sorIndex <= 5; sorIndex++)
		{
			for (int oszolopIndex = 0; oszolopIndex <= 5; oszolopIndex++)
			{
				if (Kodtabla[sorIndex,oszolopIndex] == k) return adfgvx[sorIndex] + adfgvx[oszolopIndex];
			}
		}

		return "hiba";
	}

	public string Kodszoveg()
	{
		// 7. feladat
		string uz = AtalakitottUzenet();
		string u = "";
		foreach(char c in uz)
		{
			u += Betupar(c);
		}
		Console.WriteLine($"7. feladat: A kodszoveg: {u}");
        return u;
	}

	public string KodoltUzenet()
	{
		string kodszoveg = Kodszoveg();
		int sorokSzama = kodszoveg.Length / Kulcs.Length;
		int oszlopokSzama = Kulcs.Length;
		char[,] m = new char[sorokSzama, oszlopokSzama];
		int index = 0;
		for (int sor = 0; sor < sorokSzama; sor++)
		{
			for (int oszlop = 0; oszlop < oszlopokSzama; oszlop++)
			{
				m[sor, oszlop] = kodszoveg[index++];
			}
		}

		string kodoltUzenet = "";
		for (char ch = 'A'; ch <= 'Z'; ch++)
		{
			int oszlopIndex = Kulcs.IndexOf(ch);
			if (oszlopIndex != -1)
			{
				for (int sorIndex = 0; sorIndex < sorokSzama; sorIndex++)
				{
					kodoltUzenet += m[sorIndex, oszlopIndex];
				}
			}
		}
        Console.WriteLine(kodoltUzenet);
        return kodoltUzenet;
	}

	public ADFGVXrejtjel(string kodtablaFile, string uzenet, string kulcs)
	{
		Uzenet = uzenet;
		Kulcs = kulcs;

		Kodtabla = new char[6, 6];
		int sorIndex = 0;
		foreach (var sor in System.IO.File.ReadAllLines(kodtablaFile))
		{
			for (int oszlopIndex = 0; oszlopIndex < sor.Length; oszlopIndex++)
			{
				Kodtabla[sorIndex, oszlopIndex] = sor[oszlopIndex];
			}
			sorIndex++;
		}
	}
}