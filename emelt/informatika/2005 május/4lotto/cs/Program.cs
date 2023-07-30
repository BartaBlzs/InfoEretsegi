//53 p

using System;
using System.IO;
using System.Collections.Generic;

namespace gyak
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Kérem az 52. heti lottó számokat: ");
			string inp = Console.ReadLine();
			List<int> list = new();
			foreach(string s in inp.Split(" ")) 
			{
				list.Add(int.Parse(s));
			}
			
			// sort
			for (int i = 0; i < list.Count; i++) 
			{
                for (int j = 0; j < list.Count; j++) 
				{
					if (list[i] < list[j]) (list[j], list[i]) = (list[i], list[j]);
                }
            }

			Console.Write("A rendezett számok: ");


            foreach (var s in list)
			{
                Console.Write(s+" ");
            }

            Console.WriteLine();

            Console.Write("Kérek egy egész számot 1 és 51 között: ");
            int egyotvenegy = int.Parse(Console.ReadLine());

			List<string> f = new(File.ReadAllLines("lottosz.dat"));
            Console.Write("A beírt hét lottószámai: " + f[egyotvenegy-1]);

			List<int> onetoninety = new();
			for (int i = 1; i <= 90; i++)
			{
				onetoninety.Add(i);
			}
			
			foreach(var line in f) 
			{
				foreach (var s in line.Split(" ")) 
				{
					onetoninety.Remove(int.Parse(s));
				}
			}
            Console.WriteLine();
            if (onetoninety.Count > 0) 
			{
                Console.WriteLine("Van olyan szám amit nem húztak ki egyszer sem.");
            }
            else
            {
                Console.WriteLine("Nincs olyan szám amit nem húztak ki egyszer sem.");
            }

            int odd = 0;

            foreach (var line in f)
            {
                foreach (var s in line.Split(" "))
                {
                    if (int.Parse(s) % 2 == 1) 
					{
                        odd += 1;
                    }
                }
            }

			Console.WriteLine("A kihúzott számok között " + odd + " db páratlan szám volt");
			
			f.Add(String.Join(" ", list.ConvertAll((x)=> x.ToString())));

			File.WriteAllLines("lotto52.ki", f);

			for (int i = 1; i <= 90; i++)
			{
				int sum = 0;
                foreach (var line in f)
                {
                    foreach (var s in line.Split(" "))
                    {
                        if (i.ToString() == s) sum += 1;
                    }
                }

				if (i%15 == 1) Console.WriteLine();
                Console.Write(sum + " ");
            }

			List<int> prim = new() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89 };

            Console.WriteLine("\nAz alábbi prímszámokat nem húzták ki egyszer sem az elmúlt évben:");
            foreach (var i in onetoninety) 
			{
				if (prim.Contains(i)) 
				{
                    Console.Write(i+" ");
                }
			}
        }
	}
}