using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLab.Others
{
    public class SquareNotLiskov : RectangleNotLiskov
    {
        public SquareNotLiskov() { }

        public SquareNotLiskov(int size)
        {
            width = height = size;
        }

        public override void SetWidth(int width)
        {
            base.SetWidth(width);
            base.SetHeight(width);
        }

        public override void SetHeight(int height)
        {
            base.SetHeight(height);
            base.SetWidth(height);
        }
    }
}
