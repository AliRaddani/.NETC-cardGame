//created by Ali raddani on 2/18/2020
/* this class will serve to create the deck of cards 
 and to shuffle it before each round and to generate the card that is drawen by each player
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class CardDeck
    {
        Random rand = new Random();
        string[] SUITS = {
            "Clubs", "Diamonds", "Hearts", "Spades"
        };

        string[] RANKS = {
            "2", "3", "4", "5", "6", "7", "8", "9", "10",
            "Jack", "Queen", "King", "Ace","PenalityCard"
        };

        public CardDeck() { }

        // method to initialize a new  deck of cards 
        public string[] getDeckOfCards()
        { 
            string[] cardDeck = new string[56];
            for (int i = 0; i < cardDeck.Length; i++)
            {
                cardDeck[i] = RANKS[i % 14] + " of " + SUITS[i / 14];
                
            }
            return cardDeck;
        }

        //method to shuffle the deck of cards
        public void shuffleDeckOfCards(string[] cardDeck)
        {
            for (int i = 0; i < cardDeck.Length; i++)
            {
                int index = rand.Next(56);
                string temp = cardDeck[i];
                cardDeck[i] = cardDeck[index];
                cardDeck[index] = temp;
                }
            Console.WriteLine("Deck of Cards Got Shuffeled\n");
            
            Console.WriteLine(".......................................................................................................................");
        }
        //method to generate a random card from  the deck of cards
        public string drawRandomCard(string[] cardDeck)
        {
            int index = rand.Next(0,56);
            return cardDeck[index];
        }

    }
}
