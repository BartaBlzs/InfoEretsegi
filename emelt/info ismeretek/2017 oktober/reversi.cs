// 42 p

//feladat 4
Tabla tabla = new("allas.txt");

//feladat 5
Console.WriteLine("5. feladat: A betoltott tabla");
tabla.Megjelenit();

//feladat 6
Console.WriteLine("6. feladat: Osszegzes");
tabla.Megszamlal();

//feladat 8
Console.Write("8. feladat: [jatekos;sor;oszlop;iranySor;iranyOszlop] = ");
var spl = Console.ReadLine().Split(';');
Console.WriteLine(tabla.VanForditas(spl[0][0], int.Parse(spl[1]), int.Parse(spl[2]), int.Parse(spl[3]), int.Parse(spl[4])) ? "\tVan forditas!" : "\tNincs forditas!");

//feladat 9
Console.Write("9. feladat: [jatekos;sor;oszlop] = ");
spl = Console.ReadLine().Split(';');
Console.WriteLine(tabla.SzabalyosLepes(spl[0][0], int.Parse(spl[1]), int.Parse(spl[2])) ? "\tSzabalyos lepes!" : "\tNem szabalyos lepes!");

class Tabla
{
	char[,] t;
	public Tabla(string path)
	{
		var f = File.ReadAllLines(path);
		t = new char[8, 8];
		for (int i = 0; i < f.Length; i++)
		{
			for (int j = 0; j < f[i].Length; j++)
			{
				t[i, j] = f[i][j];
			}
		}
	}

	public bool SzabalyosLepes(char jatekos, int sor, int oszlop)
	{
		if (t[sor, oszlop] != '#') return false;
		for (int i = -1; i < 2; i++)
		{
			for (int j = -1; j < 2; j++)
			{
				if (VanForditas(jatekos, sor, oszlop, i, j)) return true; 
			}
		}
		return false;
	}

	public bool VanForditas(char jatekos, int sor, int oszlop, int iranySor, int iranyOszlop)
	{
		int aktSor = sor + iranySor;
		int aktOszlop = oszlop + iranyOszlop;
		char ellenfel = 'K';
		bool nincsEllenfel = true;
		if (jatekos == 'K') ellenfel = 'F';

		while (aktSor >= 0 && aktSor < 8 && aktOszlop >= 0 && aktOszlop < 8 && t[aktSor, aktOszlop] == ellenfel)
		{
			aktSor += iranySor;
			aktOszlop += iranyOszlop;
			nincsEllenfel = false;
		}

		if (nincsEllenfel || aktSor < 0 || aktSor > 7 || aktOszlop < 0 || aktOszlop > 7 || t[aktSor, aktOszlop] != jatekos) return false;

		return true;
	}

	public void Megszamlal()
	{
		var k = 0; var f = 0; var u = 0;
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				if (t[i, j] == 'K') k++;
				if (t[i, j] == 'F') f++;
				if (t[i, j] == '#') u++;
			}
		}
        Console.WriteLine($"\tKek korongok szama: {k}\n\tFeher korongok szama: {f}\n\tUres mezok szama: {u}\n\t");
    }

	public void Megjelenit()
	{
		for (int i = 0; i < 8; i++)
		{
            Console.Write("\t");
            for (int j = 0; j < 8; j++)
			{
				Console.Write(t[i, j]);
			}
			Console.WriteLine();
		}
	}
}