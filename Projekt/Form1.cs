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
        int a1, b1, c, a2 , b2;
        
       


        public Form1()
        {
            InitializeComponent();
            
            makeBoard();
           



        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && pnlGrid[a1, b1 - 1].BackColor != Color.Gray)
            {
                pnlGrid[a1, b1].BackColor = Color.Blue;
                pnlGrid[a1, b1-1].BackColor = Color.Gold;
                b1 = b1 - 1;
            }
            if (e.KeyCode == Keys.S && pnlGrid[a1, b1 + 1].BackColor != Color.Gray)
            {
                pnlGrid[a1, b1].BackColor = Color.Blue;
                pnlGrid[a1, b1 + 1].BackColor = Color.Gold;
                b1 = b1 + 1;
            }
            if (e.KeyCode == Keys.A && pnlGrid[a1 -1 , b1 ].BackColor != Color.Gray)
            {
                pnlGrid[a1, b1].BackColor = Color.Blue;
                pnlGrid[a1 - 1, b1 ].BackColor = Color.Gold;
                a1 = a1 - 1;
            }
            if (e.KeyCode == Keys.D && pnlGrid[a1 + 1, b1 ].BackColor != Color.Gray)
            {
                pnlGrid[a1, b1].BackColor = Color.Blue;
                pnlGrid[a1 + 1, b1].BackColor = Color.Gold;
                a1 = a1 + 1;
            }

        }

        public void makeBoard()
        {
            int Psize = panel1.Width / B1.Size ;
            
            for (int i = 0; i < B1.Size; i++)
            {
                for (int j = 0; j < B1.Size; j++)
                {
                    pnlGrid[i, j] = new Panel();
                    pnlGrid[i, j].Height = Psize-5;
                    pnlGrid[i, j].Width = Psize-5;
                    c = Psize;

                    panel1.Controls.Add(pnlGrid[i, j]);

                    pnlGrid[i, j].Location = new Point(i * Psize, j * Psize);

                    pnlGrid[i, j].Text = "i" + '!' + 'j';
                    if (i == 0 | i == B1.Size-1 | j == 0 | j == B1.Size-1)
                    {
                      pnlGrid[i, j].BackColor = Color.Gray;
                    }
                    else
                    pnlGrid[i, j].BackColor = Color.Blue;
                    if ( i == 3 & j == 3)
                    {
                        pnlGrid[i,j].BackColor = Color.Gold;
                        pnlGrid[i, j].AccessibleName = "ja";
                        a1 = i;
                        b1 = j;
                    }

                    //pnlGrid[4, 4].BackgroundImage = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\Projekt\Projekt\postac1.png"); 
                    

                }
                
            }
          
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
