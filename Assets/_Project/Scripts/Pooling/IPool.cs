using System.Collections.Generic;

namespace Project.Pooling
{
    public interface IPool<T>
    {
        Stack<T> Items { get; set; }

        T Create();
        T Request();
        List<T> Request(int amount);
        void Return(T item);
        void Return(List<T> items);
    }
}
