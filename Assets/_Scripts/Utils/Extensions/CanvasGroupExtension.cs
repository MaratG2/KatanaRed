using UnityEngine;

namespace KatanaRed.Utils
{
    public static class CanvasGroupExtension
    {
        public static void SetTo(this CanvasGroup canvasGroup, bool isActive)
        {
            canvasGroup.alpha = isActive ? 1 : 0;
            canvasGroup.interactable = isActive;
            canvasGroup.blocksRaycasts = isActive;
        }
    }
}