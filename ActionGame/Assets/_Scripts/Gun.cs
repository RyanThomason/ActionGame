using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    //variables for the gun and bullet speed
    public Transform BulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 300f;
    public Transform MainCamera;
    public AudioSource audioSource;

    //variables for overheating mechanic
    public float overheatThreshold = 100f; //Max heat level
    public float heatIncreaseRate = 10f; //how much heat increases when shooting
    public float heatDecreaseRate = 30f; //the rate at which the heat decreases
    public float currentHeatLevel = 0f; //measures the heat level
    private float overheatedTimer = 0f; //Timer that times the delay after overheating
    private float overheatDelay = 4f; //The time of the delay after overheating
    public float overheatPercent = 0f; //heat percent for UI to ensure it stays in the 0-100 range
    private bool isOverheated = false;
    public Text heatPercent;

    void Update() {

        //keeps the percent in the 0-100 range and sets the UI heat level
        overheatPercent = Mathf.Clamp(currentHeatLevel, 0f, 100f);
        heatPercent.text = "Heat Level: " + Mathf.RoundToInt(overheatPercent) + "%";

        //If it is overheated it waits for the timer then it also decreases the heat overtime if it is not overheated
        if (isOverheated) {
            overheatedTimer -= Time.deltaTime;
            if (overheatedTimer <= 0.0) {
                isOverheated = false;
            }

            if (currentHeatLevel <= overheatThreshold) {
                isOverheated = false;
            }
        }
        else {
            currentHeatLevel -= heatDecreaseRate * Time.deltaTime;
            currentHeatLevel = Mathf.Clamp(currentHeatLevel, 0f, overheatThreshold);
        }
        
        //calls the Fire function when mouse is pressed.
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Fire();
        }

    }

    void Fire() {

        //checking if overheated and can fire or not
        if (!isOverheated) {
            
            //increases heat level and makes sure the heat is only to 100;
            currentHeatLevel += heatIncreaseRate;

            //spawns the bullet and pushes it forward
            GameObject bullet = Instantiate(bulletPrefab, BulletSpawnPoint.position, MainCamera.rotation);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.AddForce(BulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);
            Debug.Log(currentHeatLevel);
            audioSource.Play(0);

            //if the heat level goes above the threshold it sets it to overheated and starts the timer.
            if (currentHeatLevel >= overheatThreshold) {
                isOverheated = true;
                overheatedTimer = overheatDelay;

            }

        }
    }

}
