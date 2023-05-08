using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage = 3;
    public float life = 3f;
    // Update is called once per frame
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter (Collision coll) {
        //If it is an enemy deal damage and destroy bullet
        GameObject go = coll.gameObject;
        if (go.gameObject.CompareTag("Enemy")) {
            if(go.tag == "Enemy") {
            Enemy enemy = go.GetComponent<Enemy>();
            enemy.OnBulletHit(damage);
        }

        }
        //if anything else just destroy it
        else {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter (Collider coll) {
        GameObject go = coll.gameObject;
        Debug.Log("Trigger");
        if (go.gameObject.CompareTag("Button")) {
            Debug.Log("Trigger");
            EnemySpawner spawner = go.GetComponent<EnemySpawner>();
            spawner.OnClick();
        }
    }
}