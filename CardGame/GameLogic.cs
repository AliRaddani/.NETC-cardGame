//created by ali raddani on 2/18/2020
/* this class will serve to make the game logic.
 it will create the game header. then prompt the user for the number of players.
 then 
 it will take the deck of cards array to start playing the game 
 and generate the value for each card.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class GameLogic

    {
        string endOfGame = "";
        int value = 0;
        string[] cardDeck = new string[56];
        int num;

        public GameLogic()
        {

        }
        
        // method to create and display the header for the game
        public void gameHeader()
        {
                  Console.WriteLine("************************************************************************************************************************\t\t\t\t\t");
                  Console.WriteLine("                                        *       Card Game                   *\n\t\t\t\t\t* \tBy: Ali Raddani \t    *");
                  Console.WriteLine("\t\t\t\t\t*\t\t\t\t    *");
                  Console.WriteLine("************************************************************************************************************************\n");
                  Console.Write("\t\t\t\t\t Instructions:  Each player will draw a card from a shuffeled deck of cards.\n "
                        + "                                        "
                        + "The player  with the highest ranked card wins the round and gets 2 points,\n"
                        + "                                         "
                        + "The player who draws a penality card should have their score reduced by 1 point\n"
                        + "                         "
                        + "                If a player reaches the score of 21 and leads  by 2 point Wins the Game..\n\n"
                        + "" +
                        "              ");
        }
       
        //method to prompt the user for the number pf players
        public void getNumberOfPlayers(int num, List<Player> myList)
        {
            do
            {

                Console.Write("\t\t\t\t Please choose The number of players. It must be between 2 and 4: ");
                num = Convert.ToInt32(Console.ReadLine());

            } while (num < 2 || num > 4);

            for (int i = 0; i < num; i++)
            {
                Console.Write("\t\t\t\t\t" +
                    "" +
                    "" +
                    "Please enter the name of e" +
                    "ach player and click enter: ");
                string playerName = Console.ReadLine();
                Player player = new Player(playerName);
                myList.Add(player);
                Console.WriteLine("");
            }
                Console.WriteLine("........................................................................................................................");
                Console.WriteLine("                                           " +
                "Are you ready The game has started:  ");
                Console.WriteLine("........................................................................................................................\n");

        }
        
        //method for playing the game
        public void playGame(List<Player> myList, CardDeck cd)
        {
                gameHeader();
           

            getNumberOfPlayers(num, myList);

            do {
               
                foreach (Player p in myList)
                    {
                    
                    Console.Write("Please  " + p.getName() + "  click Enter to draw a card:  ");
                    Console.Read();
                    cardDeck = cd.getDeckOfCards();
                    string s = cd.drawRandomCard(cardDeck);
                    Console.WriteLine("" +"You Drew the card : " + s);
                    int cardValue = getCardValue(s);
                    p.setScore(cardValue);
                    Console.WriteLine("your card Value is : " + p.getScore());
                    Console.WriteLine(".........................\n");
                    Console.Read();
                    }
                    updatePlayerTotalScore(myList);
                    determineGameWinner(myList);
                    cd.shuffleDeckOfCards(cardDeck);
                } while (endOfGame != "gameFinished");

        }
        
        //method to update total Score for each player after each round
        public void updatePlayerTotalScore(List<Player> myList)
        {
                int highest = int.MinValue;

                foreach (Player p in myList)
                {
                    if (p.getScore() > highest)
                        highest = p.getScore();
                }
                foreach (Player p in myList)
                {

                if (p.getScore() == highest)
                {
                    highest = p.getTotalScore() + 2;
                    p.setTotalScore(highest);
                    Console.WriteLine("The Winner of this round is player {0} : ", p.getName());
                }
                else if (p.getScore() == -1)
                {
                    int score = p.getTotalScore() - 1;
                    p.setTotalScore(score);
                }
                    Console.WriteLine("The Total Score for Player {0} is {1}", p.getName(), p.getTotalScore());

            }
                

        }

        //method to determine game the winner based on their total score.
        public void determineGameWinner(List<Player> myList)
        {
            int secondhighest = int.MinValue;
            int theHighest = int.MinValue;
            foreach (Player p in myList)
            {
                if ((p.getTotalScore() >= 21) && ((p.getTotalScore() - secondhighest) > 2))
                {
                    Console.WriteLine("We have a Winner.. Congrats  {0} you have won the Game ", p.getName());
                    endOfGame = "gameFinished";
                }
                else if (p.getTotalScore() < 0)
                {
                    p.setTotalScore(0);
                }
                else if (p.getTotalScore() > theHighest)
                {
                    theHighest = p.getTotalScore();
                    secondhighest = theHighest;
                }

                else if (p.getTotalScore() < theHighest && p.getTotalScore() > secondhighest)
                {
                    secondhighest = p.getTotalScore();
                }
            }
        }

        //method to get the value of each deck card passed to it
        public int getCardValue(string str)
        {
                int clubs = 4;
                int diamonds = 3;
                int hearths = 2;
                int spades = 1;
                switch (str)
                {
                    case "2 of Clubs":
                        value = 2 + clubs;
                        break;
                    case "3 of Clubs":
                        value = 3 + clubs;
                        break;
                    case "4 of Clubs":
                        value = 4 + clubs;
                        break;
                    case "5 of Clubs":
                        value = 5 + clubs;
                        break;
                    case "6 of Clubs":
                        value = 6 + clubs;
                        break;
                    case "7 of Clubs":
                        value = 7 + clubs;
                        break;
                    case "8 of Clubs":
                        value = 8 + clubs;
                        break;
                    case "9 of Clubs":
                        value = 9 + clubs;
                        break;
                    case "10 of Clubs":
                        value = 10 + clubs;
                        break;
                    case "Jack of Clubs":
                        value = 11 + clubs;
                        break;
                    case "Queen of Clubs":
                        value = 12 + clubs;
                        break;
                    case "King of Clubs":
                        value = 14 + clubs;
                        break;
                    case "Ace of Clubs":
                        value = 15 + clubs;
                        break;
                    case "PenalityCard of Clubs":
                        value = -1;
                        break;

                    case "2 of Diamonds":
                        value = 2 + diamonds;
                        break;
                    case "3 of Diamonds":
                        value = 3 + diamonds;
                        break;
                    case "4 of Diamonds":
                        value = 4 + diamonds;
                        break;
                    case "5 of Diamonds":
                        value = 5 + diamonds;
                        break;
                    case "6 of Diamonds":
                        value = 6 + diamonds;
                        break;
                    case "7 of Diamonds":
                        value = 7 + diamonds;
                        break;
                    case "8 of Diamonds":
                        value = 8 + diamonds;
                        break;
                    case "9 of Diamonds":
                        value = 9 + diamonds;
                        break;
                    case "10 of Diamonds":
                        value = 10 + diamonds;
                        break;
                    case "Jack of Diamonds":
                        value = 11 + diamonds;
                        break;
                    case "Queen of Diamonds":
                        value = 12 + diamonds;
                        break;
                    case "King of Diamonds":
                        value = 14 + diamonds;
                        break;
                    case "Ace of Diamonds":
                        value = 15 + diamonds;
                        break;
                    case "PenalityCard of Diamonds":
                        value = -1;
                        break;

                    case "2 of Hearts":
                        value = 2 + hearths;
                        break;
                    case "3 of Hearts":
                        value = 3 + hearths;
                        break;
                    case "4 of Hearts":
                        value = 4 + hearths;
                        break;
                    case "5 of Hearts":
                        value = 5 + hearths;
                        break;
                    case "6 of Hearts":
                        value = 6 + hearths;
                        break;
                    case "7 of Hearts":
                        value = 7 + hearths;
                        break;
                    case "8 of Hearts":
                        value = 8 + hearths;
                        break;
                    case "9 of Hearts":
                        value = 9 + hearths;
                        break;
                    case "10 of Hearts":
                        value = 10 + hearths;
                        break;
                    case "Jack of Hearts":
                        value = 11 + hearths;
                        break;
                    case "Queen of Hearts":
                        value = 12 + hearths;
                        break;
                    case "King of Hearts":
                        value = 14 + hearths;
                        break;
                    case "Ace of Hearts":
                        value = 15 + hearths;
                        break;
                    case "PenalityCard of Hearts":
                        value = -1;
                        break;

                    case "2 of Spades":
                        value = 2 + spades;
                        break;
                    case "3 of Spades":
                        value = 3 + spades;
                        break;
                    case "4 of Spades":
                        value = 4 + spades;
                        break;
                    case "5 of Spades":
                        value = 5 + spades;
                        break;
                    case "6 of Spades":
                        value = 6 + spades;
                        break;
                    case "7 of Spades":
                        value = 7 + spades;
                        break;
                    case "8 of Spades":
                        value = 8 + spades;
                        break;
                    case "9 of Spades":
                        value = 9 + spades;
                        break;
                    case "10 of Spades":
                        value = 10 + spades;
                        break;
                    case "Jack of Spades":
                        value = 11 + spades;
                        break;
                    case "Queen of Spades":
                        value = 12 + spades;
                        break;
                    case "King of Spades":
                        value = 14 + spades;
                        break;
                    case "Ace of Spades":
                        value = 15 + spades;
                        break;
                    case "PenalityCard of Spades":
                        value = -1;
                        break;

                    default:
                        value = 0;
                        break;

                };
                return value;
        }
    }
}
