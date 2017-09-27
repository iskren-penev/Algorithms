namespace Algorithms.Test.Iterators
{
    using System;
    using Algorithms.Exceptions;
    using Algorithms.Implementations.Iterators;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArrayIteratorTest
    {
        private ArrayIterator iterator;
        private object[] array;

        
        [TestMethod]
        public void Iterator_Iteration_RespectsBounds()
        {
            this.array = new object[]{"A", "B", "C", "D", "E", "F"};
            this.iterator= new ArrayIterator(this.array, 1,3);

            this.iterator.First();
            Assert.IsFalse(this.iterator.IsDone());
            Assert.AreSame(this.array[1], this.iterator.Current());

            this.iterator.Next();
            Assert.IsFalse(this.iterator.IsDone());
            Assert.AreSame(this.array[2], this.iterator.Current());

            this.iterator.Next();
            Assert.IsFalse(this.iterator.IsDone());
            Assert.AreSame(this.array[3], this.iterator.Current());

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
        public void Iterator_IteratesBackwards()
        {
            this.array = new object[] { "A", "B", "C"};
            this.iterator = new ArrayIterator(this.array);

            this.iterator.Last();
            Assert.IsFalse(this.iterator.IsDone());
            Assert.AreSame(this.array[2], this.iterator.Current());

            this.iterator.Previous();
            Assert.IsFalse(this.iterator.IsDone());
            Assert.AreSame(this.array[1], this.iterator.Current());

            this.iterator.Previous();
            Assert.IsFalse(this.iterator.IsDone());
            Assert.AreSame(this.array[0], this.iterator.Current());

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
