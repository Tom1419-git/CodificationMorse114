/*
ETML
Thomas Mayoraz
Created: 27.08.2025
Last modified: 08.09.2025
Couteau Suisse - Morse et Conversions de bases


Description: Programme "Couteau Suisse" offrant plusieurs utilitaires:
1.Conversion de texte en code Morse avec lecture audio et sauvegarde
2.Conversions de bases numériques(décimal, binaire, octal) avec calculs manuels
*/

namespace CodificationMorseCode
{
    internal class Program
    {
        // Dictionnaire de correspondance pour la conversion en code Morse
        // Inclut les lettres A-Z, chiffres 0-9 et l'espace
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
            ClearAndShowTitle();
            AfficherMenuPrincipal();
        }

        private static void AfficherMenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("=== Couteau Suisse – Utilitaires ===");
                Console.WriteLine("1. Convertir du texte en code Morse");
                Console.WriteLine("2. Convertir des nombres entre différentes bases (Décimal <> Binaire <> Octal)");
                Console.WriteLine("3. Quitter");
                Console.Write("Veuillez entrer votre choix : ");

                string choix = Console.ReadLine()!;
                ClearAndShowTitle();

                switch (choix)
                {
                    case "1":
                        MenuMorse();
                        break;
                    case "2":
                        MenuConversionBases();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Appuyez sur une touche pour continuer...");
                        Console.ReadKey();
                        ClearAndShowTitle();
                        break;
                }

            }
        }

        private static void MenuMorse()
        {
            Console.Write("Entrez un mot ou une phrase (A-Z,0-9 sans accents) : ");
            string input = Console.ReadLine()!.ToUpper();

            string result = ConvertToMorse(input);

            Console.WriteLine("\nRésultat en Morse :");
            Console.WriteLine(result);

            // Sauvegarde dans un fichier texte
            SaveMorseToFile(result, "morse_output.txt");
            Console.WriteLine("\nRésultat sauvegardé dans 'morse_output.txt'");

            // jouer les sons associés
            PlayMorseSound(result);

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
            Console.ReadKey();
            ClearAndShowTitle();
        }

        private static void MenuConversionBases()
        {
            Console.WriteLine("=== Convertisseur de bases ===");
            Console.WriteLine("1. Décimal > Binaire");
            Console.WriteLine("2. Binaire > Décimal");
            Console.WriteLine("3. Binaire > Octal");
            Console.WriteLine("4. Octal > Binaire");
            Console.WriteLine("5. Décimal > Octal");
            Console.WriteLine("6. Octal > Décimal");
            Console.Write("Veuillez entrer votre choix : ");

            string choix = Console.ReadLine()!;

            switch (choix)
            {
                case "1":
                    ConvertDecimalToBinary();
                    break;
                case "2":
                    ConvertBinaryToDecimal();
                    break;
                case "3":
                    ConvertBinaryToOctal();
                    break;
                case "4":
                    ConvertOctalToBinary();
                    break;
                case "5":
                    ConvertDecimalToOctal();
                    break;
                case "6":
                    ConvertOctalToDecimal();
                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
            Console.ReadKey();
            ClearAndShowTitle();
        }

        // Conversion Décimal vers Binaire (divisions par 2)
        private static void ConvertDecimalToBinary()
        {
            Console.Write("Entrez un nombre décimal : ");
            if (int.TryParse(Console.ReadLine(), out int nombre) && nombre >= 0)
            {
                string binaire = "";
                int temp = nombre;

                if (temp == 0)
                {
                    binaire = "0";
                }
                else
                {
                    while (temp > 0)
                    {
                        binaire = (temp % 2) + binaire;
                        temp = temp / 2;
                    }
                }

                Console.WriteLine($"Résultat : {binaire}");
            }
            else
            {
                Console.WriteLine("Nombre invalide. Veuillez entrer un entier positif.");
            }
        }

        // Conversion Binaire vers Décimal (multiplications par puissances de 2)
        private static void ConvertBinaryToDecimal()
        {
            Console.Write("Entrez un nombre binaire : ");
            string binaire = Console.ReadLine()!;

            if (IsValidBinary(binaire))
            {
                int decimal_result = 0;
                int puissance = 0;

                for (int i = binaire.Length - 1; i >= 0; i--)
                {
                    if (binaire[i] == '1')
                    {
                        int valeur_puissance = 1;
                        for (int j = 0; j < puissance; j++)
                        {
                            valeur_puissance = valeur_puissance * 2;
                        }
                        decimal_result = decimal_result + valeur_puissance;
                    }
                    puissance++;
                }

                Console.WriteLine($"Résultat : {decimal_result}");
            }
            else
            {
                Console.WriteLine("Nombre binaire invalide. Utilisez uniquement 0 et 1.");
            }
        }

        // Conversion Décimal vers Octal (divisions par 8)
        private static void ConvertDecimalToOctal()
        {
            Console.Write("Entrez un nombre décimal : ");
            if (int.TryParse(Console.ReadLine(), out int nombre) && nombre >= 0)
            {
                string octal = "";
                int temp = nombre;

                if (temp == 0)
                {
                    octal = "0";
                }
                else
                {
                    while (temp > 0)
                    {
                        octal = (temp % 8) + octal;
                        temp = temp / 8;
                    }
                }

                Console.WriteLine($"Résultat : {octal}");
            }
            else
            {
                Console.WriteLine("Nombre invalide. Veuillez entrer un entier positif.");
            }
        }

        // Conversion Octal vers Décimal (multiplications par puissances de 8)
        private static void ConvertOctalToDecimal()
        {
            Console.Write("Entrez un nombre octal : ");
            string octal = Console.ReadLine()!;

            if (IsValidOctal(octal))
            {
                int decimal_result = 0;
                int puissance = 0;

                for (int i = octal.Length - 1; i >= 0; i--)
                {
                    int chiffre = int.Parse(octal[i].ToString());
                    int valeur_puissance = 1;

                    for (int j = 0; j < puissance; j++)
                    {
                        valeur_puissance = valeur_puissance * 8;
                    }

                    decimal_result = decimal_result + (chiffre * valeur_puissance);
                    puissance++;
                }

                Console.WriteLine($"Résultat : {decimal_result}");
            }
            else
            {
                Console.WriteLine("Nombre octal invalide. Utilisez uniquement les chiffres 0-7.");
            }
        }

        // Conversion Binaire vers Octal (via décimal)
        private static void ConvertBinaryToOctal()
        {
            Console.Write("Entrez un nombre binaire : ");
            string binaire = Console.ReadLine()!;

            if (IsValidBinary(binaire))
            {
                // Binaire vers décimal
                int decimal_temp = 0;
                int puissance = 0;

                for (int i = binaire.Length - 1; i >= 0; i--)
                {
                    if (binaire[i] == '1')
                    {
                        int valeur_puissance = 1;
                        for (int j = 0; j < puissance; j++)
                        {
                            valeur_puissance = valeur_puissance * 2;
                        }
                        decimal_temp = decimal_temp + valeur_puissance;
                    }
                    puissance++;
                }

                // Décimal vers octal
                string octal = "";
                if (decimal_temp == 0)
                {
                    octal = "0";
                }
                else
                {
                    while (decimal_temp > 0)
                    {
                        octal = (decimal_temp % 8) + octal;
                        decimal_temp = decimal_temp / 8;
                    }
                }

                Console.WriteLine($"Résultat : {octal}");
            }
            else
            {
                Console.WriteLine("Nombre binaire invalide. Utilisez uniquement 0 et 1.");
            }
        }

        // Conversion Octal vers Binaire (via décimal)
        private static void ConvertOctalToBinary()
        {
            Console.Write("Entrez un nombre octal : ");
            string octal = Console.ReadLine()!;

            if (IsValidOctal(octal))
            {
                // Octal vers décimal
                int decimal_temp = 0;
                int puissance = 0;

                for (int i = octal.Length - 1; i >= 0; i--)
                {
                    int chiffre = int.Parse(octal[i].ToString());
                    int valeur_puissance = 1;

                    for (int j = 0; j < puissance; j++)
                    {
                        valeur_puissance = valeur_puissance * 8;
                    }

                    decimal_temp = decimal_temp + (chiffre * valeur_puissance);
                    puissance++;
                }

                // Décimal vers binaire
                string binaire = "";
                if (decimal_temp == 0)
                {
                    binaire = "0";
                }
                else
                {
                    while (decimal_temp > 0)
                    {
                        binaire = (decimal_temp % 2) + binaire;
                        decimal_temp = decimal_temp / 2;
                    }
                }

                Console.WriteLine($"Résultat : {binaire}");
            }
            else
            {
                Console.WriteLine("Nombre octal invalide. Utilisez uniquement les chiffres 0-7.");
            }
        }

        // Validation des entrées
        private static bool IsValidBinary(string input)
        {
            foreach (char c in input)
            {
                if (c != '0' && c != '1')
                    return false;
            }
            return !string.IsNullOrEmpty(input);
        }

        private static bool IsValidOctal(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c > '7')
                    return false;
            }
            return !string.IsNullOrEmpty(input);
        }

        // Fonctions Morse 
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
                    // point → bip court
                    Console.Beep(800, 100);
                }
                else if (c == '-')
                {
                    // tiret → bip long
                    Console.Beep(800, 200);
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

        private static void ClearAndShowTitle()
        {
            Console.Clear();
            AfficherTitreASCII();
        }
    }
}
