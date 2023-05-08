using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Most code replicated from Space Shmup
    [Header("Inscribed")]
    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;

    void Awake() {
        Invoke(nameof(SpawnEnemy), 1f/enemySpawnPerSecond);
    }

    public void SpawnEnemy() {
        Vector3 pos = transform.position;
        int ndx = Random.Range(0,prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);
        go.transform.position = pos;

        Invoke(nameof(SpawnEnemy), 1f/enemySpawnPerSecond);
    }
}
