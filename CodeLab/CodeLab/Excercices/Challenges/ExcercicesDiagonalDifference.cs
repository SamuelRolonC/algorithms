using CodeLab.Utils;

namespace CodeLab.Excercices
{
    public class ExcercicesDiagonalDifference : Excercices, IExcercices
    {
        public void Run()
        {
            Initialize(this);

            var rawList = new List<string>() { "11 2 4", "4 5 6", "10 8 -12" };
            Console.WriteLine("Input:");

            List<List<int>> arr = new List<List<int>>();
            foreach(var row in rawList)
            {
                Console.WriteLine(row);
                arr.Add(row.TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            }

            int result = DiagonalDifference(arr);

            Console.WriteLine(result);
        }

        public static int DiagonalDifference(List<List<int>> arr)
        {
            int size = arr.Count();
            int sumLeftRightDiagonal = 0;
            int sumRightLeftDiagonal = 0;

            for (var i = 0; i < size; i++)
            {
                sumLeftRightDiagonal += arr[i][i];
                sumRightLeftDiagonal += arr[i][size - 1 - i];
            }

            return Math.Abs(sumLeftRightDiagonal - sumRightLeftDiagonal);
        }
    }
}
