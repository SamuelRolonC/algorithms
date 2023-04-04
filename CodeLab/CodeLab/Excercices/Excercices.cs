using System.Text.RegularExpressions;

namespace CodeLab.Excercices
{
    public class Excercices
    {
        public static void Initialize(Excercices excercices)
        {
            var name = excercices != null ? Regex.Replace(excercices.GetType().Name, "Excercices", "") : string.Empty;
            Console.WriteLine($"- {name} excersices -");
            Console.WriteLine("");
        }
    }
}
