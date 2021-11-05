using UnityEngine;
using TMPro;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameOverScreen : MonoBehaviour
    {
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            Hide();
        }

        public void Show() => SetVisibility(true);

        public void Hide() => SetVisibility(false);

        public void SetVisibility(bool visible)
        {
            canvasGroup.alpha = visible ? 1 : 0;
            canvasGroup.interactable = visible;
            canvasGroup.blocksRaycasts = visible;
        }
    }
}