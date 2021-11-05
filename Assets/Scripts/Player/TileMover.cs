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
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.MaxValue, tileLayer);
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
        else if (Input.GetMouseButtonUp(0))
        {
            currentTile = null;
            OnSetFreezeTile.Event.Raise(false);
        }
#endif

        if (currentTile)
            currentTile.SetPosition(cam.ScreenToWorldPoint(Input.mousePosition));
    }


}
