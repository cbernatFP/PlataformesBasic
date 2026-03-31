using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearBombes : MonoBehaviour
{
    public GameObject sawPrefab; // Prefab de la bomba

    public float spawnY = 1.5f; // Y fixa
    public float minX = -3.7f, maxX = 3.7f; // Rang de X
    public float minSpawnTime = 1f, maxSpawnTime = 3f; // Interval de temps aleatori

    void Start() {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects() {
        while (true) {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);
            Instantiate(sawPrefab, spawnPosition, Quaternion.identity);

            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
