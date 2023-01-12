using System.Runtime.CompilerServices;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KatanaRed.Cameras
{
    public class ChangeCameraFromTrigger : MonoBehaviour
    {
        [SerializeField, Required] private CinemachineVirtualCamera _cameraToEnable;
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                return;
            
            Camera.main.GetComponent<CinemachineBrain>().
                ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
            _cameraToEnable.gameObject.SetActive(true);
        }
    }
}