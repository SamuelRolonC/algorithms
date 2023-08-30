using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLab.Others
{
    public class RectangleNotLiskov
    {
        protected int width, height;

        public RectangleNotLiskov()
        {
        }

        public RectangleNotLiskov(int width, int height)
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

        public int GetArea()
        {
            return width * height;
        }
    }
}
