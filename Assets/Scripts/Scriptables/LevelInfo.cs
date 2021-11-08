using UnityEngine;
using Player;

[CreateAssetMenu(menuName = "Scriptables/Level Info", fileName = "New Level Info")]
public class LevelInfo : ScriptableObject
{
    public PlayerController currentPlayer;
    public Camera mainCamera;
    public Vector2 sceneBounds = Vector2.zero;
    public float startingHeight;

    public void SetStartingHeight(float value) => startingHeight = value;

    [ContextMenu("Clear")]
    private void OnEnable()
    {
        currentPlayer = null;
        mainCamera = null;
    }
}
