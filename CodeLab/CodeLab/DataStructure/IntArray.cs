using System.Collections;

namespace CodeLab.DataStructure
{
    public class IntArray : IEnumerable<int>
    {
        private readonly int _defaultCapacity = 8;

        public int[] Array;
        public int Length = 0;
        private int Capacity = 0;

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public IntArray()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            Setup(_defaultCapacity);
        }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public IntArray(int capacity)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            Setup(capacity);
        }

        public IntArray(int[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            Capacity = array.Length;
            Length = array.Length;

            Array = new int[Capacity];
            array.CopyTo(Array, 0);
        }

        public int Size()
        {
            return Length;
        }

        public bool IsEmpty()
        {
            return Length == 0;
        }

        public int Get(int index)
        {
            return Array[index];
        }

        public void Set(int index, int element)
        {
            Array[index] = element;
        }

        public void Add(int element)
        {
            if (Length + 1 >= Capacity)
            {
                if (Capacity == 0)
                    Capacity = 1;
                else
                    Capacity *= 2;

                var newArray = new int[Capacity];
                Array.CopyTo(newArray, 0);
                Array = newArray;
            }

            Array[Length++] = element;
        }

        public void RemoveAt(int index)
        {
            Array[index] = 0;
            for (var i = index; i < Length - 1; i++)
            {
                Array[i] = Array[i + 1];
                Array[i + 1] = 0;
            }
        }

        public bool Remove(int element)
        {
            for (var i = 0; i < Length; i++)
            {
                if (Array[i] == element)
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void Reverse()
        {
            for (var i = 0; i < Length; i++)
            {
                var aux = Array[i];
                Array[i] = Array[Length - i - 1];
                Array[Length - i - 1] = aux;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Index of first element that matches with the parameter. Null if not found.</returns>
        public int? Search(int element)
        {
            for (int i = 0; i < Length; i++)
            {
                if (Array[i] == element) return i;
            }
            return null;
        }

        /// <summary>
        /// Make sure this array is sorted before using this function.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Index of first element that matches with the parameter. Null if not found.</returns>
        public int? BinarySearch(int element)
        {
            var low = 0;
            var high = Length - 1;
            int medium;
            while (low <= high)
            {
                medium = (low + high) / 2;
                if (Array[medium] < element)
                    low = medium + 1;
                else if (Array[medium] > element)
                    high = medium - 1;
                else
                    return medium;
            }
            return null;
        }

        public void Sort()
        {
            System.Array.Sort(Array);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (var i = 0; i < Length; i++)
            {
                yield return Array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Setup(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));
            Capacity = capacity;
            Array = new int[capacity];
        }
    }
}
