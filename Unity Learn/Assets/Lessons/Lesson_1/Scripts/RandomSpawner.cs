using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private MonoBehaviour[] _scripts;
    [SerializeField] private float _maxSpawnRangeX;
    [SerializeField] private float _maxSpawnRangeY;
    [SerializeField] private float _maxSpawnRangeZ;
    private float startDelay = 2f;
    private float spawnInterval = 3f;
    private Vector3 spawnPos;

    void Start()
    {
        InvokeRepeating("SpawnRandomPrefabs", startDelay, spawnInterval);
    }

    void SpawnRandomPrefabs()
    {
        int prefabIndex = Random.Range(0, _prefabs.Length);
        spawnPos.Set(
            Random.Range(-_maxSpawnRangeX, _maxSpawnRangeX),
            Random.Range(-_maxSpawnRangeY, _maxSpawnRangeY),
            Random.Range(-_maxSpawnRangeZ, _maxSpawnRangeZ)
            );
        GameObject gameObject = Instantiate(_prefabs[prefabIndex], spawnPos, _prefabs[prefabIndex].transform.rotation);
        int scriptIndex = Random.Range(0, _scripts.Length);
        gameObject.AddComponent(_scripts[scriptIndex].GetType());
    }
}
