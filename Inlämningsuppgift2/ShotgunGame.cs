using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inlämningsuppgift2
{
    public partial class frmGame : Form
    {
        public frmGame()
        {
            InitializeComponent();
        }

        public static Player player = new Player();
        public static Opponent opponent = new Opponent();
        string result = "";

        public void frmGame_Load(object sender, EventArgs e)
        {
            player.Shots = 0;
            opponent.Shots = 0;
            ChangeUI(opponent, player);
        }

        public void Msg(string outCome)
        {
            string message = "The " + outCome + " is the winner.\nDo you want to play again?";
            string title = "Shotgun";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                player.Shots = 0;
                opponent.Shots = 0;
                player.Action = "";
                opponent.Action = "";
                ChangeUI(opponent, player);
            }
            else
            {
                Application.Exit();
            }
        }

        public void ChangeUI(Opponent opponent, Player player)
        {
            lblOpponentAction.Text = opponent.Action;
            lblPlayerAction.Text = player.Action;
            lblOpponentShots.Text = opponent.Shots.ToString();
            lblPlayerShots.Text = player.Shots.ToString();
            if (player.Shots <= 0)
            {
                btnShoot.Enabled = false;
                btnShotgun.Enabled = false;
            }
            else
            {
                btnShoot.Enabled = true;
                if (player.Shots >= 3)
                {
                    btnShotgun.Enabled = true;
                }
                else
                {
                    btnShotgun.Enabled = false;
                }
            }
        }

        private void NewRound(Opponent opponent, Player player, string playerAction)
        {
            opponent.Action = Opponent.Randomize(opponent, player);
            player.Action = playerAction;
            Player.HandleShots(player);
            ChangeUI(opponent, player);
            GameRound gameround = new GameRound(opponent, player);
            result = gameround.CheckResult(opponent, player);
            if (result == "player" || result == "opponent")
            {
                Msg(result);
            }

        }

        private void btnShoot_Click(object sender, EventArgs e)
        {
            NewRound(opponent, player, "shoot");
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            NewRound(opponent, player, "reload");
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            NewRound(opponent, player, "block");
        }

        private void btnShotgun_Click(object sender, EventArgs e)
        {
            NewRound(opponent, player, "shotgun");
        }
    }
}
