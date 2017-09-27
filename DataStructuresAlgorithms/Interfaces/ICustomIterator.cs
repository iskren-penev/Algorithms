namespace Algorithms.Interfaces
{
    using System;

    public interface ICustomIterator
    {
        void First();

        void Last();

        void Next();

        void Previous();

        bool IsDone();

        Object Current();
    }
}
