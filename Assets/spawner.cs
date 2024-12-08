using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private const float Y_OFFSET = 0.1f; // 10cm offset in Unity units

    void Start()
    { 
    }

    public void SpawnPrefabAtTransform(Transform spawnPoint)
    {
        if (prefabToSpawn == null)
        {
            Debug.LogError("Prefab to spawn is not assigned!");
            return;
        }

        Vector3 spawnPosition = spawnPoint.position + new Vector3(0, Y_OFFSET, 0);
        Instantiate(prefabToSpawn, spawnPosition, spawnPoint.rotation);
    }
}