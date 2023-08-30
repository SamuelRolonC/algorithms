using CodeLab.DataStructure;
using CodeLab.Utils;

namespace CodeLab.Excercices
{
    public class ExcercicesStack : Excercices, IExcercices
    {
        private readonly Dictionary<char, char> _brackets = new()
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' },
        };

        public void Run()
        {
            Initialize(this);

            while (true)
            {
                var text = Input.GetString("Ingrese el texto para validar los corchetes: ");

                Console.WriteLine($"Text: {text}");
                Console.WriteLine("");
                Console.WriteLine($"Resultado: {IsValidSetBrackets(text)}");
            }
        }

        private bool IsValidSetBrackets(string text)
        {
            var stack = new DataStructure.Stack<char>();
            foreach(var character in text)
            {
                if (IsLeftBracket(character))
                    stack.Push(character);
                else if (IsRightBracket(character))
                {
                    if (stack.IsEmpty()) return false;

                    _brackets.TryGetValue(stack.Peek(), out char closingBracket);
                    if (closingBracket == character)
                        stack.Pop();
                    else
                        return false;

                }
            }
            return stack.IsEmpty();
        }

        private bool IsLeftBracket(char bracket)
        {
            return _brackets.ContainsKey(bracket);
        }

        private bool IsRightBracket(char bracket)
        {
            return _brackets.ContainsValue(bracket);
        }
    }
}
