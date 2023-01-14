using System;
using UnityEngine;

namespace KatanaRed.Movement.Jump
{
    public class JumpEventWrapper : MonoBehaviour
    {
        [SerializeField] private int _groundLayerMask;
        [SerializeField] private int _mixedLayerMask;
        public Action OnGroundEntered;
        public Action OnGroundExited;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.layer != _groundLayerMask
                && col.gameObject.layer != _mixedLayerMask)
                return;
            
            OnGroundEntered?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.layer != _groundLayerMask
                && col.gameObject.layer != _mixedLayerMask)
                return;
            
            OnGroundExited?.Invoke();
        }
    }
}