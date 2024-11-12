using System;

namespace TP2
{
    class Program
    {
        // Largeur de la console
        const int CONSOLE_WIDTH = 5 * Display.CARD_WIDTH;
        // Nombre d'itérations où le joueur peut changer ses cartes (max 10 ici)
        const int NUM_DRAWS = 1000;

        static void Main(string[] args)
        {
            Display.Clear();
            Console.WindowWidth = CONSOLE_WIDTH;

            bool[] availableCards = new bool[Game.NUM_CARDS];
            for (int i = 0; i < availableCards.Length; i++)
                availableCards[i] = true;

            int[] cardIndexes = new int[Game.NUM_CARDS_IN_HAND];

            bool[] selectedCards = new bool[Game.NUM_CARDS_IN_HAND];
            for (int i = 0; i < selectedCards.Length; i++)
                selectedCards[i] = false;

            Game.DrawFaces(cardIndexes, selectedCards, availableCards);
            for (int i = 0; i < NUM_DRAWS; i++)
            {
                // Afficher les cartes
                Display.ShowCards(cardIndexes);
                // Afficher les consignes
                Display.ShowInstructions();
                Display.ShowRemainingDraws(NUM_DRAWS - i);
                // Afficher la meilleure main à date
                Game.ShowScore(cardIndexes);
                // Permettre au joueur de sélectionner les cartes à garder
                Display.SelectCards(selectedCards);
                // Relancer les cartes que le joueur ne veut pas garder.
                Game.DrawFaces(cardIndexes, selectedCards, availableCards);
            }

            Display.WriteString("La partie est terminée!", 0, Console.WindowHeight - 1, ConsoleColor.Black);
        }
    }
}
