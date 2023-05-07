using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 3f;
    public float life = 3f;

    public GameManager GameManager;
    // Update is called once per frame
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter (Collision coll) {
        //If it is an enemy deal damage and destroy bullet
        if (coll.gameObject.CompareTag("Enemy")) {
            Debug.Log("Test");

        }
        //if anything else just destroy it
        else {
            Destroy(gameObject);
        }
    }
}
