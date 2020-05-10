using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    /// Klasa w której znajdują się zmienne potrzebne do utworzenia obiektu Board

    class Board
    {
        /// <summary>
        /// Zmienna oznaczająca wielkośc planszy
        /// </summary>
        public int Size;
        /// <summary>
        /// Tablica kratek, która jest obiektem klasy Cell
        /// </summary>
        public Cell[,] theGrid;
        /// <summary>
        /// Funkcja tworząca planszę na podstawię obiektów klasy Cell
        /// </summary>
        /// <param name="s">Wielkość planszy</param>
        /// @see Size, theGrid
        public Board(int s)
        {
            Size = s;

            theGrid = new Cell[Size, Size];

            for(int i = 0; i < Size; i++  )
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);

                }
            }
           
        }
    
    }

   
}
