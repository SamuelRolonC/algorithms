using System.Diagnostics.Metrics;

namespace CodeLab.Excercices
{
    public class ExcercicesCaesarCipher : Excercices, IExcercices
    {
        public void Run()
        {
            Initialize(this);

            var k = 2;

            foreach(var input in new string[] { "middle-Outz" })
            {
                Console.WriteLine($"Input: {input}");
                var output = CaesarCipher(input, k);
                Console.WriteLine($"Output: {output}");
                Console.WriteLine("");
            }
        }

        public static string CaesarCipher(string s, int k)
        {
            var alphabetChars = "abcdefghijklmnopqrstuvwxyz";
            var encripted = string.Empty;

            foreach(var letter in s)
            {
                if (!alphabetChars.Contains(letter.ToString().ToLower()))
                {
                    encripted += letter;
                    continue;
                }
                var indexInAlphabet = alphabetChars.IndexOf(letter.ToString().ToLower());
                var newLetter = alphabetChars[(indexInAlphabet + k) % 26];
                encripted += char.IsUpper(letter) ? newLetter.ToString().ToUpper() : newLetter.ToString();
            }

            return encripted;
        }
    }
}
