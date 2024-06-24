using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region TABLE OF WAO
            Console.WriteLine("============  T A B L E  O F  W A O !  ============\n");
            int[,] letters = new int[26, 26];
            List<int> characters = new List<int>();

            for (int i = 0; i < 26; i++)
                characters.Add(i + 65);
            #endregion

            #region INPUT & DISPLAY

            string Choice = "";
            while (true)
            {
                for (int x = 0; x < letters.GetLength(0); x++)
                {
                    for (int y = 0; y < letters.GetLength(0); y++)
                    {
                        letters[x, y] = characters[y];
                        Console.Write($"{(char)letters[x, y]} ");
                    }
                    characters.Add(x + 65);
                    characters.RemoveAt(0);
                    Console.WriteLine();
                }
                Console.Write("\n[1] ENCRYPTION\n[2] DECRYPTION\n\nCHOICE: ");
                Choice = Console.ReadLine();
                Console.WriteLine("\n===================================================\n");
                if (!(Choice == "1" || Choice == "2"))
                {
                    Console.WriteLine("Please input either 1 or 2 only");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                    break;
            }
            #endregion

            #region READER
            string keyIP = "";
            string mainMessage = ""; ; bool ananab2 = false; bool ananab = false;
            //string line = "";

            if (File.Exists("BANANA KEY.txt"))
            {
                using (StreamReader banana1 = new StreamReader("BANANA KEY.txt"))
                {
                    keyIP = banana1.ReadLine().ToUpper();
                    if (keyIP == null)
                        ananab2 = true;
                }
                //keyIP = line.ToUpper();
            }
            

            while (ananab2 || (!File.Exists("BANANA KEY.txt")))
            {
                Console.Write("INPUT KEY:\t");
                keyIP = Console.ReadLine().ToUpper();

                if (keyIP.Length != 0)
                    break;

                Console.WriteLine("Please enter a valid key");
                Console.ReadLine(); Console.Clear();
            }

            if (File.Exists("BANANA SPAWNER.txt"))
            {
                using (StreamReader banana2 = new StreamReader("BANANA SPAWNER.txt"))
                {
                    mainMessage = banana2.ReadLine();
                    if (mainMessage == null)
                        ananab = true;
                }
            }

            while (ananab || !File.Exists("BANANA SPAWNER.txt") || Choice == "1")
            {
                Console.Write("INPUT MESSAGE:\t");
                mainMessage = Console.ReadLine().ToUpper();

                if (mainMessage.Length != 0)
                    break;

                Console.WriteLine("Please enter a valid message");
                Console.ReadLine(); Console.Clear();
            }


            #endregion

            #region KEY LOGIC

            string hold = "";

            for (int i = 0; i < mainMessage.Length; i++)
            {
                if (mainMessage[i] >= 65 && mainMessage[i] <= 90)
                {
                    hold += mainMessage[i];
                }
            }
            mainMessage = hold;
            hold = "";

            for (int i = 0; i < keyIP.Length; i++)
            {
                if (keyIP[i] >= 65 && keyIP[i] <= 90)
                {
                    hold += keyIP[i];
                }
            }
            keyIP = hold;

            Console.Write($"\n===================================================\n\nMESSAGE:\t{mainMessage}");

            int counter = 0;
            hold = "";

            for (int i = 0; i < mainMessage.Length; i++)
            {
                if (counter >= keyIP.Length)
                    counter = 0;
                hold += keyIP[counter];
                counter++;
            }
            keyIP = hold;
            Console.Write($"\nKEY NOW:\t{keyIP}");
            #endregion

            #region LOGIC             

            int[] collectedMessage = new int[mainMessage.Length];

            for (int i = 0; i < mainMessage.Length; i++)
            {
                if (Choice == "1")
                    collectedMessage[i] = letters[mainMessage[i] - 65, keyIP[i] - 65];
                else if (Choice == "2")
                {
                    collectedMessage[i] = (mainMessage[i] - 65) - (keyIP[i] - 65);
                    if (collectedMessage[i] < 0)
                        collectedMessage[i] += 26;
                    collectedMessage[i] = (char)(collectedMessage[i] + 65);
                }
            }

            if (Choice == "1")
                Console.Write("\nENCRYPTED:\t");
            else if (Choice == "2")
                Console.Write("\nDECRYPTED:\t");

            for (int i = 0; i < collectedMessage.Count(); i++)
            {
                Console.Write($"{(char)collectedMessage[i]}");
            }

            using (StreamWriter banana = new StreamWriter("BANANA SPAWNER.txt"))
            {
                for (int i = 0; i < collectedMessage.Count(); i++)
                {
                    banana.Write($"{(char)collectedMessage[i]}");
                }
            }

            #endregion

            Console.ReadKey();
        }
    }
}
