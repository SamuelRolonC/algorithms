using CodeLab.DataStructure;
using CodeLab.Others;
using System.Drawing;

namespace CodeLab.Excercices
{
    public class ExcercicesLiskovPrinciple : Excercices, IExcercices
    {
        public void Run()
        {
            Initialize(this);

            RectangleNotLiskov rc = new(2, 3);
            GetAreaTest(rc);

            RectangleNotLiskov sq = new SquareNotLiskov(5);
            GetAreaTest(sq);

            AbstractRectangle rectangle = new Others.Rectangle(2, 3);
            GetAreaTest(rectangle);

            AbstractRectangle square = new Square(5);
            GetAreaTest(square);
        }

        private static void GetAreaTest(RectangleNotLiskov r)
        {
            int width = r.GetWidth();
            r.SetHeight(10);
            Console.WriteLine($"TestNotLiskov: Expected area of {width * 10}, got {r.GetArea()}");
        }

        private static void GetAreaTest(AbstractRectangle r)
        {
            Console.WriteLine($"TestLiskov: Area {r.GetArea()}. Not able to calculate expected area.");
        }
    }
}
