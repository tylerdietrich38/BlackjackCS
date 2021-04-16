using System;
using System.Collections.Generic;

namespace BlackjackCS
{
    // class Set
    // {
    //     public string Card;
    //     public string Suit;

    //     public int Value()
    //     {
    //         if (Card == "Ace")
    //         {
    //             return 11;
    //         }
    //         if (Card == "King")
    //         {
    //             return 10;
    //         }
    //         if (Card == "Queen")
    //         {
    //             return 10;
    //         }
    //         if (Card == "Jack")
    //         {
    //             return 10;
    //         }
    //         if (Card == "10")
    //         {
    //             return 10;
    //         }
    //         if (Card == "9")
    //         {
    //             return 9;
    //         }
    //         if (Card == "8")
    //         {
    //             return 8;
    //         }
    //         if (Card == "7")
    //         {
    //             return 7;
    //         }
    //         if (Card == "6")
    //         {
    //             return 6;
    //         }
    //         if (Card == "5")
    //         {
    //             return 5;
    //         }
    //         if (Card == "4")
    //         {
    //             return 4;
    //         }
    //         if (Card == "3")
    //         {
    //             return 3;
    //         }
    //         if (Card == "2")
    //         {
    //             return 2;
    //         }
    //         else
    //         {
    //             return int.Parse(Value);
    //         }
    //     }
    // }
    class Program
    {
        static void PlayerHand()
        {
            var cards = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
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
            // var thirdCard = deck[2];

            Console.WriteLine(firstCard);
            Console.WriteLine("+");
            Console.WriteLine(secondCard);
            // Console.WriteLine(thirdCard);

            Console.WriteLine("Do you want to hit or stand? ");

            Console.WriteLine(" ");

            var answer = Console.ReadLine();

            var thirdCard = deck[4];

            var fourthCard = deck[5];

            if (answer == "hit" || answer == "Hit" || answer == "HIT")
            {
                Console.WriteLine($"{deck[4]}");
            }
            if (answer == "hit" || answer == "Hit" || answer == "HIT")
            {
                Console.WriteLine($"{deck[5]}");
                return;
            }
            // else (answer == "stand" || answer == "Stand" || answer = "STAND");
            // {
            //     Console.WriteLine("No more cards please!");
            //     return;
            // }


        }
        static void DealerHand()
        {
            var cards = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
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

            var firstCard = deck[2];
            var secondCard = deck[3];
            // var thirdCard = deck[2];

            Console.WriteLine(firstCard);
            Console.WriteLine("+");
            Console.WriteLine(secondCard);
            // Console.WriteLine(thirdCard);

            Console.WriteLine("Do you want to hit or stand? ");

            Console.WriteLine(" ");

            var answer = Console.ReadLine();

            var thirdCard = deck[6];

            if (answer == "hit" || answer == "Hit" || answer == "HIT")
            {
                Console.WriteLine($"{deck[4]}");
                return;
            }

        }

        static void DisplayGreeting()
        {
            Console.WriteLine("Welcome to Blackjack");

            Console.WriteLine("");

            Console.WriteLine("Let us play the game....");
        }

        static void Main(string[] args)
        {

            DisplayGreeting();

            Console.WriteLine(" ");

            Console.WriteLine("Player Hand-------");

            PlayerHand();

            Console.WriteLine(" ");

            Console.WriteLine("Dealer Hand-------");

            DealerHand();

            Console.WriteLine(" ");
        }
    }
}
