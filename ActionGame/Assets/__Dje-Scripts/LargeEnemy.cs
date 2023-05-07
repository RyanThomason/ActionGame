using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeEnemy : MonoBehaviour
{

    [Header("Inscribed")]
    public int health = 10;
    public float speed = 0.2f;

    //When an enemy is hit, set health to health minus damage, and check if health is 0 or less. If health is 0 or less, destroy the object   
    public void OnBulletHit(int damage) {
        Debug.Log(health);
        Debug.Log("Hit");
        health = health - damage;
        if(health <= 0) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
    }
}
