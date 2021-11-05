using UnityEngine;
using Player;

[CreateAssetMenu(menuName = "Scriptables/Level Info", fileName = "New Level Info")]
public class LevelInfo : ScriptableObject
{
    public PlayerController currentPlayer;
    public Camera mainCamera;
    public Vector2 sceneBounds = Vector2.zero;
    public float startingHeight;
}
