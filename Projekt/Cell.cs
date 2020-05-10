using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
      /// Klasa w której znajdują się zmienne potrzebne do utworzenia obiektu Cell
     class Cell
    {
        /// <summary>
        /// Zmienna określająca numer rzędu danej komórki
        /// </summary>
        public int Row;
        /// <summary>
        /// Zmienna określająca numer kolumny danej komórki
        /// </summary>
        public int Column;
        
        /// <summary>
        /// Funkcja tworząca komórkę
        /// </summary>
        /// <param name="x">Numer rzędu komórki</param>
        /// <param name="y">Numer kolumny komórki</param>
        public Cell(int x, int y)
        {
            Row = x;
            Column = y;
        }


    }
}