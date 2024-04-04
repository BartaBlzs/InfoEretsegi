//73p

using System;
using System.IO;
using System.Collections.Generic;

namespace gyak
{
	class Program
	{
		static string[] f;
		static Fracs fracs;

        static void Main(string[] args)
		{
			feladat5();
			feladat6();
            
        }
		static void feladat5() 
		{
            f = File.ReadAllLines("szoveg.txt");
            Console.WriteLine("5. feladat:");
            Console.WriteLine(f[0]+"\n");
        }
        static void feladat6()
        {
			fracs = new Fracs("kodlemez.txt", f[0]);
        }
    }

	class Fracs 
	{
		static char[,] Kodlemez;
		static char[,] Titkositott;
        readonly string Titkositando;
        public Fracs(string path, string titk)
		{
            Kodlemez = new char[8, 8];
            Titkositott = new char[8, 8];
			string[] file = File.ReadAllLines(path);
            Titkositando = Atalakit(titk);

			for (int i = 0; i < file.Length; i++)
			{
                for (int j = 0; j < file[i].Length; j++)
                {
					Kodlemez[i, j] = file[i][j];
                }
            }
			KiirKodlemez();
            feladat8(Titkositando);
            Titikosit(Titkositando);

        }

        static void Titikosit(string titk)
        {
            int index = 0;
            for (int z = 0; z <= 4; z++)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (Kodlemez[j, i] == 'A' && index < 64)
                        {
                            Titkositott[j, i] = titk[index++];
                        }
                    }
                }
                Kodlemez = ForgatKodlemez(Kodlemez);
            }

            Console.WriteLine("10. feladat:");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(Titkositott[i, j]);
                }
                Console.WriteLine();
            }
        }

        static char[,] ForgatKodlemez(char[,] kod)
        {
            var ujKodlemez = new char[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ujKodlemez[7-j, i] = kod[i, j];
                }
            }
            return ujKodlemez;
        }

        static void feladat8(string t) 
		{
            Console.WriteLine("8. feladat:");
            Console.WriteLine(t);
            Console.WriteLine();
        }


        static void KiirKodlemez()
		{
            Console.WriteLine("7. feladat:");
            for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
                    Console.Write(Kodlemez[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static string Atalakit(string titk)
		{
			string s = titk.Replace(".", "").Replace(",", "").Replace(" ", "");
            if (s.Length > 64) throw new Exception("Túl hosszú a titkosítandó szöveg!");
			else 
			{
                for (int i = 0; i <= (64 - s.Length); i++)
				{
                    s += "X";
				}
                s += "X";
                return s;
			}
        }
	}
}