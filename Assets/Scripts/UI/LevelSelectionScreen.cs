using UnityEngine;
using DG.Tweening;

public class LevelSelectionScreen : MonoBehaviour
{
    [SerializeField] private RectTransform content;

    [Header("Animation")]
    [SerializeField] private float animDuration = 1f;
    [SerializeField] private Ease animEase = Ease.InOutElastic;


    private void Start()
    {
        content.localScale = Vector3.zero;
    }

    [ContextMenu("Show")]
    public void Show() => content.DOScale(Vector3.one, animDuration).SetEase(animEase);

    [ContextMenu("Hide")]
    public void Hide() => content.DOScale(Vector3.zero, animDuration).SetEase(animEase);

}
