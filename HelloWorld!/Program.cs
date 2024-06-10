using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============  T A B L E  O F  W A O !  ============\n");

            int[,] letters = new int[26,26];
            List<int> characters = new List<int>();

            for (int i = 0; i < 26; i++)
            {
                characters.Add(i+65);
            }

            for (int x = 0; x < letters.GetLength(0); x++)
            {
                for (int y = 0; y < letters.GetLength(1); y++)
                {
                    letters[x, y] = characters[y];
                    Console.Write($"{(char)letters[x, y]} ");
                }
                characters.Add(x+65);
                characters.RemoveAt(0);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
