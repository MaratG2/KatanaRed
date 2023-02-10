using KatanaRed.Utils.Scriptables;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Movement.Dash
{
    public abstract class Dashable : MonoBehaviour
    {
        [Header("Dependencies")] 
        [SerializeField, Required] protected HorizontalDashSO dashData;
        [SerializeField, Required] protected Rigidbody2D rb2d;

        public abstract void Dash();
    }
}