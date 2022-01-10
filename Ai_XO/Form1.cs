using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ai_XO
{
    public partial class frmXO : Form
    {
        #region Variable And Constant
        String[,] board = new string[3, 3];
        #endregion

        #region Constructor

        public frmXO()
        {
            InitializeComponent();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = "";
                }
            }
        }

        #endregion

        #region Events

        private void btn1_MouseClick(object sender, MouseEventArgs e)
        {
            Button temp = (Button)sender;
            if (string.IsNullOrEmpty(temp.Text))
            {

                temp.Text = "X";
                SetX(temp.Name);
                Move();
                System.Diagnostics.Debug.Write("\n");
            }
        }

        #endregion

        #region Methods And Functions 
  

        String CheckWinner()
        {
            if (board[0, 0] == board[0, 1] && board[0, 0] == board[0, 2] && board[0, 0] != "")
                return board[0, 0];
            else if (board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2] && board[1, 0] != "")
                return board[1, 0];
            else if (board[2, 0] == board[2, 1] && board[2, 0] == board[2, 2] && board[2, 0] != "")
                return board[2, 0];
            else if (board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0] && board[0, 0] != "")
                return board[0, 0];
            else if (board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1] && board[0, 1] != "")
                return board[0, 1];
            else if (board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2] && board[0, 2] != "")
                return board[0, 2];
            else if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0, 0] != "")
                return board[0, 0];
            else if (board[2, 0] == board[1, 1] && board[2, 0] == board[0, 2] && board[2, 0] != "")
                return board[2, 0];
            else
                return "";
        }

        Boolean  checkDraw()
        {
            for (int i = 0 ; i < 3 ; i++)
            {
                for (int j=0; j < 3; j++)
                {
                    if (board[i, j] == "")
                    {
                        return false;
                    }
                }
            }
            return true;
         }

        Boolean CheckAvalibal(int i, int j)
        {
            if (board[i, j] == "")
            { 
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        void SetX(String btn)
        {
            if (btn == "btn1")
            {
                board[0, 0] = "X";
            }
            else if (btn == "btn2")
            {
                board[0, 1] = "X";
            }
            else if (btn == "btn3")
            {
                board[0, 2] = "X";
            }
            else if (btn == "btn4")
            {
                board[1, 0] = "X";
            }
            else if (btn == "btn5")
            {
                board[1, 1] = "X";
            }
            else if (btn == "btn6")
            {
                board[1, 2] = "X";
            }
            else if (btn == "btn7")
            {
                board[2, 0] = "X";
            }
            else if (btn == "btn8")
            {
                board[2, 1] = "X";
            }
            else if (btn == "btn9")
            {
                board[2, 2] = "X";
            }

        }

        void SetO(int i, int j)
        {
            if (CheckAvalibal(i, j))
            {
                if (i == 0 && j == 0)
                {
                    btn1.Text = "O";
                    board[i, j] = "O";
                }
                else if (i == 0 && j == 1)
                {
                    btn2.Text = "O";
                    board[i, j] = "O";
                }
                else if (i == 0 && j == 2)
                {
                    btn3.Text = "O";
                    board[i, j] = "O";
                }
                else if (i == 1 && j == 0)
                {
                    btn4.Text = "O";
                    board[i, j] = "O";
                }
                else if (i == 1 && j == 1)
                {
                    btn5.Text = "O";
                    board[i, j] = "O";
                }
                else if (i == 1 && j == 2)
                {
                    btn6.Text = "O";
                    board[i, j] = "O";
                }
                else if (i == 2 && j == 0)
                {
                    btn7.Text = "O";
                    board[i, j] = "O";
                }
                else if (i == 2 && j == 1)
                {
                    btn8.Text = "O";
                    board[i, j] = "O";
                }
                else if (i == 2 && j == 2)
                {
                    btn9.Text = "O";
                    board[i, j] = "O";
                }
            }
        }

        void clear()
        {
            board = new string[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i,j] = "";
                }
            }
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";
        }

        void Move()
        {
            int m = 0;
            int n = 0;
            int bestScore = int.MinValue;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == "")
                    {
                        board[i, j] = "O";
                        int score = minimax(board, 0, false);
                        System.Diagnostics.Debug.Write("a[" + i + "," + j + "]=" + board[i, j] + "Score = " + score + " , ");
                        board[i, j] = "";
                        if (score > bestScore)
                        {
                            bestScore = score;
                            m = i;
                            n = j;
                        }
                        //else {
                        //    System.Diagnostics.Debug.WriteLine("score="+score +" , BestScore="+bestScore );
                        //}
                    }
                }
                System.Diagnostics.Debug.Write("\n");
            }

            SetO(m, n);
            String Winner = CheckWinner();
            if (Winner != "")
            {
                MessageBox.Show("Winer : " + Winner);
                clear();
            }
            else if (checkDraw())
            {
                MessageBox.Show("   Draw    ");
                clear();
            }
        }

        int minimax(String[,] board, int depth, Boolean isMaximizing)
        {
            int bestScore;
            if (CheckWinner() == "O")
            {
                return 1;
            }
            else if (CheckWinner() == "X")
            {
                return -1;
            }
            else if (checkDraw())
                return 0;

            if (isMaximizing)
            {
                bestScore = int.MinValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == "")
                        {
                            board[i, j] = "O";
                            int score = minimax(board, depth + 1, false);
                            board[i, j] = "";
                            if (score > bestScore)
                                bestScore = score;
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                bestScore = int.MaxValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == "")
                        {
                            board[i, j] = "X";
                            int score = minimax(board, depth + 1, true);
                            board[i, j] = "";
                            if (score < bestScore)
                                bestScore = score;
                        }
                    }
                }
                return bestScore;
            }

        }

        #endregion

    }
}
