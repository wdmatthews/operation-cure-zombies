using UnityEngine;

namespace Project.Variables
{
    public abstract class Variable<T> : MonoBehaviour
    {
        [SerializeField] protected T _initialValue = default;
        [SerializeField] protected VariableSO<T> _variable = null;

        protected void Awake()
        {
            _variable.Value = _initialValue;
        }
    }
}
