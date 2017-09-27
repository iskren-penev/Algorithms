namespace Algorithms.Test.Iterators
{
    using System;
    using Algorithms.Exceptions;
    using Algorithms.Implementations.Iterators;
    using Algorithms.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FilterIteratorTest
    {
        //dummy predicate implementing the ICustomPredicate class
        private sealed class DummyPredicate : ICustomPredicate
        {
            private readonly ICustomIterator iterator;
            private readonly bool result;

            public DummyPredicate(ICustomIterator iterator, bool result)
            {
                this.iterator = iterator;
                this.result = result;
                iterator.First();
            }

            public bool Evaluate(object obj)
            {
                Assert.AreSame(this.iterator.Current(), obj);
                this.iterator.Next();
                return this.result;
            }
        }


        private object[] array;
        private ICustomIterator underlyingIterator;
        private ICustomIterator expectedIterator;

        [TestInitialize]
        public void Initialize()
        {
            this.array = new object[] { "A", "B", "C" };
            this.underlyingIterator = new ArrayIterator(this.array);
        }

        [TestMethod]
        public void FilterIterator_ForwardIterations_IncludesItemsIfPredicateReturnsTrue()
        {
            this.expectedIterator = new ArrayIterator(this.array);
            ICustomIterator iterator = new FilterIterator(this.underlyingIterator,
                new DummyPredicate(this.expectedIterator, true));

            iterator.First();
            Assert.IsFalse(iterator.IsDone());
            Assert.AreSame(this.array[0], iterator.Current());

            iterator.Next();
            Assert.IsFalse(iterator.IsDone());
            Assert.AreSame(this.array[1], iterator.Current());

            iterator.Next();
            Assert.IsFalse(iterator.IsDone());
            Assert.AreSame(this.array[2], iterator.Current());

            iterator.Next();
            Assert.IsTrue(iterator.IsDone());
            try
            {
                iterator.Current();
                Assert.Fail();
            }
            catch (IteratorOutOfBoundsException e)
            {
                //expected
            }

            Assert.IsTrue(this.expectedIterator.IsDone());
            Assert.IsTrue(this.underlyingIterator.IsDone());
        }

        [TestMethod]
        public void FilterIterator_ForwardIterations_ExcludesItemsIfPredicateReturnsFalse()
        {
            this.expectedIterator = new ArrayIterator(this.array);
            ICustomIterator iterator = new FilterIterator(this.underlyingIterator,
                new DummyPredicate(this.expectedIterator, false));

            iterator.First();
            Assert.IsTrue(iterator.IsDone());
            try
            {
                iterator.Current();
                Assert.Fail();
            }
            catch (IteratorOutOfBoundsException e)
            {
                //expected
            }

            Assert.IsTrue(this.expectedIterator.IsDone());
            Assert.IsTrue(this.underlyingIterator.IsDone());
        }

        [TestMethod]
        public void FilterIterator_BackwardIterations_IncludesItemsIfPredicateReturnsTrue()
        {
            this.expectedIterator = new ReverseIterator(new ArrayIterator(this.array));
            ICustomIterator iterator = new FilterIterator(this.underlyingIterator,
                new DummyPredicate(this.expectedIterator, true));

            iterator.Last();
            Assert.IsFalse(iterator.IsDone());
            Assert.AreSame(this.array[2], iterator.Current());

            iterator.Previous();
            Assert.IsFalse(iterator.IsDone());
            Assert.AreSame(this.array[1], iterator.Current());

            iterator.Previous();
            Assert.IsFalse(iterator.IsDone());
            Assert.AreSame(this.array[0], iterator.Current());

            iterator.Previous();
            Assert.IsTrue(iterator.IsDone());
            try
            {
                iterator.Current();
                Assert.Fail();
            }
            catch (IteratorOutOfBoundsException e)
            {
                //expected
            }

            Assert.IsTrue(this.expectedIterator.IsDone());
            Assert.IsTrue(this.underlyingIterator.IsDone());
        }

        [TestMethod]
        public void FilterIterator_BackwardIterations_ExcludesItemsIfPredicateReturnsFalse()
        {
            this.expectedIterator = new ReverseIterator(new ArrayIterator(this.array));
            ICustomIterator iterator = new FilterIterator(this.underlyingIterator,
                new DummyPredicate(this.expectedIterator, false));

            iterator.Last();
            Assert.IsTrue(iterator.IsDone());
            try
            {
                iterator.Current();
                Assert.Fail();
            }
            catch (IteratorOutOfBoundsException e)
            {
                //expected
            }

            Assert.IsTrue(this.expectedIterator.IsDone());
            Assert.IsTrue(this.underlyingIterator.IsDone());
        }
    }
}
