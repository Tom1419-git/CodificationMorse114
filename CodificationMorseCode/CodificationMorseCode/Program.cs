/*
ETML
Thomas Mayoraz
Created: 27.08.2025
Last modified: 29.09.2025
Couteau Suisse - Morse, Conversions de bases et Stéganographie

Description: Programme "Couteau Suisse" offrant plusieurs utilitaires:
1. Conversion de texte en code Morse avec lecture audio et sauvegarde
2. Conversions de bases numériques (décimal, binaire, octal) avec calculs manuels
3. Stéganographie - Cacher et extraire des messages en Morse dans du texte
SANS UTILISATION DE FONCTIONS INTÉGRÉES
*/

namespace CodificationMorseCode
{
    internal class Program
    {
        // Dictionnaire de correspondance pour la conversion en code Morse
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

        // Dictionnaire inverse pour décoder le Morse
        private static Dictionary<string, char> ReverseMorseTable = new();

        // Caractères invisibles pour la stéganographie
        private const char POINT = '\u200B';           // ZERO WIDTH SPACE
        private const char TIRET = '\u200C';           // ZERO WIDTH NON-JOINER
        private const char SEPARATEUR_LETTRE = '\u200D'; // ZERO WIDTH JOINER
        private const char SEPARATEUR_MOT = '\u2060';    // WORD JOINER

        static void Main()
        {
            InitializeReverseMorseTable();
            ClearAndShowTitle();
            AfficherMenuPrincipal();
        }

        private static void InitializeReverseMorseTable()
        {
            foreach (var kvp in MorseTable)
            {
                if (!ReverseMorseTable.ContainsKey(kvp.Value))
                {
                    ReverseMorseTable.Add(kvp.Value, kvp.Key);
                }
            }
        }

        // ============= FONCTIONS UTILITAIRES DE BASE =============

        private static bool EstVide(string texte)
        {
            if (texte == null)
                return true;

            int longueur = 0;
            for (int i = 0; i < texte.Length; i++)
            {
                longueur++;
            }

            if (longueur == 0)
                return true;

            for (int i = 0; i < texte.Length; i++)
            {
                if (texte[i] != ' ' && texte[i] != '\t' && texte[i] != '\n' && texte[i] != '\r')
                    return false;
            }
            return true;
        }

        private static string EnleverEspacesDebut(string texte)
        {
            if (texte == null)
                return "";

            int debut = 0;
            for (int i = 0; i < texte.Length; i++)
            {
                if (texte[i] != ' ' && texte[i] != '\t' && texte[i] != '\n' && texte[i] != '\r')
                {
                    debut = i;
                    break;
                }
            }

            string resultat = "";
            for (int i = debut; i < texte.Length; i++)
            {
                resultat += texte[i];
            }
            return resultat;
        }

        private static string EnleverEspacesFin(string texte)
        {
            if (texte == null)
                return "";

            int fin = texte.Length - 1;
            for (int i = texte.Length - 1; i >= 0; i--)
            {
                if (texte[i] != ' ' && texte[i] != '\t' && texte[i] != '\n' && texte[i] != '\r')
                {
                    fin = i;
                    break;
                }
            }

            string resultat = "";
            for (int i = 0; i <= fin; i++)
            {
                resultat += texte[i];
            }
            return resultat;
        }

        private static string EnleverEspaces(string texte)
        {
            string temp = EnleverEspacesDebut(texte);
            return EnleverEspacesFin(temp);
        }

        private static string[] SeparerParCaractere(string texte, char separateur)
        {
            if (texte == null)
                return new string[0];

            // Compter le nombre de parties
            int compteur = 1;
            for (int i = 0; i < texte.Length; i++)
            {
                if (texte[i] == separateur)
                    compteur++;
            }

            string[] parties = new string[compteur];
            int indexPartie = 0;
            string partieActuelle = "";

            for (int i = 0; i < texte.Length; i++)
            {
                if (texte[i] == separateur)
                {
                    parties[indexPartie] = partieActuelle;
                    indexPartie++;
                    partieActuelle = "";
                }
                else
                {
                    partieActuelle += texte[i];
                }
            }

            parties[indexPartie] = partieActuelle;
            return parties;
        }

        private static string JoindreAvecSeparateur(string[] parties, string separateur)
        {
            if (parties == null || parties.Length == 0)
                return "";

            string resultat = "";
            for (int i = 0; i < parties.Length; i++)
            {
                resultat += parties[i];
                if (i < parties.Length - 1)
                    resultat += separateur;
            }
            return resultat;
        }

        private static string MettreEnMajuscules(string texte)
        {
            string resultat = "";
            for (int i = 0; i < texte.Length; i++)
            {
                char c = texte[i];
                if (c >= 'a' && c <= 'z')
                {
                    resultat += (char)(c - 32);
                }
                else
                {
                    resultat += c;
                }
            }
            return resultat;
        }

        // ============= MENU PRINCIPAL =============

        private static void AfficherMenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("=== Couteau Suisse – Utilitaires ===");
                Console.WriteLine("1. Convertir du texte en code Morse");
                Console.WriteLine("2. Convertir des nombres entre différentes bases (Décimal <> Binaire <> Octal)");
                Console.WriteLine("3. Stéganographie");
                Console.WriteLine("4. Quitter");
                Console.Write("Veuillez entrer votre choix : ");

                string choix = Console.ReadLine()!;
                ClearAndShowTitle();

                if (choix == "1")
                {
                    MenuMorse();
                }
                else if (choix == "2")
                {
                    MenuConversionBases();
                }
                else if (choix == "3")
                {
                    MenuSteganographie();
                }
                else if (choix == "4")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Choix invalide. Appuyez sur une touche pour continuer...");
                    Console.ReadKey();
                    ClearAndShowTitle();
                }
            }
        }

        // ============= STÉGANOGRAPHIE =============

        private static void MenuSteganographie()
        {
            Console.WriteLine("=== Stéganographie ===");
            Console.WriteLine("1. Encoder (Cacher un message)");
            Console.WriteLine("2. Décoder (Extraire un message caché)");
            Console.Write("Veuillez entrer votre choix : ");

            string choix = Console.ReadLine()!;
            ClearAndShowTitle();

            if (choix == "1")
            {
                EncoderMessage();
            }
            else if (choix == "2")
            {
                DecoderMessage();
            }
            else
            {
                Console.WriteLine("Choix invalide.");
            }

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
            Console.ReadKey();
            ClearAndShowTitle();
        }

        private static void EncoderMessage()
        {
            Console.Write("Texte porteur (ce que l'on verra) :\n");
            string textePorteur = Console.ReadLine()!;

            if (EstVide(textePorteur))
            {
                Console.WriteLine("Erreur : Le texte porteur ne peut pas être vide.");
                return;
            }

            Console.Write("Message secret à cacher (A-Z et espace) :\n");
            string messageSecret = MettreEnMajuscules(Console.ReadLine()!);

            if (!ValiderMessageSecret(messageSecret))
            {
                Console.WriteLine("Erreur : Le message secret doit contenir uniquement des lettres A-Z et des espaces.");
                return;
            }

            string morseCode = ConvertToMorse(messageSecret);
            string texteStegano = Encode(textePorteur, morseCode);

            if (texteStegano == null)
            {
                Console.WriteLine("Erreur : Le texte porteur est trop court pour cacher le message.");
                return;
            }

            try
            {
                File.WriteAllText("stegano.txt", texteStegano, System.Text.Encoding.UTF8);
                Console.WriteLine("\nLe texte avec stéganographie a été sauvegardé dans le fichier stegano.txt");
                Console.WriteLine("\nTexte visible (vous pouvez le copier) :");
                Console.WriteLine(texteStegano);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la sauvegarde : " + ex.Message);
            }
        }

        private static void DecoderMessage()
        {
            Console.WriteLine("Collez le texte stéganographié (ou appuyez sur Entrée pour lire depuis stegano.txt) :");
            string texteStegano = Console.ReadLine()!;

            if (EstVide(texteStegano))
            {
                if (File.Exists("stegano.txt"))
                {
                    texteStegano = File.ReadAllText("stegano.txt", System.Text.Encoding.UTF8);
                    Console.WriteLine("Lecture du fichier stegano.txt...");
                }
                else
                {
                    Console.WriteLine("Erreur : Aucun texte fourni et le fichier stegano.txt n'existe pas.");
                    return;
                }
            }

            string messageDecoded = Decode(texteStegano);

            if (messageDecoded == null)
            {
                Console.WriteLine("Erreur : Aucun message caché trouvé dans le texte. Vérifiez que le texte contient bien des marqueurs invisibles.");
            }
            else
            {
                Console.WriteLine("\nMessage secret décodé :");
                Console.WriteLine(messageDecoded);
            }
        }

        private static bool ValiderMessageSecret(string message)
        {
            if (EstVide(message))
                return false;

            for (int i = 0; i < message.Length; i++)
            {
                char c = message[i];
                bool estValide = (c >= 'A' && c <= 'Z') || c == ' ';
                if (!estValide)
                    return false;
            }
            return true;
        }

        private static string Encode(string coverText, string morseCode)
        {
            string result = "";
            int coverIndex = 0;

            for (int i = 0; i < morseCode.Length; i++)
            {
                char morseChar = morseCode[i];

                if (coverIndex >= coverText.Length)
                    return null;

                result += coverText[coverIndex];

                if (morseChar == '.')
                {
                    result += POINT;
                }
                else if (morseChar == '-')
                {
                    result += TIRET;
                }
                else if (morseChar == ' ')
                {
                    result += SEPARATEUR_LETTRE;
                }
                else if (morseChar == '/')
                {
                    result += SEPARATEUR_MOT;
                }

                coverIndex++;
            }

            for (int i = coverIndex; i < coverText.Length; i++)
            {
                result += coverText[i];
            }

            return result;
        }

        private static string Decode(string stegoText)
        {
            string morseExtracted = "";

            for (int i = 0; i < stegoText.Length; i++)
            {
                char c = stegoText[i];
                if (c == POINT)
                {
                    morseExtracted += '.';
                }
                else if (c == TIRET)
                {
                    morseExtracted += '-';
                }
                else if (c == SEPARATEUR_LETTRE)
                {
                    morseExtracted += ' ';
                }
                else if (c == SEPARATEUR_MOT)
                {
                    morseExtracted += '/';
                }
            }

            if (EstVide(morseExtracted))
                return null;

            return ConvertFromMorse(morseExtracted);
        }

        private static string ConvertFromMorse(string morse)
        {
            string result = "";
            string[] mots = SeparerParCaractere(morse, '/');

            for (int m = 0; m < mots.Length; m++)
            {
                string mot = EnleverEspaces(mots[m]);
                string[] lettres = SeparerParCaractere(mot, ' ');

                for (int l = 0; l < lettres.Length; l++)
                {
                    string lettre = lettres[l];
                    bool estVide = true;
                    for (int i = 0; i < lettre.Length; i++)
                    {
                        if (lettre[i] != ' ')
                        {
                            estVide = false;
                            break;
                        }
                    }

                    if (!estVide && ReverseMorseTable.ContainsKey(lettre))
                    {
                        result += ReverseMorseTable[lettre];
                    }
                }

                result += ' ';
            }

            return EnleverEspacesFin(result);
        }

        // ============= MENU MORSE =============

        private static void MenuMorse()
        {
            Console.Write("Entrez un mot ou une phrase (A-Z,0-9 sans accents) : ");
            string input = MettreEnMajuscules(Console.ReadLine()!);

            string result = ConvertToMorse(input);

            Console.WriteLine("\nRésultat en Morse :");
            Console.WriteLine(result);

            SaveMorseToFile(result, "morse_output.txt");
            Console.WriteLine("\nRésultat sauvegardé dans 'morse_output.txt'");

            PlayMorseSound(result);

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
            Console.ReadKey();
            ClearAndShowTitle();
        }

        // ============= MENU CONVERSION BASES =============

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

            if (choix == "1")
            {
                ConvertDecimalToBinary();
            }
            else if (choix == "2")
            {
                ConvertBinaryToDecimal();
            }
            else if (choix == "3")
            {
                ConvertBinaryToOctal();
            }
            else if (choix == "4")
            {
                ConvertOctalToBinary();
            }
            else if (choix == "5")
            {
                ConvertDecimalToOctal();
            }
            else if (choix == "6")
            {
                ConvertOctalToDecimal();
            }
            else
            {
                Console.WriteLine("Choix invalide.");
            }

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
            Console.ReadKey();
            ClearAndShowTitle();
        }

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

        private static void ConvertBinaryToOctal()
        {
            Console.Write("Entrez un nombre binaire : ");
            string binaire = Console.ReadLine()!;

            if (IsValidBinary(binaire))
            {
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

        private static void ConvertOctalToBinary()
        {
            Console.Write("Entrez un nombre octal : ");
            string octal = Console.ReadLine()!;

            if (IsValidOctal(octal))
            {
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

        private static bool IsValidBinary(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c != '0' && c != '1')
                    return false;
            }

            bool estVide = true;
            for (int i = 0; i < input.Length; i++)
            {
                estVide = false;
                break;
            }
            return !estVide;
        }

        private static bool IsValidOctal(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c < '0' || c > '7')
                    return false;
            }

            bool estVide = true;
            for (int i = 0; i < input.Length; i++)
            {
                estVide = false;
                break;
            }
            return !estVide;
        }

        // ============= FONCTIONS MORSE =============

        private static string ConvertToMorse(string input)
        {
            string[] morseResultArray = new string[input.Length];
            int compteur = 0;
            int i = 1;

            for (int j = 0; j < input.Length; j++)
            {
                char c = input[j];
                if (MorseTable.ContainsKey(c))
                {
                    morseResultArray[compteur] = MorseTable[c];
                    compteur++;
                }
                else
                {
                    Console.Write("|Caractère erroné à la position " + i + "|");
                }
                i++;
            }

            string[] morseResultFinal = new string[compteur];
            for (int j = 0; j < compteur; j++)
            {
                morseResultFinal[j] = morseResultArray[j];
            }

            return JoindreAvecSeparateur(morseResultFinal, " ");
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
            for (int i = 0; i < morse.Length; i++)
            {
                char c = morse[i];
                if (c == '.')
                {
                    Console.Beep(800, 100);
                }
                else if (c == '-')
                {
                    Console.Beep(800, 200);
                }
                else if (c == ' ')
                {
                    Thread.Sleep(200);
                }
                else if (c == '/')
                {
                    Thread.Sleep(700);
                }
            }
        }

        // ============= INTERFACE =============

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