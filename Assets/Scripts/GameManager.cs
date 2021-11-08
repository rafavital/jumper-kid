using UnityEngine;
using UnityAtoms.BaseAtoms;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform startingPlatform;

    [Header("Data")]
    [SerializeField] private LevelInfo gameInfo;
    [SerializeField] private FloatVariable timer;
    [SerializeField] private FloatVariable traveledDistance;
    [SerializeField] private GameObjectValueList tilesList;

    [Header("Events")]
    [SerializeField] private VoidBaseEventReference onStartGame;

    private bool isRunning;

    private void Start()
    {
        if (gameInfo.startingHeight > 0)
        {
            gameInfo.mainCamera.transform.position = Vector3.up * gameInfo.startingHeight + Vector3.forward * gameInfo.mainCamera.transform.position.z;
            gameInfo.currentPlayer.ResetPlayer();
            var platformPos = gameInfo.currentPlayer.transform.position - Vector3.up * 0.5f;
            SetStartingPlatform(platformPos);
        }
        else
            startingPlatform.gameObject.SetActive(false);

        StartGame();
    }

    private void Update()
    {
        if (isRunning)
            timer.Value += Time.deltaTime;
    }

    public void RestartLevel()
    {
        // set the platform right under the player
        var platformPos = gameInfo.currentPlayer.transform.position - Vector3.up * 0.5f;
        SetStartingPlatform(platformPos);

        StartGame();
    }

    public void GameOver()
    {
        isRunning = false;
    }

    private void SetStartingPlatform(Vector3 position)
    {
        startingPlatform.gameObject.SetActive(true);
        startingPlatform.position = position;
    }

    private void StartGame()
    {
        // clear all tiles from screen
        if (tilesList.List.Count > 0)
        {
            foreach (var tile in tilesList.List)
            {
                Destroy(tile);
            }
        }

        isRunning = true;
        onStartGame.Event.Raise();
    }
}
