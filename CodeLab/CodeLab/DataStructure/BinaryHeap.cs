using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLab.DataStructure
{
    public class BinaryHeap<T> where T : IComparable<T>
    {
        // A dynamic list to track the elements inside the heap
        private List<T> _heap;

        // Construct and initially empty priority queue
        public BinaryHeap() : this(1)
        {
            
        }

        // Construct a priority queue with an initial capacity
        public BinaryHeap(int sz)
        {
            _heap = new List<T>(sz);
        }

        // Construct a priority queue using heapify in O(n) time, a great explanation can be found at:
        // http://www.cs.umd.edu/~meesh/351/mount/lectures/lect14-heapsort-analysis-part.pdf
        public BinaryHeap(List<T> elements)
        {
            var heapSize = elements.Count();
            _heap = new List<T>(elements);

            // Heapify process, O(n)
            for (int i = Math.Max(0, (heapSize / 2) - 1); i >= 0; i--) Sink(i);
        }

        // Returns true/false depending on if the priority queue is empty
        public bool IsEmpty()
        {
            return Size() == 0;
        }

        // Clears everything inside the heap, O(n)
        public void Clear()
        {
            _heap.Clear();
        }

        // Return the size of the heap
        public int Size()
        {
            return _heap.Count;
        }

        // Returns the value of the element with the lowest
        // priority in this priority queue. If the priority
        // queue is empty null is returned.
        public T? Peek()
        {
            return IsEmpty() ? default : _heap.First();
        }

        // Removes the root of the heap, O(log(n))
        public T? Poll()
        {
            return RemoveAt(0);
        }

        // Test if an element is in heap, O(n)
        public bool Contains(T element)
        {
            // Linear scan to check containment
            for (int i = 0; i < Size(); i++)
            {
                if (_heap.ElementAt(i).Equals(element)) 
                    return true;
            }
            return false;
        }

        // Adds an element to the priority queue, the
        // element must not be null, O(log(n))
        public void Add(T elem)
        {
            if (elem == null) throw new ArgumentNullException();

            _heap.Add(elem);

            int indexOfLastElem = Size() - 1;
            Swim(indexOfLastElem);
        }

        // Tests if the value of node i <= node j
        // This method assumes i & j are valid indices, O(1)
        private bool Less(int i, int j)
        {
            T node1 = _heap.ElementAt(i);
            T node2 = _heap.ElementAt(j);
            return node1.CompareTo(node2) <= 0;
        }

        // Perform bottom up node swim, O(log(n))
        private void Swim(int k)
        {
            // Grab the index of the next parent node WRT to k
            int parent = (k - 1) / 2;

            // Keep swimming while we have not reached the
            // root and while we're less than our parent.
            while (k > 0 && Less(k, parent))
            {
                // Exchange k with the parent
                Swap(parent, k);
                k = parent;

                // Grab the index of the next parent node WRT to k
                parent = (k - 1) / 2;
            }
        }

        // Top down node sink, O(log(n))
        private void Sink(int k)
        {
            int heapSize = Size();
            while (true)
            {
                int left = 2 * k + 1; // Left  node
                int right = 2 * k + 2; // Right node
                int smallest = left; // Assume left is the smallest node of the two children

                // Find which is smaller left or right
                // If right is smaller set smallest to be right
                if (right < heapSize && Less(right, left)) smallest = right;

                // Stop if we're outside the bounds of the tree
                // or stop early if we cannot sink k anymore
                if (left >= heapSize || Less(k, smallest)) break;

                // Move down the tree following the smallest node
                Swap(smallest, k);
                k = smallest;
            }
        }

        // Swap two nodes. Assumes i & j are valid, O(1)
        private void Swap(int i, int j)
        {
            T elem_i = _heap.ElementAt(i);
            T elem_j = _heap.ElementAt(j);
            T aux = elem_i;

            _heap[i] = elem_j;
            _heap[j] = aux;
        }

        // Removes a particular element in the heap, O(n)
        public bool Remove(T element)
        {
            if (element == null) return false;
            // Linear removal via search, O(n)
            for (int i = 0; i < Size(); i++)
            {
                if (element.Equals(_heap.ElementAt(i)))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        // Removes a node at particular index, O(log(n))
        private T? RemoveAt(int i)
        {
            if (IsEmpty()) return default;

            int indexOfLastElem = Size() - 1;
            T removed_data = _heap.ElementAt(i);
            Swap(i, indexOfLastElem);

            // Obliterate the value
            _heap.RemoveAt(indexOfLastElem);

            // Check if the last element was removed
            if (i == indexOfLastElem) return removed_data;
            T elem = _heap.ElementAt(i);

            // Try sinking element
            Sink(i);

            // If sinking did not work try swimming
            if (_heap.ElementAt(i).Equals(elem)) Swim(i);
            return removed_data;
        }

        // Recursively checks if this heap is a min heap
        // This method is just for testing purposes to make
        // sure the heap invariant is still being maintained
        // Called this method with k=0 to start at the root
        public bool IsMinHeap(int k)
        {
            // If we are outside the bounds of the heap return true
            int heapSize = Size();
            if (k >= heapSize) return true;

            int left = 2 * k + 1;
            int right = 2 * k + 2;

            // Make sure that the current node k is less than
            // both of its children left, and right if they exist
            // return false otherwise to indicate an invalid heap
            if (left < heapSize && !Less(k, left)) return false;
            if (right < heapSize && !Less(k, right)) return false;

            // Recurse on both children to make sure they're also valid heaps
            return IsMinHeap(left) && IsMinHeap(right);
        }

        public override string? ToString()
        {
            return _heap.Count > 0 ? string.Join(",", _heap) : string.Empty;
        }
    }
}
