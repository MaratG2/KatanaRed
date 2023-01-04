using System;
using UnityEngine;

namespace KatanaRed.Movement
{
    public class WallJumpEventWrapper : MonoBehaviour
    {
        [SerializeField] private int _wallLayerMask;
        [SerializeField] private int _mixedLayerMask;
        [SerializeField] private bool _isLeft;
        public Action<bool> OnWallEntered;
        public Action OnWallExited;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.layer != _wallLayerMask
                && col.gameObject.layer != _mixedLayerMask)
                return;
            
            OnWallEntered?.Invoke(_isLeft);
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.layer != _wallLayerMask
                && col.gameObject.layer != _mixedLayerMask)
                return;
            
            OnWallExited?.Invoke();
        }
    }
}