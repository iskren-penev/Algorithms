namespace Algorithms.Implementations.Iterators
{
    using System;
    using System.Diagnostics;
    using Algorithms.Exceptions;
    using Algorithms.Interfaces;
    public class ArrayIterator : ICustomIterator
    {
        private readonly object[] array;
        private readonly int first;
        private readonly int last;
        private int current = -1;

        public ArrayIterator(object[] array)
        {
            Debug.Assert(array != null, "The array parameter can't be null!");

            this.array = array;
            this.first = 0;
            this.last = this.array.Length - 1;
        }

        public ArrayIterator(object[] array, int start, int length)
        {
            Debug.Assert(array != null, "The array parameter can't be null!");
            Debug.Assert(start >=0, "The start index can't be less than 0!");
            Debug.Assert(start< array.Length, "The start index can't be bigger than the array length!");
            Debug.Assert(length >= 0, "The length can't be less than 0!");

            this.array = array;
            this.first = start;
            this.last = this.first + length - 1;
        }

        public void First()
        {
            this.current = this.first;
        }

        public void Last()
        {
            this.current = this.last;
        }

        public void Next()
        {
            this.current++;
        }

        public void Previous()
        {
            this.current--;
        }

        public bool IsDone()
        {
            return this.current < this.first || this.current > this.last;
        }

        public object Current()
        {
            if (this.IsDone())
            {

                throw new IteratorOutOfBoundsException();
            }
            return this.array[this.current];
        }
    }
}
