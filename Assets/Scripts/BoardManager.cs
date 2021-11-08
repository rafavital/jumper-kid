using System.Collections;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private float spawnDelay = 5f;
    [SerializeField] private GameTile[] allTiles;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Transform checkForTilePos;
    [SerializeField] private LayerMask tileLayer;
    [SerializeField] private VoidBaseEventReference onCameraStartMoving;
    private Coroutine spawnCoroutine;
    private WaitForSeconds spawnWait;

    private void OnEnable()
    {
        GameTile.OnTileSettle += SpawnNewBlock;
    }

    private void OnDisable()
    {
        GameTile.OnTileSettle -= SpawnNewBlock;
    }

    private void Awake() => spawnWait = new WaitForSeconds(spawnDelay);

    public void StartSpawning() => Invoke(nameof(SpawnNewBlock), 5f);

    private void SpawnNewBlock()
    {
        // if there is no space for another block, start moving the camera (if it isn't already) and try again in 5 seconds
        if (Physics2D.OverlapBox(checkForTilePos.position, new Vector2(checkForTilePos.localScale.x, checkForTilePos.localScale.y), 0, tileLayer))
        {
            onCameraStartMoving.Event.Raise();
            Invoke(nameof(SpawnNewBlock), 5f);
            return;
        }

        Instantiate(allTiles[Random.Range(0, allTiles.Length)], spawnPos.position, Quaternion.Euler(0, 0, 90 * Mathf.RoundToInt(Random.Range(0, 4))), transform);
    }

    private IEnumerator SpawnTimer()
    {
        while (true)
        {
            yield return spawnWait;
            SpawnNewBlock();
        }
    }
}
