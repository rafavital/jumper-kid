using System.Collections;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private float spawnDelay = 5f;
    [SerializeField] private GameTile[] allTiles;
    [SerializeField] private Transform spawnPos;
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
        Instantiate(allTiles[Random.Range(0, allTiles.Length)], spawnPos.position, Quaternion.identity, transform);
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
