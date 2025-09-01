/*
ETML
Thomas Mayoraz
Created: 27.08.2025
Last modified : 01.09.2025
*/
using System;
using System.Collections.Generic;

namespace CodificationMorseCode
{
    internal class Program
    {
        private static Dictionary<char, string> MorseTable = new()
        {
            {'A', ".-"},   {'B', "-..."}, {'C', "-.-."},
            {'D', "-.."},  {'E', "."},    {'F', "..-."},
            {'G', "--."},  {'H', "...."}, {'I', ".."},
            {'J', ".---"}, {'K', "-.-"},  {'L', ".-.."},
            {'M', "--"},   {'N', "-."},   {'O', "---"},
            {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."},
            {'S', "..."},  {'T', "-"},    {'U', "..-"},
            {'V', "...-"}, {'W', ".--"},  {'X', "-..-"},
            {'Y', "-.--"}, {'Z', "--.."}, {' ', "/"},
            {'0', "-----"},{'1', ".----"},{'2', "..---"},
            {'3', "...--"},{'4', "....-"},{'5', "....."},
            {'6', "-...."},{'7', "--..."},{'8', "---.."},
            {'9', "----."}
        };

        static void Main()
        {
            AfficherTitreASCII();

            Console.Write("Entrez un mot ou une phrase (A-Z,0-9 sans accents) : ");
            string input = Console.ReadLine()!.ToUpper();

            string result = ConvertToMorse(input);

            Console.WriteLine("\nRésultat en Morse :");
            Console.WriteLine(result);

            Console.WriteLine("\nAppuyez sur une touche pour recommencer...");
            Console.ReadKey();
            Console.Clear();
            Main();
        }

        private static string ConvertToMorse(string input)
        {
            List<string> morseResult = new();
            int i =1;

            foreach (char c in input)
            {
                if (MorseTable.ContainsKey(c))
                    morseResult.Add(MorseTable[c]);
                else 
                    Console.Write("|Caractère erroné à la position " + i  , "|");
                    
                i++;
            }

            return string.Join(" ", morseResult);
        }

        private static void AfficherTitreASCII()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("\t\t\t╔══════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t║  ███╗   ███╗ ██████╗ ██████╗ ███████╗███████╗    ██████╗ ██████╗ ██████╗ ███████╗    ║");
            Console.WriteLine("\t\t\t║  ████╗ ████║██╔═══██╗██╔══██╗██╔════╝██╔════╝   ██╔════╝██╔═══██╗██╔══██╗██╔════╝    ║");
            Console.WriteLine("\t\t\t║  ██╔████╔██║██║   ██║██████╔╝███████╗█████╗     ██║     ██║   ██║██║  ██║█████╗      ║");
            Console.WriteLine("\t\t\t║  ██║╚██╔╝██║██║   ██║██╔══██╗╚════██║██╔══╝     ██║     ██║   ██║██║  ██║██╔══╝      ║");
            Console.WriteLine("\t\t\t║  ██║ ╚═╝ ██║╚██████╔╝██║  ██║███████║███████╗   ╚██████╗╚██████╔╝██████╔╝███████╗    ║");
            Console.WriteLine("\t\t\t║  ╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝╚══════╝    ╚═════╝ ╚═════╝ ╚═════╝ ╚══════╝    ║");
            Console.WriteLine("\t\t\t║                                                                                      ║");
            Console.WriteLine("\t\t\t║                            CRÉÉ PAR : Thomas MAYORAZ (MIN2B)                         ║");
            Console.WriteLine("\t\t\t║                                  PROJET : C114 - 2025                                ║");
            Console.WriteLine("\t\t\t║                                                                                      ║");
            Console.WriteLine("\t\t\t╚══════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
