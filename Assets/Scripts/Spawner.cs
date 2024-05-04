using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    public GameObject enemyPrefab;
    private bool canSpawn = true;
    private int enemiesAlive = 0;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private void Start() {
        StartCoroutine(SpawnerGenerator());
    }

    private IEnumerator SpawnerGenerator() {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while(canSpawn) {
            yield return wait;

            if(enemiesAlive < 5) {
                float spawnPointX = Random.Range(-15f, -2f);            
                float spawnPointY = -7.7f;
                enemiesAlive++;

                Vector2 spawnPosition = new Vector2(spawnPointX,spawnPointY);

                GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                newEnemy.GetComponent<KillPlayer>().OnDeath += HandleEnemyDeath;
                spawnedEnemies.Add(newEnemy);
            } 
        }
    }

    void HandleEnemyDeath()
    {
        enemiesAlive--;
    }
}
