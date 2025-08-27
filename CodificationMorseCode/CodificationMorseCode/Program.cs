/*
 ETML
 Thomas Mayoraz
 Created: 27.08.2025
 Last modified : 27.08.2025
 */

namespace CodificationMorseCode
{
    internal class Program
    {
        // Table de correspondance lettre → Morse (uniquement A-Z selon CDC)
        private static Dictionary<char, string> tableMorse = new Dictionary<char, string>()
        {
            {'A', ".-"},   {'B', "-..."}, {'C', "-.-."},
            {'D', "-.."},  {'E', "."},    {'F', "..-."},
            {'G', "--."},  {'H', "...."}, {'I', ".."},
            {'J', ".---"}, {'K', "-.-"},  {'L', ".-.."},
            {'M', "--"},   {'N', "-."},   {'O', "---"},
            {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."},
            {'S', "..."},  {'T', "-"},    {'U', "..-"},
            {'V', "...-"}, {'W', ".--"},  {'X', "-..-"},
            {'Y', "-.--"}, {'Z', "--.."}
        };
        static void Main(string[] args)
        {
            AfficherTitreASCII();

        }
        /// <summary>
        /// Affiche le titre ASCII art du programme
        /// </summary>
        private static void AfficherTitreASCII()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
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