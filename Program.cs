using System;
using System.Collections.Generic;

namespace BlackjackCS
{
    // class Card
    // {
    //     public string rank;
    //     public string suit;

    //     public int Value()
    //     {
    //         return 0;
    //     }
    // }
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("Welcome to Blackjack");

            Console.WriteLine("");

            Console.WriteLine("Let us play the game....");
        }
        static void Main(string[] args)
        {
            DisplayGreeting();

            var cards = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            var suits = new List<string>() { "Hearts", "Diamonds", "Spades", "Clubs" };

            var deck = new List<string>();

            for (var index = 0; index < suits.Count; index++)
            {
                for (var numbersIndex = 0; numbersIndex < cards.Count; numbersIndex++)
                {
                    var fullNumber = ($"{cards[numbersIndex]} of {suits[index]} ");
                    deck.Add(fullNumber);
                }
            }

            var numberOfCards = deck.Count;

            for (var rightIndex = numberOfCards - 1; rightIndex >= 1; rightIndex--)
            {
                var randomNumberGenerator = new Random();
                var leftIndex = randomNumberGenerator.Next(rightIndex);

                var leftCard = deck[leftIndex];

                var rightCard = deck[rightIndex];

                deck[rightIndex] = leftCard;

                deck[leftIndex] = rightCard;
            }

            var firstCard = deck[0];
            var secondCard = deck[1];
            // var thirdCard = deck[3];

            Console.WriteLine(firstCard);
            Console.WriteLine(secondCard);
            // Console.WriteLine(thirdCard);


        }
    }
}



