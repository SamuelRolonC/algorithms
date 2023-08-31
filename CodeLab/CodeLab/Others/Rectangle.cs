using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLab.Others
{
    public class Rectangle : AbstractRectangle
    {
        public Rectangle() { }

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public int GetWidth()
        {
            return width;
        }

        public virtual void SetWidth(int width)
        {
            this.width = width;
        }

        public int GetHeight()
        {
            return height;
        }

        public virtual void SetHeight(int height)
        {
            this.height = height;
        }
    }
}
