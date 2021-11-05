using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] LevelInfo levelInfo;

    private bool moving;
    private void Start()
    {
        moving = false;
        levelInfo.mainCamera = Camera.main;
        levelInfo.sceneBounds = new Vector2(levelInfo.mainCamera.orthographicSize * levelInfo.mainCamera.aspect, levelInfo.mainCamera.orthographicSize);
    }

    private void Update()
    {
        //TODO: remove this hardcoded value
        if (!moving && target.position.y > 4)
            StartMoving();

        if (moving)
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }

    [ContextMenu("StartMoving")]
    private void StartMoving()
    {
        moving = true;
    }
}
