# Couteau Suisse - Utilitaires de Codification

## 📋 Description

Programme "Couteau Suisse" offrant plusieurs utilitaires de conversion et de cryptographie :
1. **Conversion Morse** - Conversion de texte en code Morse avec lecture audio et sauvegarde
2. **Conversions de bases** - Conversions entre décimal, binaire et octal avec calculs manuels
3. **Stéganographie** - Cacher et extraire des messages secrets dans du texte

**Particularité** : Toutes les fonctions sont implémentées **SANS UTILISATION DE FONCTIONS INTÉGRÉES** (pas de `.Trim()`, `.Split()`, `.ToUpper()`, etc.)

## 👤 Auteur

- **Nom** : Thomas MAYORAZ
- **Classe** : MIN2B
- **École** : ETML
- **Projet** : C114 - 2025
- **Création** : 27.08.2025
- **Dernière modification** : 29.09.2025

## 🚀 Fonctionnalités

### 1. Conversion Morse
- Conversion de texte (A-Z, 0-9) en code Morse
- Lecture audio du code Morse généré (bips sonores)
- Sauvegarde automatique dans `morse_output.txt`
- Support des lettres, chiffres et espaces

### 2. Conversions de bases numériques
Conversions bidirectionnelles entre :
- **Décimal ↔ Binaire**
- **Décimal ↔ Octal**
- **Binaire ↔ Octal**

Toutes les conversions sont effectuées avec des calculs manuels (sans fonctions intégrées).

### 3. Stéganographie
- **Encodage** : Cacher un message secret (en code Morse) dans un texte porteur visible
- **Décodage** : Extraire le message caché d'un texte stéganographié
- Utilisation de caractères Unicode invisibles (Zero Width Characters)
- Sauvegarde automatique dans `stegano.txt`

## 🛠️ Technologies utilisées

- **Langage** : C# (.NET)
- **Namespace** : `CodificationMorseCode`
- **Encodage** : UTF-8 pour la gestion des caractères invisibles

## 📦 Installation et exécution

### Prérequis
- .NET SDK installé sur votre machine

### Compilation et exécution
```bash
# Compiler le projet
dotnet build

# Exécuter le programme
dotnet run
```

Ou avec Visual Studio :
1. Ouvrir le fichier `.csproj` ou `.sln`
2. Appuyer sur `F5` pour exécuter

## 📖 Guide d'utilisation

### Menu principal
Au lancement, vous accédez au menu principal avec 4 options :
```
1. Convertir du texte en code Morse
2. Convertir des nombres entre différentes bases
3. Stéganographie
4. Quitter
```

### Utilisation de la conversion Morse
1. Sélectionner l'option `1`
2. Entrer un texte (lettres A-Z, chiffres 0-9, sans accents)
3. Le code Morse s'affiche et est lu audio
4. Le résultat est sauvegardé dans `morse_output.txt`

**Exemple** :
```
Entrée : HELLO
Sortie : .... . .-.. .-.. ---
```

### Utilisation des conversions de bases
1. Sélectionner l'option `2`
2. Choisir le type de conversion souhaité (1-6)
3. Entrer le nombre à convertir
4. Le résultat s'affiche immédiatement

**Exemples** :
- Décimal → Binaire : `42` → `101010`
- Binaire → Octal : `1010` → `12`
- Octal → Décimal : `17` → `15`

### Utilisation de la stéganographie

#### Encoder un message
1. Sélectionner l'option `3` puis `1`
2. Entrer le **texte porteur** (ce qui sera visible)
3. Entrer le **message secret** (A-Z et espaces uniquement)
4. Le texte stéganographié est sauvegardé dans `stegano.txt`

**Exemple** :
```
Texte porteur : "Ceci est un texte normal qui ne cache rien"
Message secret : "SOS"
Résultat : Texte visible identique mais contenant des caractères invisibles
```

#### Décoder un message
1. Sélectionner l'option `3` puis `2`
2. Coller le texte stéganographié (ou laisser vide pour lire `stegano.txt`)
3. Le message secret s'affiche

## 🔧 Détails techniques

### Table de code Morse
Le programme utilise un dictionnaire complet avec :
- Lettres A-Z
- Chiffres 0-9
- Espace → `/` (séparateur de mots)
- Espace entre lettres → ` ` (espace simple)

### Caractères invisibles pour la stéganographie
```csharp
POINT (.)              → \u200B (ZERO WIDTH SPACE)
TIRET (-)              → \u200C (ZERO WIDTH NON-JOINER)
SEPARATEUR_LETTRE ( )  → \u200D (ZERO WIDTH JOINER)
SEPARATEUR_MOT (/)     → \u2060 (WORD JOINER)
```

### Fonctions utilitaires personnalisées
Toutes implémentées manuellement sans fonctions intégrées :
- `EstVide()` - Vérification de chaîne vide
- `EnleverEspaces()` - Suppression des espaces (trim)
- `SeparerParCaractere()` - Découpage de chaîne (split)
- `JoindreAvecSeparateur()` - Jointure de tableaux (join)
- `MettreEnMajuscules()` - Conversion en majuscules (toUpper)

## 📁 Fichiers générés

- `morse_output.txt` - Résultat de la conversion Morse
- `stegano.txt` - Texte avec message stéganographié (encodage UTF-8)

## ⚠️ Limitations

- **Morse** : Uniquement lettres A-Z, chiffres 0-9 et espaces
- **Bases numériques** : Nombres entiers positifs uniquement
- **Stéganographie** : 
  - Message secret limité à A-Z et espaces
  - Le texte porteur doit être suffisamment long pour contenir le message

## 🎨 Interface

Le programme affiche un titre ASCII art stylisé au démarrage :
```
            ╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            ║  ██████╗ ██████╗ ██╗   ██╗████████╗███████╗ █████╗ ██╗   ██╗    ███████╗██╗   ██╗██╗███████╗███████╗███████╗  ║");
            ║ ██╔════╝██╔═══██╗██║   ██║╚══██╔══╝██╔════╝██╔══██╗██║   ██║    ██╔════╝██║   ██║██║██╔════╝██╔════╝██╔════╝  ║");
            ║ ██║     ██║   ██║██║   ██║   ██║   █████╗  ███████║██║   ██║    ███████╗██║   ██║██║███████╗███████╗█████╗    ║");
            ║ ██║     ██║   ██║██║   ██║   ██║   ██╔══╝  ██╔══██║██║   ██║    ╚════██║██║   ██║██║╚════██║╚════██║██╔══╝    ║");
            ║ ╚██████╗╚██████╔╝╚██████╔╝   ██║   ███████╗██║  ██║╚██████╔╝    ███████║╚██████╔╝██║███████║███████║███████╗  ║");
            ║  ╚═════╝ ╚═════╝  ╚═════╝    ╚═╝   ╚══════╝╚═╝  ╚═╝ ╚═════╝     ╚══════╝ ╚═════╝ ╚═╝╚══════╝╚══════╝╚══════╝  ║");
            ║                                                                                                               ║");
            ║                                         CRÉÉ PAR : Thomas MAYORAZ (MIN2B)                                     ║");
            ║                                              PROJET : C114 - 2025                                             ║");
            ║                                                                                                               ║");
            ╚═══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
```

## 📝 Notes de développement

Ce projet a été développé dans un cadre éducatif avec la contrainte de ne pas utiliser les fonctions intégrées du framework .NET pour les opérations sur les chaînes de caractères et les conversions, afin de comprendre les mécanismes sous-jacents.

## 📄 Licence

Projet éducatif - ETML 2025 - Thomas Mayoraz