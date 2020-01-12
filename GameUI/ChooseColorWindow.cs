using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUI
{
    internal class ChooseColorWindow : Form
    {
        private Button[][] m_colorButtons;
        private Button m_senderButton;

        public ChooseColorWindow(Button i_senderButton)
        {
            m_senderButton = i_senderButton;
            this.Text = "Pick A Color:";
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // initiate 8 colors buttons table
            m_colorButtons = new Button[2][];
            for(int i = 0; i < m_colorButtons.Length; i++)
            {
                m_colorButtons[i] = new Button[4];
                for (int j = 0; j < 4; j++)
                {
                    createColorButton(ref m_colorButtons[i][j]);
                }
            }

            m_colorButtons[0][0].BackColor = Color.BlueViolet;
            m_colorButtons[0][1].BackColor = Color.Red;
            m_colorButtons[0][2].BackColor = Color.Chartreuse;
            m_colorButtons[0][3].BackColor = Color.Aqua;
            m_colorButtons[1][0].BackColor = Color.Blue;
            m_colorButtons[1][1].BackColor = Color.Yellow;
            m_colorButtons[1][2].BackColor = Color.Brown;
            m_colorButtons[1][3].BackColor = Color.White;

            for (int i = 0; i < m_colorButtons.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int xPosition = 10 +  j * m_colorButtons[i][j].Width + (j * 10);
                    int yPosition = 10 + i * m_colorButtons[i][j].Height + (i * 10);
                    m_colorButtons[i][j].Location = new Point(xPosition, yPosition);

                    this.Controls.Add(m_colorButtons[i][j]);
                    m_colorButtons[i][j].Click += new EventHandler(userColorChoose_Click);
                }
            }
        }

        private void userColorChoose_Click(object i_Sender, EventArgs i_E)
        {
            Button senderButton = i_Sender as Button;
            
            if (senderButton != null)
            {
                m_senderButton.BackColor = senderButton.BackColor;
            }

            this.Close();
        }

        private void createColorButton(ref Button io_Button)
        {
            io_Button = new Button();
            io_Button.Enabled = true;
            io_Button.Size = new Size(40, 40);
        }
    }
}
