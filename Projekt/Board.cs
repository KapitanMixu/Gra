using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Board
    {
        public int Size;
        public Cell[,] theGrid;

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
       public static void  printBoard(Board X)
        {
            for (int i = 0; i < X.Size; i++)
            {
                for (int j = 0; j < X.Size; j++)
                {
                    Cell c = X.theGrid[i,j];

                }
            }
        }
    }

   
}
