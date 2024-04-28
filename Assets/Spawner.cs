using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    public GameObject enemy;
    private bool canSpawn = true;

    private void Start() {
        StartCoroutine(SpawnerGenerator());
    }

    private IEnumerator SpawnerGenerator() {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while(canSpawn) {
            yield return wait;

            float spawnPointX = Random.Range(-15f, -5f);            
            float spawnPointY = -8.31f;

            Vector2 spawnPosition = new Vector2(spawnPointX,spawnPointY);

            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }

    }
}
