using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Inscribed")]
    public int damage = 1;

    //When a projectile comes into contact with something, it checks if it was an enemy or a large enemy. If a type of enemy, do damage to that enemy. Destroy after collision.
    void OnTriggerEnter(Collider col) {
        GameObject go = col.gameObject;
        if(go.tag == "Enemy") {
            Enemy enemy = go.GetComponent<Enemy>();
            enemy.OnBulletHit(damage);
        }
        Destroy(gameObject);
    }
}
