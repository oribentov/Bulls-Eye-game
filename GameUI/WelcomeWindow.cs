using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace GameUI
{
    public class WelcomeWindow : Form
    {
        private Button m_NumOfChancesButton;
        private Button m_StartGameButton;
        internal int m_NumOfChances = 4;

        public WelcomeWindow()
        {
            this.Text = "Start Game";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.m_NumOfChancesButton = new System.Windows.Forms.Button();
            this.m_StartGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_NumOfChancesButton
            // 
            this.m_NumOfChancesButton.Location = new System.Drawing.Point(28, 35);
            this.m_NumOfChancesButton.Name = "m_NumOfChancesButton";
            this.m_NumOfChancesButton.Size = new System.Drawing.Size(306, 45);
            this.m_NumOfChancesButton.TabIndex = 0;
            this.m_NumOfChancesButton.Text = "Number of chances: 4";
            this.m_NumOfChancesButton.UseVisualStyleBackColor = true;
            this.m_NumOfChancesButton.Click += new System.EventHandler(this.NumOfChancesButton_Click);
            // 
            // m_StartGameButton
            // 
            this.m_StartGameButton.Location = new System.Drawing.Point(234, 111);
            this.m_StartGameButton.Name = "m_StartGameButton";
            this.m_StartGameButton.Size = new System.Drawing.Size(100, 43);
            this.m_StartGameButton.TabIndex = 1;
            this.m_StartGameButton.Text = "Start";
            this.m_StartGameButton.UseVisualStyleBackColor = true;
            this.m_StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // WelcomeWindow
            // 
            this.ClientSize = new System.Drawing.Size(356, 178);
            this.Controls.Add(this.m_StartGameButton);
            this.Controls.Add(this.m_NumOfChancesButton);
            this.Name = "WelcomeWindow";
            this.ResumeLayout(false);

        }

        private void NumOfChancesButton_Click(object sender, EventArgs e)
        {
            this.m_NumOfChances++;

            if(this.m_NumOfChances > 10)
            {
                this.m_NumOfChances = 4;
            }

            string buttonText = string.Format("Number of chances: {0}", m_NumOfChances);

            this.m_NumOfChancesButton.Text = buttonText;
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            GameUI.BoardWindow gameBoard = new BoardWindow(m_NumOfChances);

            gameBoard.ShowDialog();
        }
    }
}
