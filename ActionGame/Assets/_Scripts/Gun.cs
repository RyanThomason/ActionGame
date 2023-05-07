using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 300f;
    public Transform MainCamera;

    void Update() {
        
        //If mouse button is pressed shoots a bullet
        if(Input.GetKeyDown(KeyCode.Space)) {
            var bullet = Instantiate(bulletPrefab, BulletSpawnPoint.position, MainCamera.rotation);
            bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.forward * bulletSpeed;
        }
    }

}
