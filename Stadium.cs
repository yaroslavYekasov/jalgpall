using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    public class Stadium
    {
        //konstruktor
        public Stadium(int width, int height)
        {
            Width = width;
            Height = height;
        }

        //anna Width
        public int Width { get; }

        //anna Height
        public int Height { get; }

        //is it in stadium
        public bool IsIn(double x, double y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }

}
