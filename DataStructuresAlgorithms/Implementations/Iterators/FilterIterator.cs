namespace Algorithms.Implementations.Iterators
{
    using System.Diagnostics;
    using Algorithms.Interfaces;

    public class FilterIterator : ICustomIterator
    {
        private readonly ICustomIterator iterator;
        private readonly ICustomPredicate predicate;

        public FilterIterator(ICustomIterator iterator, ICustomPredicate predicate)
        {
            Debug.Assert(iterator != null, "The iterator parameter can't be null!");
            Debug.Assert(predicate != null, "The predicate parameter can't be null!");

            this.iterator = iterator;
            this.predicate = predicate;
        }

        public void First()
        {
            this.iterator.First();
            this.FilterForwards();
        }

        public void Last()
        {
            this.iterator.Last();
            this.FilterBackwars();
        }

        public void Next()
        {
            this.iterator.Next();
            this.FilterForwards();
        }

        public void Previous()
        {
            this.iterator.Previous();
            this.FilterBackwars();
        }

        public bool IsDone()
        {
            return this.iterator.IsDone();
        }

        public object Current()
        {
            return this.iterator.Current();
        }

        private void FilterForwards()
        {
            while (!this.iterator.IsDone() && !this.predicate.Evaluate(this.iterator.Current()))
            {
                this.iterator.Next();
            }
        }

        private void FilterBackwars()
        {
            while (!this.iterator.IsDone() && !this.predicate.Evaluate(this.iterator.Current()))
            {
                this.iterator.Previous();
            }
        }
    }
}
