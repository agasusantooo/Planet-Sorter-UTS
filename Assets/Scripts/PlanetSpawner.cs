using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject[] planetPrefabs;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnPlanet", 1f, spawnInterval);
    }

    void SpawnPlanet()
    {
        int index = Random.Range(0, planetPrefabs.Length);

        // Ambil posisi spawner
        Vector3 spawnPos = transform.position;

        // Spawn planet
        Instantiate(planetPrefabs[index], spawnPos, Quaternion.identity);
    }
}
