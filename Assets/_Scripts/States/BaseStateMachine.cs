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

        public virtual void InitStateMachine(BaseState state, Enum initState)
        {
            this._state = state;
            SetStateTo(initState);
            if(_isDebugOn)
                DebugLogStateChanged();
        }
        public virtual void SetStateTo(Enum newState)
        {
            if (CheckStateIs(newState))
                return;
            
            _state.State = newState;
            OnStateChanged?.Invoke();
        }
        public virtual bool CheckStateIs(params Enum[] checkStates)
        {
            bool equals = false;
            foreach (var checkState in checkStates)
            {
                if(_state == null || _state.State == null)
                    continue;
                
                if (_state.State.Equals(checkState))
                    equals = true;
            }
            return equals;
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