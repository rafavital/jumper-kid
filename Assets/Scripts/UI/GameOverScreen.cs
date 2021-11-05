using UnityEngine;
using TMPro;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameOverScreen : MonoBehaviour
    {
        private CanvasGroup canvasGroup;

        public CanvasGroup CanvasGroup
        {
            get
            {
                if (canvasGroup)
                    return canvasGroup;
                else
                    return canvasGroup = GetComponent<CanvasGroup>();
            }
            set => canvasGroup = value;
        }

        private void Awake()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            Hide();
        }

        public void Show() => SetVisibility(true);

        public void Hide() => SetVisibility(false);

        public void SetVisibility(bool visible)
        {
            CanvasGroup.alpha = visible ? 1 : 0;
            CanvasGroup.interactable = visible;
            CanvasGroup.blocksRaycasts = visible;
        }
    }
}