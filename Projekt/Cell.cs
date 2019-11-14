using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Cell
    {
        public int Row;
        public int Column;
        public string Type;

        public Cell(int x, int y)
        {
            Row = x;
            Column = y;
        }


    }
}