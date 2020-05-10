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

    /// Klasa w której znajdują się niezbędne funkcje i zmienne do utworzenia i działania całego poziomu trzeciego.
    public partial class Lvl3 : Form
    {
        /// <summary>
        /// Plansza gry, która jest obiektem klasy Board
        /// </summary>
        static Board B1 = new Board(13);
        /// <summary>
        /// Kratki na planszy
        /// </summary>
        public Panel[,] pnlGrid = new Panel[B1.Size, B1.Size];
        /// <summary>
        /// Pierwsza współrzędna postaci
        /// </summary>
        int a1;
        /// <summary>
        /// Druga współrzędna postaci
        /// </summary>
        int b1;
        /// <summary>
        /// Pierwsza współrzędna ruchu
        /// </summary>
        int N;
        /// <summary>
        /// Druga współrzędna ruchu
        /// </summary>
        int M;
        /// <summary>
        /// Licznik ruchów
        /// </summary>
        int Wynik = 0;


        /// <summary>
        ///  Funkcja sprawia, że po naciśnieciu "krzyżyka" na pasku z grą, aplikacja wyłączy się
        /// </summary>
        private void Lvl3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



         public Lvl3()
        {
            InitializeComponent();
            makeBoard();                                        
        }

        /// <summary>
        /// Funkcja która, podejmuje kontretną akcję na podstawie klawisza klawiatury, który został wciśnięty:
        /// 
        /// 1.Po kliknięciu R resetuje poziom
        /// 
        /// 2.Po kliknięciu M wraca do menu
        /// 
        /// 3.Po kliknieciu W,S,A albo D wykonuje ruch:
        /// 
        /// a)Zmienia wartości M i N w zależności od klikniętego klawisza
        /// 
        /// b)Sprawdza czy dany ruch jest dozowolony. Jeżeli tak to sprawdza czy postać przesuwa skrzynkę czy nie.
        /// 
        /// c)Wykonuje ruch.
        /// 
        /// d)Sprawdza ile skrzynkek jest na swoich miejscach(Jeżeli wyniesie tylie ile założyliśmy na początku gracz wygrywa)
        /// 
        /// </summary>
        /// @see M, N
        private void Lvl3_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.R)
            {
                Lvl3 lvl3 = new Lvl3();
                lvl3.Show();
                lvl3.SetBounds(this.Location.X, this.Location.Y, this.Width, this.Height);
                lvl3.Location = this.Location;
                this.Hide();

            }
            
            if (e.KeyCode == Keys.M)
            {
                Form1 Menu = new Form1();
                Menu.Show();
                Menu.SetBounds(this.Location.X, this.Location.Y, this.Width, this.Height);
                Menu.Location = this.Location;
                this.Hide();

            }
            else
            {
                
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
                
                

                if (pnlGrid[a1 + N, b1 + M].AccessibleName == "Wall" || ((pnlGrid[a1 + 2 * N, b1 + 2 * M].AccessibleName == "Wall" || pnlGrid[a1 + 2 * N, b1 + 2 * M].AccessibleName == "Box") && pnlGrid[a1 + N, b1 + M].AccessibleName == "Box")) ; 
                else if (pnlGrid[a1 + 2 * N, b1 + 2 * M].AccessibleName != "Wall" && pnlGrid[a1 + N, b1 + M].AccessibleName == "Box") 
                {
                    pnlGrid[a1 + 2 * N, b1 + 2 * M].BackgroundImage = Properties.Resources.box2;              
                    pnlGrid[a1 + 2 * N, b1 + 2 * M].AccessibleName = "Box";                                   
                    pnlGrid[a1, b1].BackgroundImage = Properties.Resources.floor;                             
                    pnlGrid[a1, b1].AccessibleName = null;                                                    
                    pnlGrid[a1 + N, b1 + M].BackgroundImage = Properties.Resources.me;                        
                    pnlGrid[a1 + N, b1 + M].AccessibleName = "Me";                                           
                    a1 = a1 + N;                                                                             
                    b1 = b1 + M;
                }
                else                                                                                          
                {
                    pnlGrid[a1, b1].BackgroundImage = Properties.Resources.floor;
                    pnlGrid[a1, b1].AccessibleName = null;
                    pnlGrid[a1 + N, b1 + M].BackgroundImage = Properties.Resources.me;
                    pnlGrid[a1 + N, b1 + M].AccessibleName = "Me";
                    a1 = a1 + N;
                    b1 = b1 + M;
                }
                int spots = 0;
                for (int i = 0; i < B1.Size; i++)
                {
                    for (int j = 0; j < B1.Size; j++)
                    {
                        if (pnlGrid[i, j].AccessibleName == "Box" && pnlGrid[i, j].AccessibleDescription == "Spot")
                        {
                            pnlGrid[i, j].BackgroundImage = Properties.Resources.box1;
                            spots++;
                        }
                        else if (pnlGrid[i, j].AccessibleName == "Me" && pnlGrid[i, j].AccessibleDescription == "Spot")
                        {
                            pnlGrid[i, j].BackgroundImage = Properties.Resources.me;
                        }
                        else if (pnlGrid[i, j].AccessibleDescription == "Spot")
                        {
                            pnlGrid[i, j].BackgroundImage = Properties.Resources.spot;
                        }



                    }
                }
                Wynik++;
                string Wyniks = Wynik.ToString();
                Score.Text = Wyniks;
                if (spots == 12)
                {
                    win win = new win();
                    win.score = Wyniks;
                    win.Show();
                    win.Score(Wyniks);
                    win.SetBounds(this.Location.X, this.Location.Y, this.Width, this.Height);
                    this.Hide();
                }

            }


        }
        /// <summary>
        /// Funkcja, kóra zapełnia pola plnaszy konkretymi wartośćiami i obrazami.
        /// </summary>
        /// @see pnlGrid
        public void makeBoard()
        {
            int Psize = panel1.Width / B1.Size;
            a1 = 0;
            b1 = 0;
            for (int i = 0; i < B1.Size; i++)
            {
                for (int j = 0; j < B1.Size; j++)
                {
                    pnlGrid[i, j] = new Panel();
                    pnlGrid[i, j].Height = Psize - 1;
                    pnlGrid[i, j].Width = Psize - 1;
                    

                    panel1.Controls.Add(pnlGrid[i, j]);

                    pnlGrid[i, j].Location = new Point(i * Psize, j * Psize);

                    pnlGrid[i, j].Text = "i" + '!' + 'j';
                    if (i == 0 | i == B1.Size - 1 | j == 0 | j == B1.Size - 1)
                    {
                        pnlGrid[i, j].BackgroundImage = Properties.Resources.wall;
                        pnlGrid[i, j].AccessibleName = "Wall";
                    }
                    else
                        pnlGrid[i, j].BackgroundImage = Properties.Resources.floor;
                    if (j == 5 & i == 3)
                    {
                        pnlGrid[i, j].BackgroundImage = Properties.Resources.me;
                        pnlGrid[i, j].AccessibleName = "Me";
                        a1 = i;
                        b1 = j;

                    }

                    if ((j == 1) | j == 10 | j == 11 | (j == 2 & i == 1) | (j == 2 & i == 2) | (j == 2 & i == 3) | (j == 2 & i == 4) | (j == 2 & i == 5) | (j == 2 & i == 6) | (j == 2 & i == 9) | (j == 2 & i == 10) |
                       (j == 2 & i == 11) | (j == 3 & i == 9) | (j == 3 & i == 10) | (j == 3 & i == 11) | (j == 4 & i == 4) | (j == 4 & i == 10) | (j == 4 & i == 11) | (j == 5 & i == 5) | (j == 5 & i == 11) |
                       (j == 6 & i == 1) | (j == 6 & i == 5) | (j == 7 & i == 1) | (j == 7 & i == 2) | (j == 7 & i == 3) | (j == 7 & i == 5) | (j == 8 & i == 1) | (j == 8 & i == 8) | (j == 9 & i == 1) |
                       (j == 9 & i == 5) | (j == 9 & i == 8) | (j == 9 & i == 9) | (j == 9 & i == 10) | (j == 9 & i == 11))
                    {

                        pnlGrid[i, j].BackgroundImage = Properties.Resources.wall;
                        pnlGrid[i, j].AccessibleName = "Wall";

                    }

                    if ((j == 3 & i == 8) | (j == 7 & i == 6) | (j == 8 & i == 5) | (j == 8 & i == 11))
                    {
                        pnlGrid[i, j].BackgroundImage = Properties.Resources.spot;
                        pnlGrid[i, j].AccessibleDescription = "Spot";
                       
                    }
                    if ((j == 4 & i == 2) | (j == 4 & i == 3) | (j == 5 & i == 2) | (j == 6 & i == 3))
                    {
                        pnlGrid[i, j].BackgroundImage = Properties.Resources.box2;
                        pnlGrid[i, j].AccessibleName = "Box";
                      
                    }
                    if ((j == 3 & i == 6) | (j == 4 & i == 7) | (j == 5 & i == 8) | (j == 6 & i == 9) | (j == 7 & i == 10) | (j == 5 & i == 6) | (j == 6 & i == 7) | (j == 7 & i == 8))
                    {
                        pnlGrid[i, j].BackgroundImage = Properties.Resources.box1;
                        pnlGrid[i, j].AccessibleName = "Box";
                        pnlGrid[i, j].AccessibleDescription = "Spot";
                        
                    }
                }
            }

        }
    }
}

