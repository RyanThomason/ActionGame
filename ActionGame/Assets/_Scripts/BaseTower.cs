using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseTower : MonoBehaviour
{
    static private BaseTower S;

    [Header("Inscribed")]
    public int health = 150;

    void Awake() {
        if (S == null) {
            S = this;
        }
    }

    //After the base tower is hit, check to see if the collision was from enemy or large enemy object. If it is from enemy type, deal base tower damage depending on the enemy type. Destroy game object in collision.
    void OnCollisionEnter(Collision coll) {
        GameObject collGO = coll.gameObject;
        if(collGO.tag == "Enemy") {
            health = health - 35;
        }
        Destroy(collGO);
        if(health <= 0) {
            //Change Scenes
        }
    }
}
