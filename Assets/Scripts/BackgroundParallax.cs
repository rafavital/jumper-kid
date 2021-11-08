using UnityEngine;
using UnityAtoms.BaseAtoms;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private FloatConstant parallaxSpeed;
    [SerializeField] private LevelInfo gameInfo;
    [SerializeField] [Range(0, 1)] private float parallaxMultiplier = 1;
    private Vector3 lastCameraPos;

    private void Start()
    {
        lastCameraPos = gameInfo.mainCamera.transform.position;
    }

    private void LateUpdate()
    {
        var delta = (lastCameraPos - gameInfo.mainCamera.transform.position) * parallaxSpeed.Value * parallaxMultiplier;

        transform.position += new Vector3(delta.x, delta.y, 0);

        lastCameraPos = gameInfo.mainCamera.transform.position;
    }

}
