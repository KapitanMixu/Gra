﻿using System;
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
        static Board B1 = new Board(10);

        public Panel[,] pnlGrid = new Panel[B1.Size, B1.Size];
        int a1, b1, c, a2 , b2, N, M;
        





        public Form1()
        {
            InitializeComponent();
            
            makeBoard();
           

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

           /* if (e.KeyCode == Keys.R)
            {
                makeBoard();
            } */

            if (e.KeyCode == Keys.W)
            {
                M = -1;
                N = 0;
            }
            if (e.KeyCode == Keys.S)
            {
                M = 1;
                N = 0;
            }
            if (e.KeyCode == Keys.A)
            {
                M = 0;
                N = -1;
            }
            if (e.KeyCode == Keys.D)
            {
                M = 0;
                N = 1;
            }


            if (pnlGrid[a1 + N, b1 + M].BackColor == Color.Gray || ((pnlGrid[a1 + 2 * N, b1 + 2 * M].BackColor == Color.Gray || pnlGrid[a1 + 2 * N, b1 + 2 * M].AccessibleName == "Box") && pnlGrid[a1 + N, b1 + M].AccessibleName == "Box")) ;
            else if (pnlGrid[a1 + 2 * N, b1 + 2 * M].BackColor != Color.Gray && pnlGrid[a1 + N, b1 + M].AccessibleName == "Box")
            {
                pnlGrid[a1 + 2 * N, b1 + 2 * M].BackColor = Color.Brown;
                pnlGrid[a1 + 2 * N, b1 + 2 * M].AccessibleName = "Box";
                pnlGrid[a1, b1].BackColor = Color.Blue;
                pnlGrid[a1 ,b1].AccessibleName = null;
                pnlGrid[a1 + N, b1 + M].BackColor = Color.Gold;
                pnlGrid[a1 + N, b1 + M].AccessibleName = "Me";
                a1 = a1 + N;
                b1 = b1 + M;
            }
            else
            {
                pnlGrid[a1, b1].BackColor = Color.Blue;
                pnlGrid[a1, b1].AccessibleName = null;
                pnlGrid[a1 + N, b1 + M].BackColor = Color.Gold;
                pnlGrid[a1 + N, b1 + M].AccessibleName = "Me";
                a1 = a1 + N;
                b1 = b1 + M;
            }
            int ok = 0;
            for (int i = 0; i < B1.Size; i++)
            {
                for (int j = 0; j < B1.Size; j++)
                {
                    if (pnlGrid[i, j].AccessibleName == "Box" && pnlGrid[i, j].AccessibleDescription == "Spot")
                    {
                        pnlGrid[i, j].BackColor = Color.Green;
                        
                    }else if(pnlGrid[i, j].AccessibleName =="Me" && pnlGrid[i, j].AccessibleDescription == "Spot")
                    {
                        pnlGrid[i, j].BackColor = Color.Gold;
                    }
                    else if(pnlGrid[i, j].AccessibleDescription == "Spot")
                    {
                        pnlGrid[i, j].BackColor = Color.White;
                    }
                    
                    if (pnlGrid[i, j].AccessibleDescription == "Spot")
                    {
                        
                        if (pnlGrid[i, j].AccessibleName == "Box")
                        {
                            ok = ok + 1;
                            
                        }

                        if (ok == 2)
                         {
                            label1.Text = "wygranko" ;
                         }else
                            label1.Text = "przegranko";

                    }
                }
            }

            
            

            
        }

        public void makeBoard()
        {
            int Psize = panel1.Width / B1.Size ;
            a1 = 0;
            b1 = 0;
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
                        pnlGrid[i, j].AccessibleName = "Me";
                        //pnlGrid[i, j].BackgroundImage = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\Projekt\Projekt\postac1.png");
                        a1 = i;
                        b1 = j;

                    }
                    if (i == 4 & j == 4)
                    {
                        pnlGrid[i, j].BackColor = Color.Brown;
                        pnlGrid[i, j].AccessibleName = "Box";
                        a2 = i;
                        b2 = j;
                    }
                    if (i == 5 & j == 5)
                    {
                        pnlGrid[i, j].BackColor = Color.White;
                        pnlGrid[i, j].AccessibleDescription = "Spot";
                        a2 = i;
                        b2 = j;
                    }

                    if (i == 7 & j == 7)
                    {
                        pnlGrid[i, j].BackColor = Color.Brown;
                        pnlGrid[i, j].AccessibleName = "Box";
                        a2 = i;
                        b2 = j;
                    }
                    if (i == 6 & j == 6)
                    {
                        pnlGrid[i, j].BackColor = Color.White;
                        pnlGrid[i, j].AccessibleDescription = "Spot";
                        a2 = i;
                        b2 = j;
                    }

                    // pnlGrid[4, 4].BackgroundImage = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\Projekt\Projekt\postac1.png"); 


                }
                
            }
          
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
