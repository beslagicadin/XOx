using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace progXO
{
    public partial class progXO : Form
    {
        bool turn = true;
        int turnCount = 0;

        

        public progXO()
        {
            InitializeComponent();
            label4.Text = "x";
        }

        //Help>About;
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Uradio:  \r\n  Adin Bešlagić 4t2 \r\n \r\nDatum: \r\n   30.01.2018.", "About XO");
        }

        //File>Exit;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Button_Click;
        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "x";
                label4.Text = "O";
            }
            else
            {
                b.Text = "o";
                label4.Text = "X";
            }

            turn = !turn;
            b.Enabled = false;
            check4winner();
            turnCount++;
            label2.Text = Convert.ToString(turnCount);
        }

        //checking_Method
        private void check4winner()
        {
            bool winnerCheck=false;

            //horizontal
            if((A1.Text==A2.Text)&&(A2.Text==A3.Text)&&(!A1.Enabled))
                winnerCheck=true;
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                winnerCheck=true;
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                winnerCheck=true;

            //vertical
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                winnerCheck= true;
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                winnerCheck = true;
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                winnerCheck = true;

            //diagonal
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                winnerCheck = true;
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                winnerCheck = true;

            //results
            if (winnerCheck)
            {
                disableButtons();

                String winner = "";

                if (turn)
                    winner = "O";
                else
                    winner = "X";

                MessageBox.Show(winner + " wins!", "We have a winner!");
                label2.Text = "";
                
            }
            else 
            {
                if ((A1.Enabled == false) && (A2.Enabled == false) && (A3.Enabled == false) && (B1.Enabled == false) && (B2.Enabled == false) && (B3.Enabled == false) && (C1.Enabled == false) && (C2.Enabled == false) && (C3.Enabled == false))
                {
                    MessageBox.Show("Draw!", "Bummer!");
                    label2.Text = "";
                }
            }




        }
        private void disableButtons()
        {
            //disable
            A1.Enabled = false; A2.Enabled = false; A3.Enabled = false;
            B1.Enabled = false; B2.Enabled = false; B3.Enabled = false;
            C1.Enabled = false; C2.Enabled = false; C3.Enabled = false;
            }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
                //Process.Start("http://en.wikipedia.org/wiki/Tic-tac-toe");
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 1;
            //enable
            A1.Enabled = !false; A2.Enabled = !false; A3.Enabled = !false;
            B1.Enabled = !false; B2.Enabled = !false; B3.Enabled = !false;
            C1.Enabled = !false; C2.Enabled = !false; C3.Enabled = !false;
            //empty the buttons
            A1.Text = ""; A2.Text = ""; A3.Text = "";
            B1.Text = ""; B2.Text = ""; B3.Text = "";
            C1.Text = ""; C2.Text = ""; C3.Text = "";
            //turn set
            label4.Text = "X";
            
        }

        private void enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "x";
            else
                b.Text = "o";
        }

        private void leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
                b.Text = "";
            
        }
        }

        
}

    

