using UnityEngine;
using UnityAtoms.BaseAtoms;

public class GameManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private LevelInfo gameInfo;
    [SerializeField] private FloatVariable timer;
    [SerializeField] private FloatVariable traveledDistance;
    [SerializeField] private Transform startingPlatform;

    private void Start()
    {
        if (gameInfo.startingHeight > 0)
        {
            SetStartingPlatform(new Vector3(0, gameInfo.startingHeight, 0));
        }
        else
            startingPlatform.gameObject.SetActive(false);
    }

    private void Update()
    {
        timer.Value += Time.deltaTime;
    }

    public void RestartLevel()
    {
        // set the platform right under the player
        var platformPos = gameInfo.currentPlayer.transform.position + Vector3.up * (gameInfo.currentPlayer.transform.lossyScale.y / 2 + 0.1f);
        SetStartingPlatform(platformPos);
    }

    private void SetStartingPlatform(Vector3 position)
    {
        startingPlatform.gameObject.SetActive(true);
        startingPlatform.position = -position;
    }
}
