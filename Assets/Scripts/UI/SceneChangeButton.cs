using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneChangeButton : MonoBehaviour
{
    [SerializeField] private LevelId levelToLoad;
    [SerializeField] private float loadDelay = 0;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }

    public void LoadLevel() => Invoke(nameof(Load), loadDelay);
    private void Load() => LevelLoader.LoadLevel(levelToLoad);
}
