using System.Collections.Generic;
using UnityEngine;

namespace Project.Pooling
{
    public abstract class PoolSO<T> : ScriptableObject, IPool<T> where T : MonoBehaviour
    {
        public T Prefab = default;
        public Stack<T> Items { get; set; } = new Stack<T>();

        public virtual T Create() => Instantiate(Prefab);

        public virtual T Request()
        {
            return Items.Count > 0 ? Items.Pop() : Create();
        }

        public virtual List<T> Request(int amount)
        {
            List<T> items = new List<T>();

            for (int i = 0; i < amount; i++)
            {
                items.Add(Request());
            }

            return items;
        }

        public virtual void Return(T item)
        {
            Items.Push(item);
        }

        public virtual void Return(List<T> items)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                Return(items[i]);
            }
        }
    }
}
