// created by Ali Raddani on 02/18/2020
/*this class will serve to create the player objects
 it will allow to get the player name and his score, and 
 set the player name and score*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Player
    {
        //local variabales to store player name and score
        string name;
        int score = 0;
        int totalScore =0;

        public Player()
        {

        }

        public Player(string name)
        {
            this.name = name;
        }
        // setters and getters for name and score
        public string getName()
        {
            return this.name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public int getScore()
        {
            return this.score;
        }

        public void setScore(int score)
        {
            this.score = score;
        }
        public int getTotalScore()
        {
            return this.totalScore;
        }

        public void setTotalScore(int totalScore)
        {
            this.totalScore = totalScore;
        }

    }
}
