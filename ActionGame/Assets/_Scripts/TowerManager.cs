using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [Header("Properties")]
    public int TowerCost;
    public float TowerHealth;
    public float TowerRange = 5f;
    public int TowerDamage = 10;
    public float attackSpeed = 3f;
    public float rotateSpeed = 10f;
    public bool CloseTargets = true;
    public bool hasTower = false;

    private float attackTimer = 0f;
    private Transform target;
    

    [Header("Objects")]
    public GameObject TowerPreFab;
    public GameObject CurrentTarget = null;

    [HideInInspector]
    public static GameObject playerObject;
    public PlayerController playerController;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        playerController = playerObject.GetComponent<PlayerController>();
    }

    public void CreateTower()
    {
        hasTower = true;
        print(playerController);
        playerController.coins -= TowerCost;
    }


    void DestroyTower()
    {

    }

    private GameObject GetTarget()
    {
        GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag("Enemy");

        if (possibleTargets.Length == 0)
        {
            return null;
        }

        GameObject target = possibleTargets[0]; // Grab the first element of the possibleTargets array as it is the earliest
        float targetDist = Vector3.Distance(TowerPreFab.transform.position, target.transform.position);
        
        foreach (GameObject possibleTarget in possibleTargets)
        {
            float distanceFromTower = Vector3.Distance(TowerPreFab.transform.position, possibleTarget.transform.position);
            if (CloseTargets == true)
            {
                if (distanceFromTower < targetDist)
                {  
                    targetDist = distanceFromTower; // Replace the targetDist
                    target = possibleTarget;
                }
            }
            else
            {
                if (distanceFromTower > targetDist)
                {  
                    targetDist = distanceFromTower; // Replace the targetDist
                    target = possibleTarget;
                }
            }
            
        }

        return target;
    }

    void Update()
    {
        if(hasTower == true) {
            GetTarget();
            if (TowerHealth < 0)
            {
                DestroyTower();
            }
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackSpeed) // determine if the amount of time has passed to attack again
            {
                CurrentTarget = GetTarget();
                if (CurrentTarget != null)  // if the CurrentTarget is found; closest one possible, initiate attack sequence
                {
                    RotateTowardsTarget();
                    if (Vector3.Distance(transform.position, CurrentTarget.transform.position) <= TowerRange)
                        {
                            CurrentTarget.GetComponent<Enemy>().OnBulletHit(TowerDamage);    // Through the script component of the Enemy GameObject, call TakeDamage
                            attackTimer = 0f;   // reset timer
                        }
                }
            }
        }
    }

    void RotateTowardsTarget()  // Rotate towards CurrentTarget
    {
        Vector3 direction = CurrentTarget.transform.position - transform.position;   
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);
    }

}