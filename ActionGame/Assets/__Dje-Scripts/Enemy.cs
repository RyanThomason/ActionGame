using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Inscribed")]
    public int health = 5;
    public float speed = 10f;
    Vector3 leftTurn = new Vector3(0, -90, 0);
    Vector3 rightTurn = new Vector3(0, 90, 0);

    //When an enemy is hit, set health to health minus damage, and check if health is 0 or less. If health is 0 or less, destroy the object   
    public void OnBulletHit(int damage) {
        health = health - damage;
        if(health <= 0) {
            Destroy(gameObject);
        }
    }

    //When the game object triggers an object with TurnLeft or TurnRight tag, turn in that direction
    void OnTriggerEnter(Collider coll) {
        GameObject collGO = coll.gameObject;
        if(collGO.tag == "TurnLeft") {
            transform.Rotate(leftTurn);
        }
        if(collGO.tag == "TurnRight") {
            transform.Rotate(rightTurn);
        }
    }

    //Reads where the gameObject is facing and moves toward that direction
    void Move() {
        Debug.Log(transform.rotation.eulerAngles.y);
        if(transform.rotation.eulerAngles.y == 0) { 
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
        }
        if(transform.rotation.eulerAngles.y == 270) {
            Vector3 pos = transform.position;
            pos.z += speed * Time.deltaTime;
            transform.position = pos;
        }   
        if(transform.rotation.eulerAngles.y ==180) {
            Vector3 pos = transform.position;
            pos.x -= speed * Time.deltaTime;
            transform.position = pos;
        } 
        if(transform.rotation.eulerAngles.y == 90) {
            Vector3 pos = transform.position;
            pos.z -= speed * Time.deltaTime;
            transform.position = pos;
        }
    }
    // Calls the move method
    void Update()
    {
        Move();
    }
    
}
