/*
ETML
Thomas Mayoraz
Created: 27.08.2025
Last modified : 01.09.2025
*/

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

            // Sauvegarde dans un fichier texte
            SaveMorseToFile(result, "morse_output.txt");
            Console.WriteLine("\n Résultat sauvegardé dans 'morse_output.txt'");

            // jouer les sons associés
            PlayMorseSound(result);

            Console.WriteLine("\nAppuyez sur une touche pour recommencer...");
            Console.ReadKey();
            Console.Clear();
            Main();
        }

        private static string ConvertToMorse(string input)
        {
            List<string> morseResult = new();
            int i = 1;

            foreach (char c in input)
            {
                if (MorseTable.ContainsKey(c))
                    morseResult.Add(MorseTable[c]);
                else
                    Console.Write("|Caractère erroné à la position " + i, "|");

                i++;
            }

            return string.Join(" ", morseResult);
        }

        private static void SaveMorseToFile(string text, string filename)
        {
            try
            {
                File.WriteAllText(filename, text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'enregistrement du fichier : " + ex.Message);
            }
        }

        private static void PlayMorseSound(string morse)
        {
            foreach (char c in morse)
            {
                if (c == '.')
                {
                    // point → bip long
                    Console.Beep(800, 200);
                }
                else if (c == '-')
                {
                    // tiret → bip court
                    Console.Beep(800, 100);
                }
                else if (c == ' ')
                {
                    Thread.Sleep(200); // pause entre lettres
                }
                else if (c == '/')
                {
                    Thread.Sleep(700); // pause entre mots
                }
            }
        }

        private static void AfficherTitreASCII()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("\t\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║  ██████╗ ██████╗ ██╗   ██╗████████╗███████╗ █████╗ ██╗   ██╗    ███████╗██╗   ██╗██╗███████╗███████╗███████╗  ║");
            Console.WriteLine("\t\t║ ██╔════╝██╔═══██╗██║   ██║╚══██╔══╝██╔════╝██╔══██╗██║   ██║    ██╔════╝██║   ██║██║██╔════╝██╔════╝██╔════╝  ║");
            Console.WriteLine("\t\t║ ██║     ██║   ██║██║   ██║   ██║   █████╗  ███████║██║   ██║    ███████╗██║   ██║██║███████╗███████╗█████╗    ║");
            Console.WriteLine("\t\t║ ██║     ██║   ██║██║   ██║   ██║   ██╔══╝  ██╔══██║██║   ██║    ╚════██║██║   ██║██║╚════██║╚════██║██╔══╝    ║");
            Console.WriteLine("\t\t║ ╚██████╗╚██████╔╝╚██████╔╝   ██║   ███████╗██║  ██║╚██████╔╝    ███████║╚██████╔╝██║███████║███████║███████╗  ║");
            Console.WriteLine("\t\t║  ╚═════╝ ╚═════╝  ╚═════╝    ╚═╝   ╚══════╝╚═╝  ╚═╝ ╚═════╝     ╚══════╝ ╚═════╝ ╚═╝╚══════╝╚══════╝╚══════╝  ║");
            Console.WriteLine("\t\t║                                                                                                               ║");
            Console.WriteLine("\t\t║                                         CRÉÉ PAR : Thomas MAYORAZ (MIN2B)                                     ║");
            Console.WriteLine("\t\t║                                              PROJET : C114 - 2025                                             ║");
            Console.WriteLine("\t\t║                                                                                                               ║");
            Console.WriteLine("\t\t╚═══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
