using System;
using System.Collections.Generic;

namespace BlackjackCS
{
    class Hand
    {
        public List<Card> DealtCards {get; set; } = new List<Card>();

        public void Receive(Card newCard)
        {
            DealtCards.Add(newCard);
        }

        public bool Busted()
        {
            return TotalValue() > 21;
        }

        public int TotalValue()
        {
            var total = 0;

            foreach (var card in DealtCards)
            {
                total += card.Value();
            }

            return total;
        }
    }

    class Card
        {
            public string Rank {get; set; }
            public string Suit { get; set; }

            public int Value()
            {
            if (Rank == "Ace")
            {
                return 11;
            }
            if (Rank == "King")
            {
                return 10;
            }
            if (Rank == "Queen")
            {
                return 10;
            }
            if (Rank == "Jack")
            {
                return 10;
            }
            else
            {
                return int.Parse(Rank);
            }
            }

            public string Description()
            {
                var newDescriptionString = $"The {Rank} of {Suit} - you have {Value()} .";

                return newDescriptionString;
            }
        }
    class Game
    {
        public void Play()
        {
            var deck = new List<Card>();

            var ranks = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            var suits = new List<string>() { "Hearts", "Diamonds", "Spades", "Clubs" };

            // var deck = new List<string>();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    var card = new Card { Suit = suit, Rank = rank};
                    deck.Add(card);
                }
            }

            // for (var index = 0; index < suits.Count; index++)
            // {
            //     for (var numbersIndex = 0; numbersIndex < ranks.Count; numbersIndex++)
            //     {
            //         var card = ($"{ranks[numbersIndex]} of {suits[index]} ");
            //         deck.Add(card);
            //     }
            // }

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

            var playerHand = new Hand();

            var dealerHand =  new Hand();

            var newCard = deck[0];
            deck.Remove(newCard);

            playerHand.Receive(newCard);

            newCard = deck[0];
            deck.Remove(newCard);

            playerHand.Receive(newCard);

            newCard = deck[0];
            deck.Remove(newCard);

            dealerHand.Receive(newCard);

            var keepAsking = true;
            while (keepAsking && !playerHand.Busted())
            {
                Console.WriteLine("Your cards are:");
                foreach (var card in playerHand.DealtCards)
                {
                    Console.WriteLine(card.Description());
                }
                Console.Write("Your total hand value is: ");
                Console.WriteLine(playerHand.TotalValue());

                Console.Write("Do you want to [Hit] or [Stand]? ");
                var choice = Console.ReadLine().ToLower();

                if (choice == "hit")
                {
                    var hitCard = deck [0];
                    deck.Remove(hitCard);

                    playerHand.Receive(hitCard);
                }
                else
                {
                    keepAsking = false;
                }
            }

            Console.WriteLine("Your cards are:");
            foreach (var card in playerHand.DealtCards)
            {
                Console.WriteLine(card.Description());
            }
            Console.Write("Your total hand value is: ");
            Console.WriteLine(playerHand.TotalValue());

            while (dealerHand.TotalValue() < 17 && !playerHand.Busted())
            {
                var newDealerCard = deck[0];
                deck.Remove(newDealerCard);

                dealerHand.Receive(newDealerCard);
            }

            Console.WriteLine("The dealer's cards are: ");
            foreach (var card in dealerHand.DealtCards)
            {
                Console.WriteLine(card.Description());
            }
            Console.Write("The dealer's total hand value is: ");
            Console.WriteLine(dealerHand.TotalValue());

            if (playerHand.Busted())
            {
                Console.WriteLine("Dealer wins!");
            }
            else if (dealerHand.Busted())
            {
                Console.WriteLine("Player wins!");
            }
            else if (dealerHand.TotalValue() > playerHand.TotalValue())
            {
                Console.WriteLine("Dealer Wins");
            }
            else if (playerHand.TotalValue() > dealerHand.TotalValue())
            {
                Console.WriteLine("Player Wins!");
            }
            else
            {
                Console.WriteLine("Ties to the dealer");
            }
        }

    }
    class Program 
    {
        static void Main(string[] args)
        {
           var playerWantsToKeepGoing = true;

           while (playerWantsToKeepGoing)
           {
               var theGame = new Game();
               theGame.Play();

               Console.Write("Would you like to play again? [Yes] / [No] ");
               var answer = Console.ReadLine().ToLower();

               playerWantsToKeepGoing = (answer == "yes");
           }
        }
    }
    
}