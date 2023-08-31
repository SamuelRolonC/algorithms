using CodeLab.Utils;

namespace CodeLab.Excercices
{
    public class ExcercicesLonelyInteger : Excercices, IExcercices
    {
        public void Run()
        {
            Initialize(this);

            var rawInput = "34 95 34 64 45 95 16 80 80 75 3 25 75 25 31 3 64 16 31";
            //var rawInput = "0 0 1 2 1";
            List<int> procesedInput = rawInput.TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();
            var output = LonelyInteger(procesedInput);
            Console.WriteLine($"Output: {output}");
            Console.WriteLine("");
        }

        public static int LonelyInteger(List<int> a)
        {
            int number = a.First();
            int lonelyInt = number;
            for (var i = 0; i < a.Count; i++)
            {
                number = a.ElementAt(i);
                var isUnique = true;
                for (var j = 0; j < a.Count; j++)
                {
                    if (j == i) continue;

                    if (number == a.ElementAt(j))
                    {
                        isUnique = false;
                        break;
                    }
                }

                if (isUnique)
                {
                    lonelyInt = number;
                    break;
                }

            }
            return lonelyInt;
        }
    }
}
