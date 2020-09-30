using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift2
{
    public class Opponent
    {
        public int Shots { get; set; }
        public string Action { get; set; }

        public Opponent()
        {
            Shots = 0;
            Action = "";
        }

        public static void OpponentAddShot(Opponent opponent)
        {
            opponent.Shots++;
        }
        public static void OpponentRemoveShot(Opponent opponent)
        {
            opponent.Shots--;
        }

        public static string Randomize(Opponent opponent, Player player)
        {
            Random rand = new Random();

            if (opponent.Shots <= 0 && player.Shots <= 0)
            {
                opponent.Action =  "reload";
                OpponentAddShot(opponent);
            }
            
            else if (opponent.Shots <= 0)
            {
                int intResult12 = rand.Next(1, 3);
                if (intResult12 == 1)
                {
                    opponent.Action = "reload";
                    OpponentAddShot(opponent);
                }
                else
                {
                    opponent.Action = "block";
                }

            }
            else if (opponent.Shots >= 3)
            {
                opponent.Action = "shotgun";
                OpponentRemoveShot(opponent);
            }
            else
            {
                int intResult13 = rand.Next(1, 4);
                if (intResult13 == 1)
                {
                    opponent.Action = "reload";
                    OpponentAddShot(opponent);
                }
                else if (intResult13 == 2)
                {
                    opponent.Action = "block";
                }
                else
                {
                    opponent.Action = "shoot";
                    OpponentRemoveShot(opponent);
                }
            }
            return opponent.Action;
        }
    }
}
