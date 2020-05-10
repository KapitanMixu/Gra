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
    /// Klasa w której znajdują się funkcje do utworzenia i działania menu
    public partial class Form1 : Form
    { 
       /// <summary>
       /// Kontruktor klasy Form1(Menu)
       /// </summary>
        public Form1()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Funkcja, która przy kliknięciu  lewym klawiszem myszki na guzik "Poziom I", włącza ten poziom
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Lvl1 lvl1 = new Lvl1();
            lvl1.Show();
            lvl1.SetBounds(this.Location.X, this.Location.Y, this.Width, this.Height);
            lvl1.Location = this.Location;
            this.Hide();
        }

        /// <summary>
        /// Funkcja, która przy kliknięciu  lewym klawiszem myszki na guzik "Poziom II", włącza ten poziom
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            Lvl2 lvl2 = new Lvl2();
            lvl2.Show();
            lvl2.SetBounds(this.Location.X, this.Location.Y, this.Width, this.Height);
            lvl2.Location = this.Location;
            this.Hide();
        }

        /// <summary>
        /// Funkcja, która przy kliknięciu  lewym klawiszem myszki na guzik "Poziom III", włącza ten poziom
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            Lvl3 lvl3 = new Lvl3();
            lvl3.Show();
            lvl3.SetBounds(this.Location.X, this.Location.Y, this.Width, this.Height);
            lvl3.Location = this.Location;
            this.Hide();
        }

        /// <summary>
        ///  Funkcja sprawia, że po naciśnieciu "krzyżyka" na pasku z grą, aplikacja wyłączy się
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


    }

}
