using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift2
{
    public class Player
    {
        public int Shots { get; set; }
        public string Action { get; set; }

        public Player()
        {
            Shots = 0;
            Action = "";
        }

        public static void HandleShots(Player player)
        {
            if (player.Action == "reload")
            {
                PlayerAddShot(player);
            }
            else if (player.Action == "shoot" || player.Action == "shotgun")
            {
                PlayerRemoveShot(player);
            }
        }

        public static void PlayerAddShot(Player player)
        {
            player.Shots++;
        }
        public static void PlayerRemoveShot(Player player)
        {
            player.Shots--;
        }

    }
}
