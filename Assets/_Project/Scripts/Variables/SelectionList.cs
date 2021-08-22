using System.Collections.Generic;
using UnityEngine;

namespace Project.Variables
{
    public class SelectionList<T>
    {
        private readonly List<T> _list = new List<T>();
        public int CurrentIndex { get; private set; }
        public T Current { get; private set; }
        public int Count => _list.Count;

        public T this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }

        public void Add(T item) => _list.Add(item);
        public void AddRange(IEnumerable<T> items) => _list.AddRange(items);
        public void Remove(T item) => RemoveAt(_list.IndexOf(item));

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
            int currentIndex = CurrentIndex;
            if (currentIndex < 0 || index > currentIndex) return;

            if (_list.Count == 0)
            {
                CurrentIndex = -1;
                Current = default;
            }
            else if (index == 0 && currentIndex == 0)
            {
                Current = _list[0];
            }
            else
            {
                CurrentIndex--;
                Current = _list[currentIndex - 1];
            }
        }

        public void Clear()
        {
            _list.Clear();

            if (CurrentIndex >= 0)
            {
                CurrentIndex = -1;
                Current = default;
            }
        }

        public void Select(int index)
        {
            int itemCount = _list.Count;
            if (itemCount == 0) return;
            CurrentIndex = Mathf.Clamp(index, 0, itemCount);
            Current = _list[CurrentIndex];
        }

        public void SelectPrevious()
        {
            int index = CurrentIndex - 1;
            if (index < 0) index = _list.Count - 1;
            Select(index);
        }

        public void SelectNext()
        {
            int index = CurrentIndex + 1;
            if (index >= _list.Count) index = 0;
            Select(index);
        }
    }
}
