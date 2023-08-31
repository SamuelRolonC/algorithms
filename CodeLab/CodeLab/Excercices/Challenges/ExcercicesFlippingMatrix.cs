using CodeLab.Utils;

namespace CodeLab.Excercices
{
    public class ExcercicesFlippingMatrix : Excercices, IExcercices
    {
        public void Run()
        {
            Initialize(this);

            var rawList = new List<string>() { "112 42 83 119", "56 125 56 49", "15 78 101 43", "62 98 114 108" };
            //var rawList = new List<string>() { "1 2", "3 4" };
            Console.WriteLine("Input:");

            List<List<int>> arr = new List<List<int>>();
            foreach (var row in rawList)
            {
                Console.WriteLine(row);
                arr.Add(row.TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            }

            int result = FlippingMatrix(arr);

            Console.WriteLine(result);
        }

        public static int FlippingMatrix(List<List<int>> matrix)
        {
            int sum = 0;
            int size = matrix.Count();
            for (int i = 0; i < size / 2; i++)
            {
                for (int j = 0; j < size / 2; j++)
                {
                    //sum += Math.Max(matrix[i][j], Math.Max(matrix[i][size - 1 - j], Math.Max(matrix[size - 1 - i][j], matrix[size - 1 - i][size - 1 - j])));
                    int max = 0;
                    max = Math.Max(matrix[size - 1 - i][size - 1 - j], max);
                    max = Math.Max(matrix[size - 1 - i][j], max);
                    max = Math.Max(matrix[i][size - 1 - j], max);
                    max = Math.Max(matrix[i][j], max);

                    sum += max;
                }
            }
            return sum;
        }
    }
}
