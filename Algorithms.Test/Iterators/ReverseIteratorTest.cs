namespace Algorithms.Test.Iterators
{
    using Algorithms.Exceptions;
    using Algorithms.Implementations.Iterators;
    using Algorithms.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ReverseIteratorTest
    {
        private object[] array;
        private ICustomIterator arrayIterator;
        private ICustomIterator iterator;

        [TestInitialize]
        public void Initialize()
        {
            this.array = new object[] { "A", "B", "C" };
            this.arrayIterator = new ArrayIterator(this.array);
        }

        [TestMethod]
        public void ReverseIterator_ForwardIterations_IterateBackwards()
        {
            this.iterator = new ReverseIterator(this.arrayIterator);

            this.iterator.First();
            Assert.IsFalse(this.iterator.IsDone());
            Assert.AreSame(this.array[2], this.iterator.Current());

            this.iterator.Next();
            Assert.IsFalse(this.iterator.IsDone());
            Assert.AreSame(this.array[1], this.iterator.Current());

            this.iterator.Next();
            Assert.IsFalse(this.iterator.IsDone());
            Assert.AreSame(this.array[0], this.iterator.Current());

            this.iterator.Next();
            Assert.IsTrue(this.iterator.IsDone());
            try
            {
                this.iterator.Current();
                Assert.Fail();
            }
            catch (IteratorOutOfBoundsException e)
            {
                //expected
            }
        }

        [TestMethod]
        public void ReverseIterator_BackwardIterations_IterateForward()
        {
            this.iterator = new ReverseIterator(this.arrayIterator);

            this.iterator.Last();
            Assert.IsFalse(this.iterator.IsDone());
            Assert.AreSame(this.array[0], this.iterator.Current());

            this.iterator.Previous();
            Assert.IsFalse(this.iterator.IsDone());
            Assert.AreSame(this.array[1], this.iterator.Current());

            this.iterator.Previous();
            Assert.IsFalse(this.iterator.IsDone());
            Assert.AreSame(this.array[2], this.iterator.Current());

            this.iterator.Previous();
            Assert.IsTrue(this.iterator.IsDone());
            try
            {
                this.iterator.Current();
                Assert.Fail();
            }
            catch (IteratorOutOfBoundsException e)
            {
                //expected
            }
        }
    }
}
