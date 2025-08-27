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