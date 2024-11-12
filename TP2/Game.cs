using System;

namespace TP2
{
  public class Game
  {
    #region Constants
    public const int HEART = 0;
    public const int DIAMOND = 1;
    public const int SPADE = 2;
    public const int CLUB = 3;

    public const int ACE = 0;
    public const int TWO = 1;
    public const int THREE = 2;
    public const int FOUR = 3;
    public const int FIVE = 4;
    public const int SIX = 5;
    public const int SEVEN = 6;
    public const int EIGHT = 7;
    public const int NINE = 8;
    public const int TEN = 9;
    public const int JACK = 10;
    public const int QUEEN = 11;
    public const int KING = 12;

    public const int NUM_SUITS = 4;
    public const int NUM_CARDS_PER_SUIT = 13;
    public const int NUM_CARDS = NUM_SUITS * NUM_CARDS_PER_SUIT;
    public const int NUM_CARDS_IN_HAND = 3;

    public const int FACES_SCORE = 10;
    public const int ACES_SCORE = 11;

    public const int MAX_SCORE = 31;
    public const int ALL_SAME_CARDS_VALUE_SCORE = 30;
    public const int ALL_FACES_SCORE = 30;
    public const int ONLY_FACES_SCORE = 28;
    public const int SAME_COLOR_SEQUENCE_SCORE = 28;
    public const int SEQUENCE_SCORE = 26;
    public const int SAME_COLOR_SCORE = 24;
    #endregion

    public static int GetSuitFromCardIndex(int index)
    {

      int cardFace = index / NUM_CARDS_PER_SUIT;
      return cardFace;
    }
    public static int GetValueFromCardIndex(int index)
    {
      int cardValue = index % NUM_CARDS_PER_SUIT;

      return cardValue;
    }

    public static void DrawFaces(int[] cardValues, bool[] selectedCards, bool[] availableCards)
    {
      for (int i = 0; i < cardValues.Length; i++)
      {
        do
        {
          if (availableCards[i] == true)
          {
            Random random = new Random();
            cardValues[i] = random.Next(ACE, NUM_CARDS);
            availableCards[i] = false;
          }
          if (selectedCards[i] == false)
          {
            availableCards[i] = true;
          }
        } while (!availableCards[i]);
      }
    }
    public static int GetScoreFromCardValue(int cardValue)
    {
      if (cardValue >= TWO && cardValue <= TEN)
      {
        return cardValue + 1;
      }
      if (cardValue >= JACK && cardValue <= KING)
      {
        return FACES_SCORE;
      }
      else
      {
        return ACES_SCORE;
      }
    }

    public static int GetHandScore(int[] cardIndexes)
    {
      // PROF : À COMPLETER. Le code ci-après est incorrect
      return 0;
    }
    public static int GetHighestCardValue(int[] values)
    {
      int highest = 0;
      for (int i = 0; i < values.Length - 1; i++)
      {
        if (values[i] == ACE)
        {
          return values[i];
        }
        else if (values[i] <= values[i + 1])
        {
          highest = values[i + 1];
        }
      }
      return highest;
    }
    public static bool HasOnlySameColorCards(int[] cardIndex)
    {
      bool hasAllSameColor = true;
      int referencedCard = cardIndex[0];

      for (int i = 1; i < cardIndex.Length; i++)
      {
        if (referencedCard == HEART || referencedCard == DIAMOND)
        {
          if (cardIndex[i] == SPADE || cardIndex[i] == CLUB)
          {
            hasAllSameColor = false;
          }
        }
        if (referencedCard == SPADE || referencedCard == CLUB)
        {
          if (cardIndex[i] == HEART || cardIndex[i] == DIAMOND)
          {
            hasAllSameColor = false;
          }
        }
        if (cardIndex[i] > CLUB)
        {
          hasAllSameColor = false;
        }
      }
      return hasAllSameColor;
    }
    public static bool HasAllSameCardValues(int[] values)
    {
      bool hasAllSameCards = true;
      int referencedCard = values[0];
      for (int i = 1; i < values.Length; i++)
      {
       if (referencedCard !=  values[i])
        {
          hasAllSameCards = false;
        }
      }
      return hasAllSameCards;
    }
    public static bool HasAllFaces(int[] values)
    {
      
      bool hasAllFaces = true;
      for (int i = 1; i < values.Length; i++)
      {
        if (values[i] != JACK || values[i] != QUEEN || values[i] != KING && !HasSequence(values))
        {
          hasAllFaces = false;
        }
      }
      return !hasAllFaces;
    }
    public static bool HasSequence(int[] values)
    {
        bool isSorted = true;
      {
        do
        {
          isSorted = true;
          for (int i = 0; i < values.Length - 1; i++)
          {
            if (values[i] > values[i + 1])
            {
              isSorted = false;
              int valuesTemp = values[i];
              values[i] = values[i + 1];
              values[i + 1] = valuesTemp;
            }
          }
        } while (isSorted == false);

        for (int i = 1; i < values.Length; i++)
        {
          if (values[i] != values[i - 1] + 1)
          {
            isSorted =false;
          }
        }
      }
      return isSorted;
    }

    // A COMPLETER
    // ...
    // Il manque toutes les méthodes pour trouver les différentes combinaisons.
    // Référez-vous aux tests pour les noms de fonctions appropriés.
    // ATTENTION! Suivez bien les noms dans les tests, car je vais utiliser mon propre fichier
    // (qui est exactement comme le vôtre, mais vous ne pourrez pas me faire parvenir un fichier
    // de tests avec vos noms de fonctions).





    public static void ShowScore(int[] cardIndexes)
    {
      int hand = GetHandScore(cardIndexes);
      Display.WriteString($"Votre score est de : {hand}", 0, Display.CARD_HEIGHT + 14, ConsoleColor.Black);
    }

  }
}
