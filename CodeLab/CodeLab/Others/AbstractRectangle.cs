namespace CodeLab.Others
{
    public abstract class AbstractRectangle
    {
        protected int width, height;

        public AbstractRectangle()
        { 
        }

        public int GetArea()
        {
            return width * height;
        }
    }
}
