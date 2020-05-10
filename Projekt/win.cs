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
    /// Klasa w której znajdują się niezbędne funkcje i zmienne do utworzenia ekranu zwycięstwa
    public partial class win : Form
    {
        public String score;

        public win()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Funkcja, ktora wypisuje końcową ilość ruchów
        /// </summary>
        /// <param name="wynik">Końcowa ilość ruchów</param>
        public void Score(string wynik)
        {
            label2.Text = "Twoja liczba ruchów to:" + wynik;
            
        }

        /// <summary>
        ///  Funkcja sprawia, że po naciśnieciu "krzyżyka" na pasku z grą, aplikacja wyłączy się
        /// </summary
        private void win_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// Funkcja, która przy kliknięciu  klawisza M pozwala wrócić do menu
        /// </summary>
        private void win_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {
                Form1 Menu = new Form1();
                Menu.Show();
                Menu.SetBounds(this.Location.X, this.Location.Y, this.Width, this.Height);
                Menu.Location = this.Location;
                this.Hide();

            }
        }


    }
}
