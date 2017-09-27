namespace Algorithms.Implementations.Iterators
{
    using System.Diagnostics;
    using Algorithms.Interfaces;
    public class ReverseIterator : ICustomIterator
    {
        private readonly ICustomIterator iterator;

        public ReverseIterator(ICustomIterator iterator)
        {
            Debug.Assert(iterator != null, "The iterator parameter can't be null!");
            this.iterator = iterator;
        }

        public void First()
        {
            this.iterator.Last();
        }

        public void Last()
        {
            this.iterator.First();
        }

        public void Next()
        {
            this.iterator.Previous();
        }

        public void Previous()
        {
            this.iterator.Next();
        }

        public bool IsDone()
        {
            return this.iterator.IsDone();
        }

        public object Current()
        {
            return this.iterator.Current();
        }
    }
}
