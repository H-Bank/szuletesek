using System;
using System.IO;

namespace Vasmegye
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2. feladat: Adatok beolvasása, tárolása");
            string[] sorok = File.ReadAllLines("vas.txt");

            Console.WriteLine("4. feladat: Ellenőrzés");
            int s = 0;
            Program x = new Program();
            bool helyes = false;
            for (int i=0; i< sorok.Length;i++)
            {
                x.CdvEll(ref helyes, sorok[i]);
                if (helyes)
                {
                    Console.WriteLine("\tHibás a " + sorok[i]+ " személyi azonosító!");
                    sorok[i] = " ";
                    s++;
                }
            }

            Console.Write("5. feladat: ");
            int os = sorok.Length - s;
            Console.WriteLine("Vas megyében a vizsgált évek alatt " + os+ " csecsemő született.");

            Console.Write("6. feladat: ");
            int c = 0;
            for (int i=0;i<sorok.Length;i++)
            {
                if (sorok[i]!=" ")
                {
                    string sz = sorok[i];
                    if (sz[0]=='1' || sz[0] == '3')
                    {
                        c++;
                    }
                }
            }
            Console.WriteLine("Fiúk száma: " + c);

            Console.Write("7. feladat: ");
            int max = 0, min = 9999;
            int[] ev = new int[sorok.Length];
            for (int i = 0; i < sorok.Length; i++)
            {
                if (sorok[i] != " ")
                {
                    string eve = sorok[i];
                    eve = eve.Remove(0, 2);
                    eve = eve.Remove(2, 9);
                    ev[i] = Convert.ToInt32(eve);
                    if (ev[i] == 97 || ev[i] == 98 || ev[i] == 99)
                    {
                        ev[i] = ev[i] + 1900;
                    }
                    else
                    {
                        ev[i] = ev[i] + 2000;
                    }
                    if (max < ev[i])
                    {
                        max = ev[i];
                    }
                    if (min > ev[i])
                    {
                        min = ev[i];
                    }
                }
            }
            Console.WriteLine("Vizsgált időszak: " + min + " - " + max);

            Console.Write("8. feladat: ");
            bool van = true;
            int j = 0;
            while (van && j<sorok.Length)
            {
                if (sorok[j]!=" ")
                {
                    string haha = sorok[j];
                    if (haha[3]=='0' && haha[5] == '2' && haha[6] == '2' && haha[7] == '4')
                    {
                        van = false;
                    }
                }

                j++;
            }
            if (!van)
            {
                Console.WriteLine("Szökőnapon született baba!");
            }
            else
            {
                Console.WriteLine("Szökőnapon nem született baba!");
            }

            Console.WriteLine("9. feladat: Statisztika");
            int stas = max - min + 1;
            int[,] sta = new int[stas,2];
            for (int i=0;i<stas;i++)
            {
                sta[i, 0] = min + i;
                sta[i, 1] = 0;
                if (sta[i,0]<2000)
                {
                    sta[i, 0] = sta[i, 0] - 1900;
                }
                else
                {
                    sta[i, 0] = sta[i, 0] - 2000;
                }
            }
            for (int i=0;i<sorok.Length;i++)
            {
                string sor = sorok[i];
                if (sor != " ")
                {
                    sor = sor.Remove(0, 2);
                    sor = sor.Remove(2, 9);
                    int pa = Convert.ToInt32(sor);
                    for (int d = 0; d < stas; d++)
                    {
                        if (pa == sta[d, 0])
                        {
                            sta[d, 1]++;
                        }
                    }
                }
            }
            int jup = min-1;
            for (int i=0;i<stas;i++)
            {
                jup = jup +1;
                Console.WriteLine("\t"+jup + " - " + sta[i, 1] + " fő");
            }


            Console.ReadLine();
        }
        public void CdvEll(ref bool helyes, string azon)
        {
            azon = azon.Remove(8, 1);
            azon = azon.Remove(1, 1);
            int[] szet = new int[10];
            int szam = 0;
            for (int i=0;i<10;i++)
            {
                szet[i] = Convert.ToInt32(azon[i]);
                szam = szam + szet[i] * (10 - i);
            }
            int ez = Convert.ToInt32(azon[10]);
            szam = szam % 11;
            switch (ez)
            {
                case 48:
                    ez = 0;
                    break;
                case 49:
                    ez = 1;
                    break;
                case 50:
                    ez = 2;
                    break;
                case 51:
                    ez = 3;
                    break;
                case 52:
                    ez = 4;
                    break;
                case 53:
                    ez = 5;
                    break;
                case 54:
                    ez = 6;
                    break;
                case 55:
                    ez = 7;
                    break;
                case 56:
                    ez = 8;
                    break;
                case 57:
                    ez = 9;
                    break;
            }
            if (ez == szam)
            {
                helyes = false;
            }
            else
            {
                helyes = true ;
            }
        }
    }
}

