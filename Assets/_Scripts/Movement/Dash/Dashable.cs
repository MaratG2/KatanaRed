using KatanaRed.Utils.Scriptables;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Movement.Dash
{
    public abstract class Dashable : MonoBehaviour
    {
        [Header("Dependencies")] 
        [SerializeField, Required] protected DashSO dashData;
        [SerializeField, Required] protected Rigidbody2D rb2d;
        protected bool _isDashReady = true;
        public abstract void Dash();
    }
}