using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseTower : MonoBehaviour
{
    static private BaseTower S;

    [Header("Inscribed")]
    public int health = 150;

    public Text baseTowerHealth;

    void Awake() {
        if (S == null) {
            S = this;
        }
    }

    void Update() {
        baseTowerHealth.text = "Core Health:" + health.ToString();
    }

    //After the base tower is hit, check to see if the collision was from enemy or large enemy object. If it is from enemy type, deal base tower damage depending on the enemy type. Destroy game object in collision.
    void OnCollisionEnter(Collision coll) {
        GameObject collGO = coll.gameObject;
        if(collGO.tag == "Enemy") {
            health = health - 35;
        }
        if(collGO.tag == "LargeEnemy") {
            health = health - 50;
        }
        Destroy(collGO);
        if(health <= 0) {
            Destroy(gameObject);
        }
        Debug.Log(health);
    }
}
