using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BaseTower : MonoBehaviour
{

    [Header("Inscribed")]
    public int health = 150;

    public Text baseTowerHealth;

    void Update() {
        baseTowerHealth.text = "Core Health: " + health.ToString();
    }

    //After the base tower is hit, check to see if the collision was from enemy or large enemy object. If it is from enemy type, deal base tower damage depending on the enemy type. Destroy game object in collision.
    void OnTriggerEnter(Collider coll) {
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