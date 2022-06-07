using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test07Jun
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                1. Wylosuj liczbę n od 1 do 10. 
                2. Wylosuj n (z punktu 1.) liczb z zakresu 0-100 i wpisz je do tablicy
                3. Każdy element tablicy wpisz do osobnym wierszu do pliku tekstowego znajdującego się obok pliku .exe
                4. Wczytaj plik z punktu 3. i stwórz nową tablicę liczb i ją posortuj od najmniejszej do największej
                5. Posortowane elementy tablicy wpisz do kolejnych wierszy w drugim pliku tekstowym 
            */

            //losowa liczba 1 do 10 - ok

            //pkt. 1
            Random myRandom = new Random();
            int randomNumber = myRandom.Next(10, 101);

            Console.WriteLine($"Wylosowano {randomNumber} liczb");


            //wpisanie do zmiennej a tekstu z consoli + proba konwersji tekstu do zmiennej liczbowej
            //var a = Console.ReadLine();
            //if(!int.TryParse(a, out int b))
            //{
            //    Console.WriteLine("Tekst nie jest liczba");
            //    return;
            //}

            //pkt. 2
            int[] tablicaNliczb = new int[randomNumber];
            string[] tablicaNliczbAsText = new string[randomNumber];
            for (int i = 0; i < tablicaNliczb.Length; i++)
            {
                tablicaNliczb[i] = myRandom.Next(0, 101);
                Console.WriteLine(tablicaNliczb[i]);
                tablicaNliczbAsText[i] = tablicaNliczb[i].ToString();
            }

            //pkt.3
            string path = Path.Combine("D:", "jakis_folder");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.WriteAllLines(path + "\\test.txt", tablicaNliczbAsText);
            StreamWriter sw = new StreamWriter("text2.txt");
            foreach (int i in tablicaNliczb)
            {
                sw.WriteLine(i);
            }
            sw.Close();


            string[] tabFromFile = File.ReadAllLines("text.txt");

            Array.Sort(tabFromFile);
            File.WriteAllLines("sort.txt", tabFromFile);

            int[] tabFromFileInt = new int[tabFromFile.Length];
            for (int i = 0; i < tabFromFileInt.Length; i++)
            {
                tabFromFileInt[i] = Convert.ToInt32(tabFromFile[i]);
            }

            Array.Sort(tabFromFileInt);

            sw = new StreamWriter("sort2.txt");
            foreach (var el in tabFromFileInt)
            {
                sw.WriteLine(el);
            }
            sw.Close();


            File.WriteAllText("sort3.txt", String.Join(Environment.NewLine, tabFromFileInt));
            //Console.ReadLine();


            /* //pierwsza próba
            int[] page = new int[100];
            Random myRandom2 = new Random();
            for (int i = 0; i < page.Length; ++i)
                page[i] = myRandom2.Next(10);
            Console.WriteLine(myRandom2);
            Console.ReadLine();
            */


            //Console.WriteLine(String.Join(" " + System.Environment.NewLine, GetRandom()));
            //string saveText = String.Join(" " + System.Environment.NewLine, GetRandom());
            ////File.WriteAllText(@"C:\Users\Andrzej\source\repos\ArrayExcercise\bin\Debug\net6.0", saveText);
            //System.IO.File.WriteAllText("text.txt", saveText);

            //string[] sorted = File.ReadAllLines("text.txt");
            //Array.Sort(sorted);

            //for (int i = 0; i < sorted.Length; i++)
            //{
            //    Console.WriteLine(sorted[i]);
            //    System.IO.File.WriteAllLines("text2.txt", sorted); //wcześniej waliłem głową z WriteAllText

            //}


        }
        private static Random myRandom = new Random();
        public static List<int> GetRandom()
        {
            return Enumerable.Range(1, 15).OrderBy(_ => myRandom.Next()).ToList();
        }

    }

}