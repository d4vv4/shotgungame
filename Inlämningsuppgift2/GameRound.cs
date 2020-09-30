using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inlämningsuppgift2
{
    public class GameRound
    {
        public Opponent Opponent { get; set; }
        public Player Player { get; set; }

        public GameRound(Opponent opponent, Player player)
        {
            Opponent = opponent;
            Player = player;
        }

        public string CheckResult(Opponent opponent, Player player)
        {
            if (player.Action == "shoot" || player.Action == "shotgun" || opponent.Action == "shoot" || opponent.Action == "shotgun")
            {
                if ((player.Action == "shoot" && opponent.Action == "reload") || (player.Action == "shotgun" && opponent.Action != "shotgun"))
                {
                    return "player";
                }
                else if ((opponent.Action == "shoot" && player.Action == "reload") || (opponent.Action == "shotgun" && player.Action != "shotgun"))
                {
                    return "opponent";
                }

            }
            return "";
        }
    }
}
