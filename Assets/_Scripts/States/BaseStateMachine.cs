using System;
using System.Linq;
using UnityEngine;

namespace KatanaRed.States
{
    public abstract class BaseStateMachine : MonoBehaviour
    {
        [SerializeField] private bool _isDebugOn;
        private BaseState _state;
        public Action OnStateChanged;

        public virtual void InitStateMachine(BaseState state)
        {
            this._state = state;
        }
        public virtual void SetStateTo(Enum newState)
        {
            _state.State = newState;
            OnStateChanged?.Invoke();
        }
        public virtual bool CheckStateIs(Enum checkState)
        {
            return _state.State.Equals(checkState);
        }

        protected virtual void OnEnable()
        {
            if (_isDebugOn)
                OnStateChanged += DebugLogStateChanged;
        }

        protected virtual void OnDisable()
        {
            if (_isDebugOn)
                OnStateChanged -= DebugLogStateChanged;
        }

        private void DebugLogStateChanged()
        {
            Debug.Log($"{this.GetType().ToString().Split('.').Last()}" +
                      $": State changed to \"{_state.State}\"");
        }
    }
}