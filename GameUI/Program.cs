using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GameUI.WelcomeWindow startWindow = new WelcomeWindow();
            startWindow.ShowDialog();
        }
    }
}
