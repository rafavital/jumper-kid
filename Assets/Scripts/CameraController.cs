using UnityEngine;
using UnityAtoms.BaseAtoms;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] LevelInfo levelInfo;
    [SerializeField] private FloatConstant startMovingHeight;

    private bool startedMoving, isMoving;
    private bool canMove;
    private float targetStartY;
    private void Awake()
    {
        levelInfo.mainCamera = Camera.main;
        levelInfo.sceneBounds = new Vector2(levelInfo.mainCamera.orthographicSize * levelInfo.mainCamera.aspect, levelInfo.mainCamera.orthographicSize);
        isMoving = false;
        startedMoving = false;
    }

    private void Update()
    {
        //TODO: remove this hardcoded value
        if (!startedMoving && target.position.y - targetStartY > startMovingHeight.Value)
        {
            StartMoving();
            startedMoving = true;
        }

        if (isMoving)
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }

    public void HandleStartGame()
    {
        targetStartY = target.position.y;
    }

    [ContextMenu("StartMoving")]
    private void StartMoving() => isMoving = true;

    public void StopMoving() => isMoving = false;
}
