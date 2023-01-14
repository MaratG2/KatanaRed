using System;
using UnityEngine;

namespace KatanaRed.Movement.Jump
{
    public class WallEvents : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private int _wallLayerMask;
        [SerializeField] private int _mixedLayerMask;
        [SerializeField] private bool _isLeft;
        public Action<bool> OnWallEntered { get; set; }
        public Action OnWallExited { get; set; }

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