using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Most code replicated from Space Shmup
    [Header("Inscribed")]
    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 1f;
    public int waveCount = 0;
    public int waveMax = 5;
    public int enemyCount = 0;

    //On awake, start the first wave
    void Awake() {
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave() {
        waveCount++;
        //If the waveCount is equal to 1, spawn 10 enemies, 1 second apart
        if(waveCount == 1) {
            for(enemyCount = 10; enemyCount > 0; enemyCount--) {
                yield return new WaitForSeconds(1);
                Invoke(nameof(SpawnEnemy), 1f/enemySpawnPerSecond);
            }
        }
        //If the waveCount is equal to 2, spawn 20 enemies
        if(waveCount == 2) {
            for(enemyCount = 20; enemyCount > 0; enemyCount--) {
                yield return new WaitForSeconds(1);
                Invoke(nameof(SpawnEnemy), 1f/enemySpawnPerSecond);
            }
        }
        //If the waveCount is equal to 3, spawn 30 enemies, 1 second apart
        if(waveCount == 3) {
            for(enemyCount = 30; enemyCount > 0; enemyCount--) {
                yield return new WaitForSeconds(1);
                Invoke(nameof(SpawnEnemy), 1f/enemySpawnPerSecond);
            }
        }
        //If the waveCount is equal to 4, spawn 40 enemies, 1 second apart
        if(waveCount == 4) {
            for(enemyCount = 40; enemyCount > 0; enemyCount--) {
                yield return new WaitForSeconds(1);
                Invoke(nameof(SpawnEnemy), 1f/enemySpawnPerSecond);
            }
        }  
        //If the waveCount is equal to 5, spawn 50 enemies, 1 second apart
        if(waveCount == 5) {
            for(enemyCount = 50; enemyCount > 0; enemyCount--) {
                yield return new WaitForSeconds(1);
                Invoke(nameof(SpawnEnemy), 1f/enemySpawnPerSecond);
            }
        }
        yield return new WaitForSeconds(0);
    }

    //Spawn enemies on the enemySpawner position
    public void SpawnEnemy() {
        Vector3 pos = transform.position;
        int ndx = Random.Range(0,prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);
        go.transform.position = pos;
    }
}
