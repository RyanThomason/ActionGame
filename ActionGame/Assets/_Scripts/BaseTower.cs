using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseTower : MonoBehaviour
{
    [Header("Inscribed")]
    public int health = 150;


    //After the base tower is hit, check to see if the collision was from enemy or large enemy object. If it is from enemy type, deal base tower damage depending on the enemy type. Destroy game object in collision.
    void OnTriggerEnder(Collider coll) {
        GameObject collGO = coll.gameObject;
        Debug.Log("Trigger");
        if(collGO.tag == "Enemy") {
            health = health - 35;
        }
        Destroy(collGO);
        if(health <= 0) {
            //Change Scenes
        }
    }
}
