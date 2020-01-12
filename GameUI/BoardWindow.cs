using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GameUI
{
    internal class BoardWindow : Form
    {
        
        private const int k_NumOfGuesses = 4;
        private Button[] m_ComputerGuessesButtons;
        private Button[][] m_PlayerGuessesButtons;
        private Button[] m_showResultButton;
        private Button[][] m_guessResultButtons;
        private int m_NumOfChances;
        private int m_CurrentChoiceRound;
        private StringBuilder m_PlayerGuess;
        private GameLogic.Game m_GameLogic;

        public BoardWindow(int i_NumOfChances)
        {
            this.Text = "Bool Pgia";
            this.AutoSize = true;
            this.m_PlayerGuess = new StringBuilder();
            m_CurrentChoiceRound = 0;
            //m_PlayerGuess = new StringBuilder();
            m_NumOfChances = i_NumOfChances;
            m_GameLogic = new GameLogic.Game(i_NumOfChances);
            createComputerButtons();
            createPlayerButtons(m_NumOfChances);
            createShowResultButton(i_NumOfChances);
            createGuessesResultButtons(i_NumOfChances);
        }


        private void createComputerButtons()
        {
            m_ComputerGuessesButtons = new Button[k_NumOfGuesses];

            for (int i = 0; i < k_NumOfGuesses; i++)
            {
                createButton(ref m_ComputerGuessesButtons[i]);
                m_ComputerGuessesButtons[i].BackColor = Color.Black;
                int xPosition = 10 + i * m_ComputerGuessesButtons[i].Width + (i * 10);
                int yPosition = 10;
                m_ComputerGuessesButtons[i].Location = new Point(xPosition, yPosition);

                this.Controls.Add(m_ComputerGuessesButtons[i]);
            }
        }

        private void createPlayerButtons(int i_NumOfChances)
        {
            m_PlayerGuessesButtons = new Button[i_NumOfChances][];

            for (int i = 0; i < i_NumOfChances; i++)
            {
                m_PlayerGuessesButtons[i] = new Button[k_NumOfGuesses];

                for (int j = 0; j < k_NumOfGuesses; j++)
                {
                    createButton(ref m_PlayerGuessesButtons[i][j]);
                    int xPosition = 10 + j * m_PlayerGuessesButtons[i][j].Width + (j * 10);
                    int yPosition = m_ComputerGuessesButtons[j].Height + i * (m_PlayerGuessesButtons[i][j].Height + 10) + m_PlayerGuessesButtons[i][j].Height;
                    m_PlayerGuessesButtons[i][j].Location = new Point(xPosition, yPosition);

                    this.Controls.Add(m_PlayerGuessesButtons[i][j]);
                    m_PlayerGuessesButtons[i][j].Click += new EventHandler(ChooseColor_Click);
                }
            }

            for (int j = 0; j < k_NumOfGuesses; j++)
            {
                m_PlayerGuessesButtons[0][j].Enabled = true;
            }

        }

        private void ChooseColor_Click(object i_Sender, EventArgs i_E)
        {
            // open choose color window and show dialog
            ChooseColorWindow colorChoose = new ChooseColorWindow(i_Sender as Button);
            colorChoose.ShowDialog();
            AddPlayerGuess(((Button)i_Sender).BackColor.Name);
            if(isCompletedRound())
            {
                m_showResultButton[m_CurrentChoiceRound].Enabled = true;
            }
        }

        private bool isCompletedRound()
        {
            bool isCompleted = true;
            for(int j = 0; j < k_NumOfGuesses; j++)
            {
                if(m_PlayerGuessesButtons[m_CurrentChoiceRound][j].BackColor == Button.DefaultBackColor)
                {
                    isCompleted = false;
                    break;
                    
                }
            }

            return isCompleted;
        }

        private void createShowResultButton(int i_NumOfChances)
        {
            m_showResultButton = new Button[i_NumOfChances];
            for(int i = 0; i < i_NumOfChances; i++)
            {
                m_showResultButton[i] = new Button();
                m_showResultButton[i].Enabled = false;
                m_showResultButton[i].Text = "-->>";
                m_showResultButton[i].Size = new Size(35, 15);

                int xPosition = 5 + 5 * m_PlayerGuessesButtons[i][0].Width;
                int yPosition = m_PlayerGuessesButtons[i][0].Location.Y + 10;
                m_showResultButton[i].Location = new Point(xPosition, yPosition);

                this.Controls.Add(m_showResultButton[i]);
                m_showResultButton[i].Click += new EventHandler(showResult_Click);
            }
        }

        private void showResult_Click(object i_Sender, EventArgs i_E)
        {
            //string result = GameLogic.CheckGuessResult(m_PlayerGuess.ToString());
            m_CurrentChoiceRound++;
            changeEnableByRound(m_CurrentChoiceRound);

            // update result buttons:
            int numOfBool = m_GameLogic.GetNumOfBools(this.m_PlayerGuess.ToString());
            int numOfPgia = m_GameLogic.GetNumOfPgia(this.m_PlayerGuess.ToString());

            for (int i = 0; i < numOfBool; i++)
            {
                m_guessResultButtons[m_CurrentChoiceRound - 1][i].BackColor = Color.Black;
            }

            for (int i = 0; i < numOfPgia; i++)
            {
                m_guessResultButtons[m_CurrentChoiceRound - 1][i + numOfBool].BackColor = Color.Yellow;
            }

            if(numOfBool == k_NumOfGuesses)
            {
                ShowComputerResult();
            }

            m_PlayerGuess = new StringBuilder();
        }

        private void ShowComputerResult()
        {
            for(int i = 0; i < m_ComputerGuessesButtons.Length; i++)
            {
                switch (m_GameLogic.ComputerChoice[i])
                {
                    case 'A':
                        m_ComputerGuessesButtons[i].BackColor = Color.BlueViolet;
                        break;
                    case 'B':
                        m_ComputerGuessesButtons[i].BackColor = Color.Red;
                        break;
                    case 'C':
                        m_ComputerGuessesButtons[i].BackColor = Color.Chartreuse;
                        break;
                    case 'D':
                        m_ComputerGuessesButtons[i].BackColor = Color.Aqua;
                        break;
                    case 'E':
                        m_ComputerGuessesButtons[i].BackColor = Color.Blue;
                        break;
                    case 'F':
                        m_ComputerGuessesButtons[i].BackColor = Color.Yellow;
                        break;
                    case 'G':
                        m_ComputerGuessesButtons[i].BackColor = Color.Brown;
                        break;
                    case 'H':
                        m_ComputerGuessesButtons[i].BackColor = Color.White;
                        break;
                }
            }
        }

        private void changeEnableByRound(int i_CurrentChoiceRound)
        {
            this.m_showResultButton[i_CurrentChoiceRound - 1].Enabled = false;


            for(int j = 0; j < k_NumOfGuesses; j++)
            {
                m_PlayerGuessesButtons[i_CurrentChoiceRound - 1][j].Enabled = false;
                m_PlayerGuessesButtons[i_CurrentChoiceRound ][j].Enabled = true;
            }
        }

        private void createGuessesResultButtons(int i_NumOfChances)
        {
            m_guessResultButtons = new Button[i_NumOfChances][];

            for (int i = 0; i < i_NumOfChances; i++)
            {
                m_guessResultButtons[i] = new Button[k_NumOfGuesses];

                for (int j = 0; j < k_NumOfGuesses; j++)
                {
                    int xPosition;
                    int yPosition;
                    createResultButton(ref m_guessResultButtons[i][j]);

                    if (j % 2 == 0)
                    // position the left column
                    {
                        xPosition = m_showResultButton[i].Location.X + m_showResultButton[i].Width + 10 + 7 * j;
                        yPosition = m_showResultButton[i].Location.Y - 5;
                    }
                    else
                        // position the right column
                    {
                        xPosition = m_showResultButton[i].Location.X + m_showResultButton[i].Width + 10 + 7 * (j - 1);
                        yPosition = m_showResultButton[i].Location.Y + 10;
                    }
                    
                    m_guessResultButtons[i][j].Location = new Point(xPosition, yPosition);

                    this.Controls.Add(m_guessResultButtons[i][j]);
                }
            }
        }

        private void createButton(ref Button io_Button)
        {
            io_Button = new Button();
            io_Button.Enabled = false;
            io_Button.Size = new Size(40, 40);
        }

        private void createResultButton(ref Button io_Button)
        {
            io_Button = new Button();
            io_Button.Enabled = false;
            io_Button.Size = new Size(10, 10);
        }

        internal void AddPlayerGuess(string i_Guess)
        {
            // create string of input in format of: <A B C D >
            StringBuilder formatedUserInput = new StringBuilder();

            switch (i_Guess)
            {
                case "BlueViolet":
                    formatedUserInput.Append('A');
                    break;
                case "Red":
                    formatedUserInput.Append('B');
                    break;
                case "Chartreuse":
                    formatedUserInput.Append('C');
                    break;
                case "Aqua":
                    formatedUserInput.Append('D');
                    break;
                case "Blue":
                    formatedUserInput.Append('E');
                    break;
                case "Yellow":
                    formatedUserInput.Append('F');
                    break;
                case "Brown":
                    formatedUserInput.Append('G');
                    break;
                case "White":
                    formatedUserInput.Append('H');
                    break;
            }

            //formatedUserInput.Append(" ");

            m_PlayerGuess.Append(formatedUserInput.ToString());
        }

    }
}