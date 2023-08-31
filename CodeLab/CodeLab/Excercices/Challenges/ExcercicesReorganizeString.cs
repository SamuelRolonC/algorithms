namespace CodeLab.Excercices
{
    public class ExcercicesReorganizeString : Excercices, IExcercices
    {
        public void Run()
        {
            Initialize(this);

            foreach(var input in new string[] { "aab", "aaab", "vvvlo" })
            {
                Console.WriteLine($"Input: {input}");
                var output = ReorganizeString(input);
                Console.WriteLine($"Output: {output}");
                Console.WriteLine("");
            }
        }

        public static string ReorganizeString(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            var result = s.ToCharArray();

            for(var i = 0; i < result.Length - 1; i++)
            {
                var nextIndex = i + 1;
                if (result[i] != result[nextIndex]) 
                    continue;
                else if (nextIndex + 1 >= result.Length)
                    return string.Empty;
                
                for(var j = i + 2; j < result.Length; j++)
                {
                    if (result[i] == result[j])
                    {
                        continue;
                    }
                    else
                    {
                        (result[nextIndex], result[j]) = (result[j], result[nextIndex]);
                        break;
                    }
                }
            }

            return string.Join(null, result);
        }

        public static string ReorganizeString1(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            var original = new LinkedList<char>(s.ToCharArray());
            var aux = new LinkedList<char>();
            var final = new LinkedList<char>();

            while (original.Count > 0 || aux.Count > 0)
            {
                char? lastReorganized;

                if (aux.Count > 0)
                {
                    var charPendingToReorganize = (char)aux?.First?.Value;
                    lastReorganized = final?.Last?.Value;

                    if (charPendingToReorganize != lastReorganized || final.Count == 0)
                    {
                        final.AddLast(charPendingToReorganize);
                        aux.RemoveFirst();
                    }
                }

                if (original.Count > 0)
                {
                    var charaToReorganize = (char)original?.First?.Value;
                    lastReorganized = final?.Last?.Value;

                    if (charaToReorganize != lastReorganized || final.Count == 0)
                        final.AddLast(charaToReorganize);
                    else
                    {
                        if (aux.Count > 0 && charaToReorganize == aux.Last.Value) return string.Empty;
                        aux.AddLast(charaToReorganize);
                    }

                    original.RemoveFirst();
                }
            }

            return string.Join(null, final);
        }

        public static string AddCharToStack()
        {
            return "";
        }
    }
}
