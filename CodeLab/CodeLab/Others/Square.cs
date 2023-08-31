using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLab.Others
{
    public class Square : AbstractRectangle
    {
        public Square() { }

        public Square(int size)
        {
            SetSize(size);
        }

        public int GetSize()
        {
            return width;
        }

        public virtual void SetSize(int size)
        {
            width = size;
            height = size;
        }
    }
}
