using static System.Runtime.InteropServices.JavaScript.JSType;

List<BingoJatekos> players = new();
// feladat 3
var f = File.ReadAllLines("nevek.text");
foreach (var line in f)
{
    players.Add(new BingoJatekos(Path.GetFileNameWithoutExtension(line), File.ReadAllText(line)));
}

// feladat 4
Console.WriteLine($"4. Feladat: Jatekosok szama: {players.Count}\n");

// feladat 7
Console.WriteLine($"7. feladat: kihuzott szamok");
HashSet<int> randoms = new();
Random rnd = new();

var gameEnded = false;
var curnum = 0;

while (!gameEnded)
{
    var random = rnd.Next(1, 76);
    if(randoms.Add(random))
    {
        Console.Write($"{++curnum}.->{random} ");
        foreach (var player in players)
        {
            if (player.SorsoltSzamotJelol(random)) gameEnded = true;
        }
    }
}

class BingoJatekos
{
    public string Name { get; set; }
    public int[,] Matrix { get; set; }

    public BingoJatekos(string name, string matrix)
    {
        Name = name;
        var spl = matrix.Trim().Split('\n');
        Matrix = new int[spl.Length, spl.Length];

        for (int i = 0; i < spl.Length; i++)
        {
            var val = spl[i].Split(';');
            for(int j = 0; j < val.Length; j++)
            {
                if (val[j] == "X") Matrix[i, j] = -1;
                else Matrix[i, j] = int.Parse(val[j]);
            }
        }
    }

    public bool SorsoltSzamotJelol(int number)
    {
        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                if (Matrix[i, j] == number)
                {
                    Matrix[i, j] = 0;
                }
            }
        }

        if(BingoEll())
        {
            GameEnd();
            return true;
        }

        return false;
    }

    private void GameEnd()
    {
        Console.WriteLine("\n\n" + Name);
        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                if (Matrix[i, j] == -1) Console.Write("X\t");
                else Console.Write($"{Matrix[i, j]}\t");
            }
            Console.WriteLine();
        }
    }
    
    private bool BingoEll()
    {
        if(TestX()) return true;
        if(TestY()) return true;
        if(TestDiag()) return true;
        return false;
    }

    private bool TestX()
    {
        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            var s = true;
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                if (Matrix[i, j] != 0 && Matrix[i, j] != -1)
                {
                    s = false;
                }
            }
            if (s) return true;
        }

        return false;
    }

    private bool TestY()
    {
        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            var s = true;
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                if (Matrix[j, i] != 0 && Matrix[j, i] != -1)
                {
                    s = false;
                }
            }
            if (s) return true;
        }

        return false;
    }

    private bool TestDiag()
    {
        var s = true;
        for (int i = 0, j = 0; i < Matrix.GetLength(0); i++, j++)
        {
            if (Matrix[i, j] != 0 && Matrix[i, j] != -1) s = false;
        }

        if (s) return true;

        s = true;
        for (int i = 0, j = Matrix.GetLength(0) - 1; i < Matrix.GetLength(0); i++, j--)
        {
            if (Matrix[i, j] != 0 && Matrix[i, j] != -1) s = false;
        }

        if (s) return true;

        return false;
    }
}