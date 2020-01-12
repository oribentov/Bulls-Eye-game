using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Game
    {
        const int m_LengthOfGuess = 4;
        private int m_NumOfChances;
        private readonly char[] m_ComputerChoice;
        public char[] ComputerChoice
        {
            get
            {
                return m_ComputerChoice;
            }
        }


        public Game(int i_NumOfChances)
        {
            m_NumOfChances = i_NumOfChances;
            m_ComputerChoice = new char[m_LengthOfGuess];
            GenerateComputerChoice();

        }

        private void GenerateComputerChoice()
        {
            Random letter = new Random();

            for (int i = 0; i < m_LengthOfGuess; i++)
            {
                this.m_ComputerChoice[i] = (char)letter.Next((int)'A', (int)'H');
            }
        }

        public int GetNumOfPgia(string i_UserGuess)
        {
            int count = 0;
            for(int i = 0; i < i_UserGuess.Length; i++)
            {
                if(i_UserGuess[i] != m_ComputerChoice[i])
                {
                    if (m_ComputerChoice.Contains(i_UserGuess[i]))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public int GetNumOfBools(string i_UserGuess)
        {
            int count = 0;

            for(int i = 0; i < i_UserGuess.Length; i++)
            {
                if (ComputerChoice[i].Equals(i_UserGuess[i]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
