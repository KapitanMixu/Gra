using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{
    public partial class Form1 : Form
    {
        static Board B1 = new Board(8);

        public Panel[,] pnlGrid = new Panel[B1.Size, B1.Size];
        Panel P1 = new Panel();
       


        public Form1()
        {
            InitializeComponent();
            P1.Width = 800;
            P1.Height = 800;
            makeBoard();


        }

        public void makeBoard()
        {
            int Psize = P1.Width / B1.Size;
            for (int i = 0; i < B1.Size; i++)
            {
                for (int j = 0; j < B1.Size; j++)
                {
                    pnlGrid[i, j] = new Panel();
                    pnlGrid[i, j].Height = Psize;
                    pnlGrid[i, j].Width = Psize;

                }
            }
        }

    }
    
}
