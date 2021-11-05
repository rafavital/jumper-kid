using UnityEngine;
using UnityAtoms.BaseAtoms;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] LevelInfo levelInfo;
    [SerializeField] private FloatConstant startMovingHeight;

    private bool moving;
    private bool canMove;
    private void Start()
    {
        moving = false;
        levelInfo.mainCamera = Camera.main;
        levelInfo.sceneBounds = new Vector2(levelInfo.mainCamera.orthographicSize * levelInfo.mainCamera.aspect, levelInfo.mainCamera.orthographicSize);
    }

    private void Update()
    {
        //TODO: remove this hardcoded value
        if (!moving && target.position.y > startMovingHeight.Value)
            StartMoving();

        if (moving)
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }

    [ContextMenu("StartMoving")]
    private void StartMoving()
    {
        moving = true;
    }

    public void StopMoving()
    {
        moving = false;
    }
}
