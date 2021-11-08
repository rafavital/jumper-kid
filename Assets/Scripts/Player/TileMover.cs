using UnityAtoms.BaseAtoms;
using UnityEngine;

public class TileMover : MonoBehaviour
{
    [SerializeField] private BoolEventReference OnSetFreezeTile;
    [SerializeField] private LayerMask tileLayer;
    private GameTile currentTile;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector2 touchPos = Vector2.zero;

        touchPos = Application.isEditor ? (Vector2)Input.mousePosition : Input.GetTouch(0).position;

        // when touch/click down and up
        bool down = Application.isEditor && Input.GetMouseButtonDown(0) || Application.isMobilePlatform && Input.GetTouch(0).phase == TouchPhase.Began;
        bool up = Application.isEditor && Input.GetMouseButtonUp(0) || Application.isMobilePlatform && Input.GetTouch(0).phase == TouchPhase.Ended;

        if (down)
        {
            // raycasts in the given screen position to search for a tile
            Ray ray = cam.ScreenPointToRay(touchPos);
            var hit = Physics2D.Raycast(cam.ScreenToWorldPoint(touchPos), Vector2.zero, float.MaxValue, tileLayer);
            if (hit)
            {
                currentTile = hit.collider.GetComponentInParent<GameTile>();

                if (currentTile)
                {
                    OnSetFreezeTile.Event.Raise(true);
                }
            }
            else
            {
                currentTile = null;
                OnSetFreezeTile.Event.Raise(false);
            }
        }
        else if (up)
        {
            // cleanup tile when released
            currentTile = null;
            OnSetFreezeTile.Event.Raise(false);
        }

        if (currentTile)
            currentTile.SetPosition(cam.ScreenToWorldPoint(touchPos));
    }


}
