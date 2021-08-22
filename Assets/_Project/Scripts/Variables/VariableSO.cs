using UnityEngine;

namespace Project.Variables
{
    public abstract class VariableSO<T> : ScriptableObject
    {
        [SerializeField] private T _value = default;

        public T Value { get => _value; set => _value = value; }
    }
}
